    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TableFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        // Mối quan hệ với Bill
        public virtual ICollection<Bill> Bills { get; set; }

        public TableFood()
        {
            Bills = new HashSet<Bill>();
        }
    }
}
