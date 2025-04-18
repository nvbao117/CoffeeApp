using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; } 
        public string Password { get; set; }
        public int Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PasswordResetToken PasswordResetToken { get; set; }
    }
}
