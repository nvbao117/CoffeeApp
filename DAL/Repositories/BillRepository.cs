using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BillRepository
    {
        private readonly AppContext _context;
        public BillRepository()
        {
            _context = new AppContext();
        }

        public int getTodayRevenue()
        {
            return _context.Database.SqlQuery<int?>("SELECT dbo.func_TodayRevenue()").FirstOrDefault() ?? 0;
        }
        public int getMonthRevenue()
        {
            int totalRevenue = _context.Database.SqlQuery<int?>("EXEC USP_getRevenueThisMonth")
                                     .FirstOrDefault() ?? 0;
            return totalRevenue;
        }

    }
}
