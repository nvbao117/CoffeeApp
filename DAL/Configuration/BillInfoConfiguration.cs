using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class BillInfoConfiguration: EntityTypeConfiguration<BillInfo>
    {
        public BillInfoConfiguration()
        {
            ToTable("BillInfo");
            HasKey(bi => bi.Id);

            Property(bi => bi.IdBill).IsRequired();
            Property(bi => bi.IdFood).IsRequired();
            Property(bi => bi.Count).IsRequired();

            // Mối quan hệ với Bill
            HasRequired(bi => bi.Bill)
                .WithMany(b => b.BillInfos)
                .HasForeignKey(bi => bi.IdBill);

            // Mối quan hệ với Food
            HasRequired(bi => bi.Food)
                .WithMany(f => f.BillInfos)
                .HasForeignKey(bi => bi.IdFood);
        }

    }
}
