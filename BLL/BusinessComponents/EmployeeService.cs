using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.BusinessEntities;
using BLL.Mappers;
using DAL.Repositories;
using static System.Net.Mime.MediaTypeNames;
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

        public List<EmployeeDTO> getAll()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            var employees = _repository.GetAll();
            foreach (var employee in employees)
            {
                EmployeeDTO emp = new EmployeeDTO
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    HireDate = employee.HireDate,
                    TerminationDate = employee.TerminationDate,
                    Address = employee.Address,
                    Notes = employee.Notes,
                    UserId = employee.UserId,
                    LinkImage = employee.LinkImage 
                };
                list.Add(emp);
            }
            return list;
        }
        public void Add(EmployeeDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            var existing = _repository.GetById(employee.EmployeeId);
            if (existing != null)
                throw new InvalidOperationException($"Mã nhân viên {employee.EmployeeId} đã tồn tại.");

            if (string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName) ||
                string.IsNullOrWhiteSpace(employee.Email))
            {
                throw new ArgumentException("Thông tin bắt buộc không được để trống.");
            }

            var newEmployee = EmployeeMapper.ToEntity(employee);

            _repository.Add(newEmployee);
        }
        public void Update(EmployeeDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName) ||
                string.IsNullOrWhiteSpace(employee.Email))
            {
                throw new ArgumentException("Thông tin nhân viên không được để trống.");
            }

            var existingEmployee = _repository.GetById(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName.Trim();
                existingEmployee.LastName = employee.LastName.Trim();
                existingEmployee.Email = employee.Email.Trim();
                existingEmployee.Phone = employee.Phone?.Trim();
                existingEmployee.HireDate = employee.HireDate;
                existingEmployee.TerminationDate = employee.TerminationDate;
                existingEmployee.Address = employee.Address?.Trim();
                existingEmployee.Notes = employee.Notes?.Trim();
                existingEmployee.UserId = employee.UserId;

                string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "avatar");
                if (!Directory.Exists(imageFolder))
                    Directory.CreateDirectory(imageFolder);

                if (!string.IsNullOrEmpty(employee.LinkImage) && File.Exists(employee.LinkImage))
                {
                    string fileName = $"emp_{employee.EmployeeId}{Path.GetExtension(employee.LinkImage)}";
                    string relativePath = Path.Combine("Resources", "avatar", fileName);
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                    File.Copy(employee.LinkImage, fullPath, true);

                    // Lưu đường dẫn tương đối vào DB
                    existingEmployee.LinkImage = relativePath;
                }
                else
                {
                    // Nếu không có ảnh được chọn, dùng ảnh mặc định emp_0.png
                    string defaultFileName = "emp_0.png";
                    string defaultRelativePath = Path.Combine("Resources", "avatar", defaultFileName);
                    existingEmployee.LinkImage = defaultRelativePath;
                }
                _repository.Update(existingEmployee);
            }
            else
            {
                throw new InvalidOperationException("Không tìm thấy nhân viên để cập nhật.");
            }
        }


        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
