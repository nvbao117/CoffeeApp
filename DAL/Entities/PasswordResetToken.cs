using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PasswordResetToken
    {
        public int UserId { get; set; }

        public string Token { get; set; }
        public DateTime Expr { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsUsed { get; set; }

        public virtual User User { get; set; }
    }
}
