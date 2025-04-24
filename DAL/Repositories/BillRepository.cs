using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
        // Lấy số lượng bill chưa thanh toán từ idTable truyền vào
        public int GetUncheckBillIdByTableId(int id)
        {
            var bill = _context.Bills
                .Where(a => a.IdTable == id && a.Status == 0)
                .Select(a => a.Id);
            if (bill.Count() > 0)
            {
                return bill.FirstOrDefault();
            }
            return -1; 
        }
        
        public  void InsertBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }
        public void DeleteBill(int id)
        {
            var bill = _context.Bills.Include(b => b.BillInfos)
                .FirstOrDefault(b => b.Id == id);

            if (bill != null)
            {
                _context.BillInfos.RemoveRange(bill.BillInfos);

                _context.Bills.Remove(bill);
                _context.SaveChanges();
            }
        }
        public void CheckOut(int id , int discount , int totalPrice)
        {
            var bill = _context.Bills.Find(id);
            if (bill != null)
            {
                bill.DateCheckOut = DateTime.Now; 
                bill.Discount = discount;
                bill.TotalPrice = totalPrice;
                bill.Status = 1; 
            }
            _context.SaveChanges();
        }
    }
}
