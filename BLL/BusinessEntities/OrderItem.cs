using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessEntities
{
    public class OrderItem
    {
        public FoodDTO Food { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
        public string Notes { get; set; }
    }
}
