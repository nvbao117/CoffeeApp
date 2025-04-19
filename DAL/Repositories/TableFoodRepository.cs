using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TableFoodRepository
    {
        private readonly AppContext _appContext;
        public TableFoodRepository()
        {
            _appContext = new AppContext();
        }

        public int getCountTableAvailable()
        {
            int count = _appContext.Database.SqlQuery<int>("SELECT dbo.func_getCountTableAvailable()").FirstOrDefault();
            return count;
        }
    }
}
