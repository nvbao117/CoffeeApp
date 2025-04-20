using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessEntities;
using DAL.Entities;
using DAL;
using AppContext = DAL.AppContext;
using DAL.Repositories;
using BLL.Mappers;
using System.Net.Mail;
using System.Net;

namespace BLL.BusinessComponents
{
    public class UserService 
    {

        private readonly RecentActivityService _recentActivityService;
        private readonly UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
            _recentActivityService = new RecentActivityService();
        }
        public UserDTO GetUserByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return user != null ? UserMapper.ToDTO(user) : null;
        }


        public string getFullName(int userId)
        {

            string fullname =  _userRepository.GetFullName(userId); 
            if(fullname == null)
            {
                throw new Exception("J=Không tìm thấy họ tên cho người dùng có Id :" + userId); 
            }
            return fullname;
        }
        public void AddUser(UserDTO userDto)
        {
            var user = UserMapper.ToEntity(userDto);
            _userRepository.Add(user);
            _recentActivityService.Log(
               action: "Add",
               target: "User",
               description: $"Người dùng '{user.Username}' vừa được thêm vào",
               userName: user.Username
           );
        }

        public void UpdateUser(UserDTO userDto)
        {

            var user = Mappers.UserMapper.ToEntity(userDto);
            _userRepository.Update(user);
            _recentActivityService.Log(
                action: "Update",
                target: "User",
                description: $"Người dùng '{user.Username}' vừa được cập nhật",
                userName: user.Username
            );
        }
        public (UserDTO,string) GetUserAndEmailByUsername(string username)
        {
            var user = GetUserByUsername(username);
            var email = _userRepository.GetEmailByUserName(username);

            return (user,email);
        }

        public List<RoleDTO> getAllRole()
        {
            using (var context = new AppContext())
            {
                var result = context.Database.SqlQuery<RoleDTO>("EXEC [dbo].[SP_GetAllRole]").ToList();
                return result; 
            }
        }
    }

}
