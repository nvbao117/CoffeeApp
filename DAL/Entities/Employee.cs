using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public int UserId { get; set; } // Foreign Key

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

        public string LinkImage { get; set; }
        public virtual User User { get; set; }
        
    }
}
