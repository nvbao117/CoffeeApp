using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class ActivitiesConfiguration: EntityTypeConfiguration<RecentActivity>
    {
        public ActivitiesConfiguration()
        {
            ToTable("RecentActivities");
            HasKey(a => a.Id);
            Property(a => a.Action).IsRequired().HasMaxLength(50);
            Property(a => a.Target).IsRequired().HasMaxLength(100);
            Property(a => a.Description).IsRequired().HasMaxLength(255);
            Property(a => a.UserName).HasMaxLength(100);
            Property(a => a.Timestamp).IsRequired();
        }

    }
}
