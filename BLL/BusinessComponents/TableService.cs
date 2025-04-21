using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using BLL.BusinessEntities;
using DAL.Entities;
using DAL;
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

        public List<TableFoodDTO> GetAllTable()
        {
            var tables = _tableReposit.GetAllTable();
            List<TableFoodDTO> tableDTOs = new List<TableFoodDTO>();
            foreach (var table in tables)
            {
                tableDTOs.Add(new TableFoodDTO
                {
                    Id = table.Id,
                    Name = table.Name,
                    Status = table.Status
                });
            }
            return tableDTOs;
        }
        public void Add(TableFoodDTO table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (string.IsNullOrWhiteSpace(table.Name))
                throw new ArgumentException("Tên bàn không được để trống.");

            // Kiểm tra xem ID đã tồn tại chưa (nếu bạn nhập thủ công ID)
            var existing = _tableReposit.GetById(table.Id);
            if (existing != null)
                throw new InvalidOperationException($"Mã bàn {table.Id} đã tồn tại.");

            var tableEntity = new DAL.Entities.TableFood
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status ?? "Trống"
            };
            _tableReposit.Add(tableEntity);
        }
        public void Update(TableFoodDTO table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (string.IsNullOrWhiteSpace(table.Name))
                throw new ArgumentException("Tên bàn không được để trống.");

            var existing = _tableReposit.GetById(table.Id);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy bàn để cập nhật.");

            existing.Name = table.Name;
            existing.Status = table.Status ?? existing.Status;

            _tableReposit.Update(existing);
        }

        public void Delete(int id)
        {
            var existing = _tableReposit.GetById(id);
            if (existing == null)
                throw new InvalidOperationException("Không tìm thấy bàn để xóa.");

            _tableReposit.Delete(id);
        }   
        public TableFoodDTO GetById(int id)
        {
            var table = _tableReposit.GetById(id);
            if (table == null)
                return null;
            return new TableFoodDTO
            {
                Id = table.Id,
                Name = table.Name,
                Status = table.Status
            };
        }

        public List<TableFoodDTO> getTableBysStatus(string status)
        {
            var tables = _tableReposit.getTableBysStatus(status);
            List<TableFoodDTO> tableDTOs = new List<TableFoodDTO>();
            foreach (var table in tables)
            {
                tableDTOs.Add(new TableFoodDTO
                {
                    Id = table.Id,
                    Name = table.Name,
                    Status = table.Status
                });
            }
            return tableDTOs;
        }
        public List<TableFoodDTO> getTablesByName(string name)
        {
            var tables = _tableReposit.getTablesByName(name);
            List<TableFoodDTO> tableDTOs = new List<TableFoodDTO>();
            foreach (var table in tables)
            {
                tableDTOs.Add(new TableFoodDTO
                {
                    Id = table.Id,
                    Name = table.Name,
                    Status = table.Status
                });
            }
            return tableDTOs;
        }
    }
}
