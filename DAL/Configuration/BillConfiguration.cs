using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class BillConfiguration: EntityTypeConfiguration<Bill>
    {
        public BillConfiguration() 
        {
            ToTable("Bill");
            HasKey(b => b.Id);

            Property(b => b.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(b => b.DateCheckIn).IsRequired();
            Property(b => b.DateCheckOut).IsOptional();
            Property(b => b.Status).IsRequired();
            Property(b => b.Discount).IsRequired();
            Property(b => b.TotalPrice).IsOptional();

            // Khai báo mối quan hệ giữa Bill và TableFood
            HasRequired(b => b.TableFood)  
                .WithMany(t => t.Bills)
                .HasForeignKey(b => b.IdTable);
        }
    }
}
