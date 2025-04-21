using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FoodCategoryRepository
    {
        private readonly AppContext _context;
        public FoodCategoryRepository()
        {
            _context = new AppContext();
        }
        // Lấy tất cả danh mục
        public List<FoodCategory> GetAll()
        {
            return _context.FoodCategories.ToList();
        }

        public FoodCategory GetById(int id)
        {
            return _context.FoodCategories.FirstOrDefault(fc => fc.Id == id);
        }

        // Thêm mới
        public void Add(FoodCategory category)
        {
            _context.FoodCategories.Add(category);
            _context.SaveChanges();
        }

        // Cập nhật
        public void Update(FoodCategory category)
        {
            var existing = _context.FoodCategories.FirstOrDefault(fc => fc.Id == category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                // Thêm các thuộc tính khác nếu có
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var category = _context.FoodCategories.FirstOrDefault(fc => fc.Id == id);
            if (category != null)
            {
                _context.FoodCategories.Remove(category);
                _context.SaveChanges();
            }
        }

        // Tìm theo tên (gợi ý thêm)
        public List<FoodCategory> SearchByName(string keyword)
        {
            return _context.FoodCategories
                .Where(fc => fc.Name.Contains(keyword))
                .ToList();
        }
        public List<FoodCategory> GetFoodCategoriesByName(string name)
        {
            return _context.FoodCategories
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .ToList();
        }
    }
}
