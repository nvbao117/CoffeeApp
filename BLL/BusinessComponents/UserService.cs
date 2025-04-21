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

        public List<UserDTO> getAllUser()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            var users = _userRepository.GetAll();
            foreach (var user in users)
            {
                UserDTO userDTO = UserMapper.ToDTO(user);
                userDTOs.Add(userDTO);
            }
            return userDTOs;
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
            var existUserById = _userRepository.GetById(userDto.UserId);
            if (existUserById != null) 
            {
                throw new Exception($"Người dùng với ID {userDto.UserId} đã tồn tại.");
                
            }
            var existUserByUsername = _userRepository.GetByUsername(userDto.Username);
            if (existUserByUsername != null)
            {
                throw new Exception($"Người dùng với username '{userDto.Username}' đã tồn tại.");

            }
            var user = UserMapper.ToEntity(userDto);
            _userRepository.Add(user);
           

            _recentActivityService.Log(
               action: "Add",
               target: "User",
               description: $"Người dùng '{user.Username}' vừa được thêm vào",
               userName: user.Username
           );
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
        public void UpdateUser(UserDTO userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            var existingUser = _userRepository.GetById(userDto.UserId);
            if (existingUser == null)
                throw new Exception($"Không tìm thấy người dùng với ID = {userDto.UserId}");

            var userWithSameUsername = _userRepository.GetByUsername(userDto.Username);
            if (userWithSameUsername != null && userWithSameUsername.UserId != userDto.UserId)
                throw new Exception($"Username '{userDto.Username}' đã được sử dụng bởi người dùng khác.");

            var user = Mappers.UserMapper.ToEntity(userDto);
            user.UserId = existingUser.UserId;

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

        public List<UserDTO> GetListUserByUsername(string username)
        {
            var users = _userRepository.GetListUserByUsername(username);
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                UserDTO userDTO = UserMapper.ToDTO(user);
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }
        public List<UserDTO> GetListUserByRole(int role)
        {
            var users = _userRepository.GetListUserByRole(role);
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                UserDTO userDTO = UserMapper.ToDTO(user);
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }
    }

}
