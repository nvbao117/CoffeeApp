using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessEntities
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }

    }
}
