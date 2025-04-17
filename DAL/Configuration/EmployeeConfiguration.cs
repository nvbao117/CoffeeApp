using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;
namespace DAL.Configuration
{
    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employee");
            HasKey(e => e.EmployeeId);
            Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            Property(e => e.LastName).HasMaxLength(50).IsRequired();
            Property(e => e.Email).HasMaxLength(100).IsRequired();
            Property(e => e.Phone).HasMaxLength(15).IsOptional();
            Property(e => e.HireDate).IsRequired();
            Property(e => e.TerminationDate).IsOptional();
            Property(e => e.Address).HasMaxLength(200).IsOptional();
            Property(e => e.Notes).HasMaxLength(500).IsOptional();
            // Khai báo mối quan hệ giữa Employee và User

            // Thiết lập quan hệ 1-1 với User
            HasRequired(e => e.User)
                .WithOptional(u => u.Employee)
                .WillCascadeOnDelete(false); 
        }
    }
}
