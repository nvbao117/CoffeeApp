using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RecentActivity
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserName { get; set; }
    }
}
