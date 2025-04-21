using BLL.BusinessEntities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class CategoryMapper
    {
        public static FoodCategoryDTO ToDTO(FoodCategory food)
        {
            return new FoodCategoryDTO
            {
                Id = food.Id,
                Name = food.Name
            };
        }

        public static FoodCategory ToEntity(FoodCategoryDTO dto)
        {
            return new FoodCategory
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
