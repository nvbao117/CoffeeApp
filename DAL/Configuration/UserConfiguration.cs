using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities; 
using System.Data.Entity.ModelConfiguration;
namespace DAL.Configuration
{
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(u => u.UserId);
            Property(u => u.Username).HasMaxLength(50).IsRequired();
            Property(u => u.Password).HasMaxLength(100).IsRequired();
            Property(u => u.Role).IsRequired();
            Property(u => u.IsActive).IsRequired();
            Property(u => u.CreatedDate).IsRequired();
            Property(u => u.LastLoginDate).IsOptional();
        }
    }
}
