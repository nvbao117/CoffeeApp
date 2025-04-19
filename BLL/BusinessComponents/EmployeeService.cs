using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
namespace BLL.BusinessComponents
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;
        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public string getLinkImage(int userid)
        {
            string link = _repository.getLinkImage(userid);
            return link;
        }
        public int getCountEmployee()
        {
            return _repository.getCountEmployee();
        }
    }
}
