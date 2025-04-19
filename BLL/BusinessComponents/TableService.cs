using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
namespace BLL.BusinessComponents
{
    public class TableService
    {
        private readonly TableFoodRepository _tableReposit;

        public TableService()
        {
            _tableReposit = new TableFoodRepository();
        }
        public int getCountTableAvailable()
        {
            return _tableReposit.getCountTableAvailable();
        }
    }
}
