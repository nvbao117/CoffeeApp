using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Configuration
{
    public class FoodConfiguration : EntityTypeConfiguration<Food> 
    {
        public FoodConfiguration()
        {
            ToTable("Food");
            HasKey(f => f.Id); 
            Property(f => f.Name).HasMaxLength(100).IsRequired();
            Property(f => f.Price).IsRequired();
            HasRequired(f => f.FoodCategory)
                .WithMany(fc => fc.Foods)
                .HasForeignKey(f => f.FoodCategoryId);
            
        }
    }
}
