using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class PasswordResetTokenConfiguration:EntityTypeConfiguration<PasswordResetToken>
    {
        public PasswordResetTokenConfiguration()
        {
            ToTable("PasswordResetToken");

            HasKey(t => t.UserId); 

            Property(t => t.Token).IsRequired().HasMaxLength(10);

            Property(t => t.Expr).IsRequired();

            Property(t => t.CreateAt).IsRequired();

            Property(t => t.IsUsed).IsRequired();

            HasRequired(t => t.User)
                .WithOptional(u => u.PasswordResetToken)
                .WillCascadeOnDelete(true); // Xóa User thì xóa luôn Token



        }

    }
}
