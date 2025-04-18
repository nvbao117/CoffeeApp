using BLL.BusinessEntities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class PasswordResetTokenMapper
    {
        public static PasswordResetTokenDTO ToDTO(PasswordResetToken token)
        {
            return new PasswordResetTokenDTO
            {
                CreatedAt = token.CreateAt,
                UserId = token.UserId,
                ExpiryDate = token.Expr,
                IsUsed = token.IsUsed,
                Token = token.Token
            };
        }

        public static PasswordResetToken ToEntity(PasswordResetTokenDTO token)
        {
            return new PasswordResetToken
            {
                CreateAt = token.CreatedAt,
                UserId = token.UserId,
                Expr = token.ExpiryDate,
                IsUsed = token.IsUsed,
                Token = token.Token
            };
        }
    }
}
