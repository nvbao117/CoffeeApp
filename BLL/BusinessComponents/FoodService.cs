using BLL.BusinessEntities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using BLL.Mappers;
using DAL.Entities;
using System.Runtime.Remoting.Contexts;
namespace BLL.BusinessComponents
{
    public class FoodService
    {
        private readonly FoodRepository _foodRepository; 
        public FoodService()
        {
            _foodRepository = new FoodRepository();
        }

        public List<FoodDTO> Foods()
        {
            var Allfood = _foodRepository.foods();
            List<FoodDTO> foods = new List<FoodDTO>();

            foreach (Food food in Allfood)
            {
                foods.Add(new FoodDTO
                {
                    Id = food.Id,
                    Name = food.Name,
                    Price = food.Price,
                    FoodCategoryId = food.idCategory,
                    Image = food.Image
                });
            }

            return foods;
        }
        public FoodDTO GetFoodById(int id)
        {
            var food = _foodRepository.getById(id);
            if (food == null) return null;
            return new FoodDTO
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price,
                FoodCategoryId = food.idCategory,
                Image = food.Image
            };
        }

        public void AddFood(FoodDTO food)
        {
            _foodRepository.Add(FoodMapper.ToEntity(food));
        }
        public void Update(FoodDTO food)
        {
            var existingFood = _foodRepository.getById(food.Id);
            if (existingFood == null) return;
            existingFood.Name = food.Name;
            existingFood.Price = food.Price;
            existingFood.Image = food.Image;
            existingFood.idCategory = food.FoodCategoryId;
            _foodRepository.Update(existingFood);
        }
        public void Delete(int id)
        {
            var food = _foodRepository.getById(id);
            if (food == null) return;
            _foodRepository.Delete(id);

        }
        public List<FoodDTO> GetListFoodByName(string name)
        {
            var foods = _foodRepository.GetListFoodByName(name);
            List<FoodDTO> foodList = new List<FoodDTO>();
            foreach (var food in foods)
            {
                foodList.Add(new FoodDTO
                {
                    Id = food.Id,
                    Name = food.Name,
                    Price = food.Price,
                    Image = food.Image,
                    FoodCategoryId = food.idCategory
                });
            }
            return foodList;
        }

    }
}
