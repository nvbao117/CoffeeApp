using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }
        public double? TotalPrice { get; set; }

        // Khóa ngoại cho mối quan hệ với TableFood
        public int IdTable { get; set; }  // Khóa ngoại
        public virtual TableFood TableFood { get; set; }  // Thuộc tính dẫn hướng

        public virtual ICollection<BillInfo> BillInfos { get; set; }

        public Bill()
        {
            BillInfos = new HashSet<BillInfo>();
        }   


    }
}
