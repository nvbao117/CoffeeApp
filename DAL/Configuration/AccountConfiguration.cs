using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class AccountConfiguration : EntityTypeConfiguration<Account> 
    {
        public AccountConfiguration()
        {
            ToTable("Account");
            HasKey(a => a.Username);
            Property(a => a.Username).HasMaxLength(100).IsRequired(); 
            Property(a => a.DisplayName).HasMaxLength(100).IsRequired();
            Property(a => a.Password).HasMaxLength(1000).IsRequired();
            Property(a => a.Avatar).HasMaxLength(255);
            Property(a => a.Type).IsRequired();
        }
    }
}
