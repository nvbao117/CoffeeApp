using BLL.BusinessEntities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
namespace BLL.BusinessComponents
{
    public class FoodService
    {
        private readonly DAL.AppContext _context;

        public FoodService()
        {
            _context = new DAL.AppContext();  
        }

        public List<FoodDTO> Foods()
        {
            List<FoodDTO> foods = new List<FoodDTO>();
            foods = _context.Foods.Select(f => new FoodDTO
            {
                Id = f.Id,
                Name = f.Name,
                Price = f.Price,
                FoodCategoryId = f.idCategory,
                Image = f.Image,
            }).AsNoTracking().ToList();  
            return foods;
        }
       
    }
}
