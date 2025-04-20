using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using BLL.BusinessEntities;
using DAL.Entities;
using BLL.Mappers;
namespace BLL.BusinessComponents
{
    public class AuthService 
    {
        private readonly UserRepository _userRepository;
        private readonly RecentActivityService _recentActivityService;

        public static UserDTO _currentUser;
        public static UserDTO CurrentUser
        {
            get { return _currentUser; }
            private set { _currentUser = value; }
        }

        public AuthService()
        {
            _userRepository = new UserRepository();
            _recentActivityService = new RecentActivityService();
        }
        public static bool IsAuthenticated
        {
            get { return CurrentUser != null; }
        }
        public static bool IsAdmin
        {
            get { return CurrentUser != null && CurrentUser.Role == 1; }
        }
        public static bool IsEmployee
        {
            get { return CurrentUser != null && CurrentUser.Role == 2; }
        }
        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            var user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                return false;
            }


            if (user.Password == password)
            {
                user.LastLoginDate = DateTime.Now;
                _userRepository.Update(user);
                CurrentUser = UserMapper.ToDTO(user);
                _recentActivityService.Log(
                    action: "Login",
                    target: "User",
                    description: $"Người dùng '{user.Username}' đăng nhập vào hệ thống",
                    userName: user.Username
                );
                return true;
            }
            return false;
        }
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
