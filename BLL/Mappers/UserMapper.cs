using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role,
                CreatedDate = user.CreatedDate,
                LastLoginDate = user.LastLoginDate,
                IsActive = user.IsActive
            };
        }
        
        public static User ToEntity(UserDTO userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                Username = userDto.Username,
                Password = userDto.Password,
                Role = userDto.Role,
                CreatedDate = userDto.CreatedDate,
                LastLoginDate = userDto.LastLoginDate,
                IsActive = userDto.IsActive
            };
        }
    }
}
