using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BillInforRepository
    {
        private readonly AppContext _context;
        public BillInforRepository()
        {
            _context = new AppContext();
        }
        public void InsertBillInfor(BillInfo billinfo)
        {
            _context.BillInfos.Add(billinfo);
            _context.SaveChanges();
        }
        public int DeleteBillInfor(int id)
        {
            var item = _context.BillInfos
                .Where(b => b.IdBill == id)
                .ToList();

            if (item == null) return 0;
            _context.BillInfos.RemoveRange(item);
            
            return _context.SaveChanges();
        }


        public List<BillInfo> GetBillInfos(int idBill)
        {
            var billInfos = _context.BillInfos
                .Where(b => b.IdBill == idBill) 
                .ToList();
            return billInfos;
        }
        public int getCountFoodInBIll(int idbill , int idfood)
        {
            int count = _context.BillInfos
                .Where(a => a.IdBill == idbill && a.IdFood == idfood)
                .Select(a => a.Count)
                .FirstOrDefault();

            return count;
        }

        // Cập nhật số lượng món ăn trong bill 
        public bool UpdateFoodCountInBill(int idBill , int idFood,int count)
        {
            var billInfo = _context.BillInfos
                .Where(a => a.IdBill == idBill && a.IdFood == idFood)
                .FirstOrDefault();
            if (billInfo != null)
            {
                billInfo.Count = count;
                _context.SaveChanges();
                return true;
            }
            else return false; 
        }
    }
}
