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

namespace BLL.BusinessComponents
{
    public class UserService 
    {
        //public UserDTO GetUserById(int id)
        //{
        //    var user = _userRepository.GetById(id);
        //    return user != null ? MapToDTO(user) : null;
        //}
        private readonly UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public UserDTO GetUserByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            return user != null ? UserMapper.ToDTO(user) : null;
        }

        //public IEnumerable<UserDTO> GetAllUsers()
        //{
        //    var users = _userRepository.GetAll();
        //    return users.Select(u => MapToDTO(u)).ToList();
        //}

        public void AddUser(UserDTO userDto)
        {
            var user = UserMapper.ToEntity(userDto);
            _userRepository.Add(user);
        }

        //public void UpdateUser(UserDTO userDto)
        //{
        //    var user = MapToEntity(userDto);
        //    _userRepository.Update(user);
        //}

        //public void DeleteUser(int id)
        //{
        //    _userRepository.Delete(id);
        //}

        // Helper methods
        //private UserDTO MapToDTO(User user)
        //{
        //    return new UserDTO
        //    {
        //        UserId = user.UserId,
        //        Username = user.Username,
        //        Password = user.Password,
        //        Role = user.Role,
        //        CreatedDate = user.CreatedDate,
        //        LastLoginDate = user.LastLoginDate,
        //        IsActive = user.IsActive
        //    };
        //}

        //private User MapToEntity(UserDTO dto)
        //{
        //    return new User
        //    {
        //        UserId = dto.UserId,
        //        Username = dto.Username,
        //        Password = dto.Password,
        //        Role = dto.Role,
        //        CreatedDate = dto.CreatedDate,
        //        LastLoginDate = dto.LastLoginDate,
        //        IsActive = dto.IsActive
        //    };
        //}

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
