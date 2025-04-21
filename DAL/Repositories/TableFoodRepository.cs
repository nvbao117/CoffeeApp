using DAL.Entities;
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
        public List<TableFood> GetAllTable()
        {
            return _appContext.TableFoods.ToList();
        }
        public void Add(TableFood table)
        {
            _appContext.TableFoods.Add(table);
            _appContext.SaveChanges();
        }
        public void Update(TableFood table)
        {
            var existingTable = _appContext.TableFoods.Find(table.Id);
            if (existingTable != null)
            {
                existingTable.Name = table.Name;
                existingTable.Status = table.Status;
                _appContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var table = _appContext.TableFoods.Find(id);
            if (table != null)
            {
                _appContext.TableFoods.Remove(table);
                _appContext.SaveChanges();
            }
        }
        public TableFood GetById(int id)
        {
            return _appContext.TableFoods.Find(id);
        }
        

        public List<TableFood> getTableBysStatus(string status)
        {
            return _appContext.TableFoods.Where(t => t.Status == status).ToList();  
        }
        public List<TableFood> getTablesByName(string name)
        {
            name = name.ToLower();
            return _appContext.TableFoods.Where(t => t.Name.ToLower().Contains(name)).ToList();
        }
    }
}
