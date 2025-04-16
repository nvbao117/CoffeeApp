using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        // Khóa ngoại đến FoodCategory
        public int FoodCategoryId { get; set; }

        // Navigation property đến FoodCategory
        public virtual FoodCategory FoodCategory { get; set; }

        public virtual ICollection<BillInfo> BillInfos { get; set; }

        public Food()
        {
            BillInfos = new HashSet<BillInfo>();
        }
    }
}
