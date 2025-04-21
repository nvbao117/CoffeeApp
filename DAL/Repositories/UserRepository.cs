using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace DAL.Repositories
{
    public class UserRepository 
    {
        private readonly AppContext _context;
        public UserRepository()
        {
            _context = new AppContext();
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }
        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public string GetEmailByUserName(string username)
        {
            return _context.Database.SqlQuery<string>("SELECT dbo.func_GetEmailByUserName(@p0)", username).FirstOrDefault();
        }

        public string GetFullName(int userid)
        {
            string fullName = _context.Database.SqlQuery<string>("SELECT dbo.func_getFullName(@p0)", userid).FirstOrDefault();
            return fullName; 
        }
        public void Update(User user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                existingUser.IsActive = user.IsActive;
                existingUser.LastLoginDate = user.LastLoginDate;
                existingUser.CreatedDate = user.CreatedDate;
                _context.SaveChanges();
            }
        }
        public List<User> GetListUserByUsername(string username)
        {
            return _context.Users.Where(u => u.Username.ToLower().Contains(username)).ToList();
        }

        public List<User> GetListUserByRole(int role)
        {
            return _context.Users.Where(u => u.Role == role).ToList();
        }
    }

}
