using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using DAL.Entities;
namespace DAL.Configuration
{
    public class TableFoodConfiguration: EntityTypeConfiguration<TableFood>
    {

        public TableFoodConfiguration()
        {
            ToTable("TableFood");
            HasKey(tf => tf.Id);
            Property(tf => tf.Name).HasMaxLength(100).IsRequired();
            Property(tf => tf.Status).IsRequired();
        }
    }
}
