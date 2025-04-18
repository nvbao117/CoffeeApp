using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class PasswordResetTokenRepository
    {
        private readonly AppContext _context;

        public PasswordResetTokenRepository()
        {
            _context = new AppContext();
        }

        // Thêm token vào database
        public void Add(PasswordResetToken token)
        {
            var existingToken = _context.PasswordResetTokens
                              .FirstOrDefault(t => t.UserId == token.UserId);

            if (existingToken == null)
            {
                // Nếu chưa tồn tại, thêm mới token
                _context.PasswordResetTokens.Add(token);
                _context.SaveChanges();
            }
            else
            {
                existingToken.Token = token.Token;
                existingToken.Expr = token.Expr;
                existingToken.IsUsed = token.IsUsed;
                existingToken.CreateAt = token.CreateAt;

                _context.SaveChanges();
            }
        }

        // Đánh dấu token là đã dùng (IsUsed = true)
        public void MarkAsUsed(int tokenId)
        {
            var existToken = _context.PasswordResetTokens.Find(tokenId);
            if (existToken != null)
            {
                existToken.IsUsed = true;
                _context.SaveChanges();
            }
        }

        // Tùy chọn: Xóa thật sự token khỏi DB
        public void Delete(int tokenId)
        {
            var token = _context.PasswordResetTokens.Find(tokenId);
            if (token != null)
            {
                _context.PasswordResetTokens.Remove(token);
                _context.SaveChanges();
            }
        }

        public bool CheckValidate(int userId , string token)
        {
            return _context.Database.SqlQuery<bool>("EXEC [dbo].SP_ValidateOTP @P1,@P2", 
                new SqlParameter("@P1", userId),
                new SqlParameter("@P2", token)
                ).FirstOrDefault(); 
        }
    }
}
