using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ActivityRepository
    {
        private readonly AppContext _context;

        public ActivityRepository( )
        {
            _context = new AppContext();
        }

        public void Add(RecentActivity activity)
        {
            _context.RecentActivities.Add(activity);
            _context.SaveChanges();
        }

        public List<RecentActivity> GetRecent(int count = 20)
        {
            return _context.RecentActivities
                .OrderByDescending(a => a.Timestamp)
                .Take(count)
                .ToList();
        }
    }
}
