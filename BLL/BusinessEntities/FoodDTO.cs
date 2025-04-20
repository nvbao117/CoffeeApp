using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessEntities
{
    public class FoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int FoodCategoryId { get; set; }
        public string Image { get; set; }
    }
}
