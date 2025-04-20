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
            return new FoodDTO
            {
                Id = food.Id,
                Name = food.Name,
                Price = food.Price,
                FoodCategoryId  = food.idCategory
            };
        }

        public static Employee ToEntity(EmployeeDTO dto)
        {
            return new Employee
            {
                EmployeeId = dto.EmployeeId,
                UserId = dto.UserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                HireDate = dto.HireDate,
                TerminationDate = dto.TerminationDate,
                Address = dto.Address,
                Notes = dto.Notes,
                LinkImage = dto.LinkImage
            };
        }
    }
}
