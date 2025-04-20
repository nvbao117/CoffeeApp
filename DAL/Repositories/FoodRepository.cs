using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FoodRepository
    {
        private readonly AppContext _context;
        public FoodRepository()
        {
            _context = new AppContext();
        }

        public Food getById(int id)
        {
            var f = _context.Foods.FirstOrDefault(x =>x.Id == id);
            if (f == null) return null;
            return new Food
            {
                Id = id,
                Name = f.Name,
                Price = f.Price,
                Image = f.Image,
                idCategory = f.idCategory
            };
        }
        public void Add(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges(); 
        }

        public void Update(Food dto)
        {
            var food = _context.Foods.FirstOrDefault(x => x.Id == dto.Id);
            if (food == null) return;

            food.Name = dto.Name;
            food.Price = dto.Price;
            food.Image = dto.Image;
            food.idCategory = dto.idCategory;

            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var food = _context.Foods.FirstOrDefault(x => x.Id == id);
            if (food == null) return;

            _context.Foods.Remove(food);
            _context.SaveChanges();
        }
    }

}
