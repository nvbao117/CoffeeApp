using BLL.BusinessEntities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class FoodMapper
    {

        public static FoodDTO ToDTO(Food food)
        {
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

        public static Food ToEntity(FoodDTO dto)
        {
            if (dto == null) return null;

            return new Food
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                idCategory = dto.FoodCategoryId,
                Image = dto.Image
            };
        }
    }
}
