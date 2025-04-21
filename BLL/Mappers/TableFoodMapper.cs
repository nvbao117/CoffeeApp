using BLL.BusinessEntities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class TableFoodMapper
    {
        public static TableFoodDTO ToDTO(TableFood table)
        {
            if (table == null) return null;

            return new TableFoodDTO
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status
            };
        }

        public static TableFood ToEntity(TableFoodDTO table)
        {
            if (table == null) return null;

            return new TableFood
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status
            };
        }
    }
}
