using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BillInfo
    {
        public int Id { get; set; }
        public int IdBill {get; set; }
        public int IdFood { get; set; }
        public int Count {get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Food Food { get; set; }
    }
}
