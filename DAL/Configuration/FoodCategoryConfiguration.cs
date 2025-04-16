using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class FoodCategoryConfiguration :EntityTypeConfiguration<FoodCategory>
    {
        public FoodCategoryConfiguration()
        {
            ToTable("FoodCategory");
            HasKey(fc => fc.Id);
            Property(fc => fc.Name).HasMaxLength(100).IsRequired();
        }
    }
}
