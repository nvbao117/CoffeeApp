using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BLL.BusinessEntities;
using DAL;
namespace BLL.BusinessComponents
{
    public class BillService
    {
        private readonly DAL.AppContext _appContext;

        private readonly BillRepository _repository;
        public BillService()
        {
            _appContext = new DAL.AppContext();
            _repository = new BillRepository();
        }

        public int getTodayRevenue()
        {
            int todayRevenue = _repository.getTodayRevenue();
            return todayRevenue;
        }
        public int getMonthRevenue()
        {
            
            return _repository.getMonthRevenue();
        }

        public void createBill(int idTable, List<OrderItem> list)
        {
            if (list == null || list.Count == 0)
                return;
            _repository.InsertBill(new Bill
            {
                BillInfos = list.Select(item => new BillInfo
                {
                    IdFood = item.Food.Id,
                    Count = item.Quantity,
                }).ToList(),

                IdTable = idTable,
                DateCheckIn = DateTime.Now,
                Status = 0,
                Discount = 0,
                TotalPrice = list.Sum(item => item.Subtotal)
            });
        }
        public List<MonthlyRevenueDTO> GetMonthlyRevenueOfCurrentYear()
        {
            var months = Enumerable.Range(1, 12).Select(m => new MonthlyRevenueDTO { Month = m, Revenue = 0 }).ToList();

            var doanhThuTuDB = _appContext.Bills.Where(b => b.DateCheckOut.HasValue && b.DateCheckOut.Value.Year == DateTime.Now.Year)
                .GroupBy(b => b.DateCheckOut.Value.Month)
                .Select(g => new { Month = g.Key, Revenue = g.Sum(b => b.TotalPrice) })
                .ToList();

            var fullDoanhThu = months
                .GroupJoin(doanhThuTuDB,
                        m => m.Month,
                        d => d.Month,
                        (m, g) => new MonthlyRevenueDTO
                        {
                            Month = m.Month,
                            Revenue = (int)(g.FirstOrDefault()?.Revenue ?? 0)
                        })

                .OrderBy(x => x.Month)
                .ToList();

            return fullDoanhThu;
        }
        public List<WeeklyRevenueDTO> GetWeeklyRevenueOfCurrentYear()
        {
            var revenuePerWeek = _appContext.Bills
                .Where(b => b.DateCheckOut.HasValue &&
                            b.DateCheckOut.Value.Month == DateTime.Now.Month &&
                            b.DateCheckOut.Value.Year == DateTime.Now.Year)
                .AsEnumerable()
                .GroupBy(b =>
                {
                    var date = b.DateCheckOut.Value;
                    int week = ((date.Day - 1) / 7) + 1; // Week 1–5
                    return week;
                })
                .Select(g => new WeeklyRevenueDTO
                {
                    Week = g.Key,
                    Revenue = (int)g.Sum(b => b.TotalPrice ?? 0) // Ensure null safety for TotalPrice
                })
                .OrderBy(x => x.Week)
                .ToList();

            return revenuePerWeek;
        }
    }
}
