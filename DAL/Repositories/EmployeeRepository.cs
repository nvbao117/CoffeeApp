using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppContext _context;
        public EmployeeRepository()
        {
            _context = new AppContext();
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }
        public Employee GetByUserId(int userId)
        {
            return _context.Employees.FirstOrDefault(e => e.UserId == userId);
        }
        public void Update(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Email = employee.Email;
                existingEmployee.Phone = employee.Phone;
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.TerminationDate = employee.TerminationDate;
                existingEmployee.Address = employee.Address;
                existingEmployee.Notes = employee.Notes;
                existingEmployee.UserId = employee.UserId;
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;

                _context.SaveChanges();
            }
        }
        public string getLinkImage(int userid)
        {
            var param = new SqlParameter("@p1", userid);
            string link = _context.Database.SqlQuery<string>("EXEC dbo.USP_getAvatar @p1", param).FirstOrDefault()?.ToString();
            return link;
        }

        public int getCountEmployee()
        {
            int count = _context.Database.SqlQuery<int>("SELECT dbo.func_countTotalEmployee()").FirstOrDefault();
            return count;
        }
    }
}
