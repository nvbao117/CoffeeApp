using BLL.BusinessComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL.BusinessEntities;
namespace CoffeeApp
{
    public partial class Employee_Management_form : UserControl
    {
        private readonly EmployeeService _employeeService;
        private string selectedImagePath = string.Empty;
        private bool isAdding = false;
        private bool isEditing = false;
        public Employee_Management_form()
        {
            _employeeService = new EmployeeService();
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            customizeDGV();
            LoadEmployees();
            BindAccountFields();
        }
        public void LoadEmployees()
        {
            dgvData.DataSource = _employeeService.getAll(); 

        }
        private void ClearForm()
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtNote.Text = "";
            txtHireDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            selectedImagePath = string.Empty;
            picAvatar.Image = null;
        }
        public void customizeDGV()
        {
            dgvData.Font = new Font("Segoe UI", 10);
            dgvData.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvData.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Italic);

            // Màu nền và lưới
            dgvData.BackgroundColor = Color.White;
            dgvData.GridColor = Color.LightGray;
            dgvData.BorderStyle = BorderStyle.None;

            // Header màu đẹp
            dgvData.EnableHeadersVisualStyles = false;
            dgvData .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 136, 229);
            dgvData .ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvData.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

            // Cell style
            dgvData.DefaultCellStyle.BackColor = Color.White;
            dgvData.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            dgvData.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvData.DefaultCellStyle.Padding = new Padding(3);

            // Row height + autosize
            dgvData.RowTemplate.Height = 30;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToResizeRows = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                if (!DateTime.TryParse(txtHireDate.Text, out DateTime hireDate))
                {
                    MessageBox.Show("Ngày tuyển không hợp lệ.");
                    return;
                }

                var employee = new EmployeeDTO
                {
                    EmployeeId = int.TryParse(txtID.Text, out int id) ? id : 0, // nếu có nhập ID
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    HireDate = hireDate,
                    Address = txtAddress.Text.Trim(),
                    Notes = txtNote.Text.Trim(),
                    LinkImage = selectedImagePath
                };

                try
                {
                    _employeeService.Add(employee);
                    MessageBox.Show("Đã thêm nhân viên thành công!");
                    LoadEmployees();
                    ClearForm();
                    isAdding = false;
                    btnAdd.Text = "Thêm";
                    BindAccountFields();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Lỗi trùng mã nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Lỗi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ClearForm();
                isAdding = true;
                isEditing = false;
                btnAdd.Text = "Xác nhận";
                btnEdit.Text = "Sửa";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (!int.TryParse(txtID.Text, out int id))
                {
                    MessageBox.Show("ID không hợp lệ.");
                    return;
                }

                if (!DateTime.TryParse(txtHireDate.Text, out DateTime hireDate))
                {
                    MessageBox.Show("Ngày tuyển không hợp lệ.");
                    return;
                }

                var employee = new EmployeeDTO
                {
                    EmployeeId = id,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    HireDate = hireDate,
                    Address = txtAddress.Text.Trim(),
                    Notes = txtNote.Text.Trim(),
                    LinkImage = selectedImagePath
                };

                _employeeService.Update(employee);
                MessageBox.Show("Đã cập nhật thông tin nhân viên!");
                LoadEmployees();
                ClearForm();
                isEditing = false;
                btnEdit.Text = "Sửa";
                BindAccountFields();
            }
            else
            {
                isEditing = true;
                isAdding = false;
                btnEdit.Text = "Xác nhận";
                btnAdd.Text = "Thêm";
            }

        }
        private void BindAccountFields()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dgvData.DataSource, "EmployeeId");

            txtFirstName.DataBindings.Clear();
            txtFirstName.DataBindings.Add("Text", dgvData.DataSource, "FirstName");

            txtLastName.DataBindings.Clear();
            txtLastName.DataBindings.Add("Text", dgvData.DataSource, "LastName");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dgvData.DataSource, "Email");

            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add("Text", dgvData.DataSource, "Phone");

            txtHireDate.DataBindings.Clear();
            txtHireDate.DataBindings.Add("Text", dgvData.DataSource, "HireDate");

            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add("Text", dgvData.DataSource, "Address");

            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add("Text", dgvData.DataSource, "Notes");

            txtLinkImage.DataBindings.Clear();
            txtLinkImage.DataBindings.Add("Text", dgvData.DataSource, "LinkImage");

            picAvatar.DataBindings.Clear();
            picAvatar.DataBindings.Add("ImageLocation", dgvData.DataSource, "LinkImage");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _employeeService.Delete(id);
                MessageBox.Show("Đã xóa nhân viên.");
                LoadEmployees();
                ClearForm();
                BindAccountFields();
            }
        }

        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                picAvatar.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}
