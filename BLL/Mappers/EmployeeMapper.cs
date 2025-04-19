using BLL.BusinessEntities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeDTO ToDTO(Employee emp)
        {
            return new EmployeeDTO
            {
                EmployeeId = emp.EmployeeId,
                UserId = emp.UserId,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Phone = emp.Phone,
                HireDate = emp.HireDate,
                TerminationDate = emp.TerminationDate,
                Address = emp.Address,
                Notes = emp.Notes,
                LinkImage = emp.LinkImage
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
