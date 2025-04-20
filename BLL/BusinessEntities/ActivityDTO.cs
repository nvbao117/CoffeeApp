using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessEntities
{
    public class ActivityDTO
    {
        public string Action { get; set; }
        public string Target { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
