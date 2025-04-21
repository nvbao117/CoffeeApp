using BLL.BusinessComponents;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Account_form : UserControl
    {
        private readonly UserService _userService;
        private enum EditMode { None, Add, Edit }
        private EditMode currentMode = EditMode.None;

        public Account_form()
        {
            InitializeComponent();
            _userService = new UserService();
            dgvInfo.AutoGenerateColumns = false;

            loadCombobox();
            LoadListAccount();
            customizeDGV();
            AddAccountBinding();
        }
        public void loadCombobox()
        {
            var Role = new List<object>
            {
                new { Id = 1, Name = "Admin" },
                new { Id = 2, Name = "User" }
            };

            cboRole.DataSource = Role.ToList();
            cboRole.ValueMember = "Id";
            cboRole.DisplayMember = "Name";

            cboFRole.DataSource = Role.ToList(); 
            cboFRole.ValueMember = "Id";
            cboFRole.DisplayMember = "Name";

            colRole.DataSource = Role.ToList();
            colRole.ValueMember = "Id";
            colRole.DisplayMember = "Name";

            var Status = new List<object>
            {
                new { Id = true, Name = "Hoạt động" },
                new { Id = false, Name = "Không hoạt động" }
            };

            colStatus.DataSource = Status;
            colStatus.DisplayMember = "Name";
            colStatus.ValueMember = "Id";

            cboStatus.DataSource = Status;
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Id";
            
        }
        void LoadListAccount()
        {
            List<UserDTO> userDTOs = _userService.getAllUser();
            dgvInfo.DataSource = userDTOs;
        }
        void AddAccountBinding()
        {
            txtUsername.DataBindings.Clear();
            txtUsername.DataBindings.Add(new Binding("Text", dgvInfo.DataSource,"Username", true, DataSourceUpdateMode.Never));

            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add(new Binding("Text", dgvInfo.DataSource, "Password", true, DataSourceUpdateMode.Never));
            cboRole.DataBindings.Clear();
            cboRole.DataBindings.Add(new Binding("SelectedValue", dgvInfo.DataSource, "Role", true, DataSourceUpdateMode.Never));

            cboStatus.DataBindings.Clear();
            cboStatus.DataBindings.Add(new Binding("SelectedValue", dgvInfo.DataSource, "IsActive", true, DataSourceUpdateMode.Never));
            txtCreatedDate.DataBindings.Clear();
            txtCreatedDate.DataBindings.Add(new Binding("Text",dgvInfo.DataSource,"CreatedDate",true, DataSourceUpdateMode.Never));
            txtLastLoginDate.DataBindings.Clear();
            txtLastLoginDate.DataBindings.Add(new Binding("Text", dgvInfo.DataSource, "LastLoginDate", true, DataSourceUpdateMode.Never));
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add(new Binding("Text", dgvInfo.DataSource, "UserId", true, DataSourceUpdateMode.Never));
        }
        public void customizeDGV()
        {
            dgvInfo.Font = new Font("Segoe UI", 10);
            dgvInfo.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvInfo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvInfo.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Italic);

            // Màu nền và lưới
            dgvInfo.BackgroundColor = Color.White;
            dgvInfo.GridColor = Color.LightGray;
            dgvInfo.BorderStyle = BorderStyle.None;

            // Header màu đẹp
            dgvInfo.EnableHeadersVisualStyles = false;
            dgvInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 136, 229);
            dgvInfo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInfo.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

            // Cell style
            dgvInfo.DefaultCellStyle.BackColor = Color.White;
            dgvInfo.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgvInfo.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201); 
            dgvInfo.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvInfo.DefaultCellStyle.Padding = new Padding(3);

            // Row height + autosize
            dgvInfo.RowTemplate.Height = 30;
            dgvInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInfo.AllowUserToAddRows = false;
            dgvInfo.AllowUserToResizeRows = false;
        }


        private void SetFormMode(EditMode mode)
        {
            currentMode = mode;

            bool isEditing = (mode != EditMode.None);
            txtId.Enabled = (mode == EditMode.Add);
            btnADD.Enabled = (mode == EditMode.None);
            btnUpdate.Enabled = (mode == EditMode.None);
            btnDelete.Enabled = (mode == EditMode.None);

            btnRefresh.Enabled = !isEditing;

            if (mode == EditMode.Edit)
            {
                btnUpdate.Text = "Xác nhận";
            }
            else
            {
                btnUpdate.Text = "Sửa";
            }

            if (mode == EditMode.Add)
            {
                btnADD.Text = "Xác nhận";
            }
            else
            {
                btnADD.Text = "Thêm";
            }
        }
        private void btnADD_Click(object sender, EventArgs e)
        {
            if (currentMode != EditMode.Add)
            {
                ClearInput();
                SetFormMode(EditMode.Add);
                SetButtonStates(false);
                btnADD.Enabled = true;
                return;
            }
            try
            {
                if (!ValidateUserInput(out string msg))
                {
                    MessageBox.Show(msg);
                    return;
                }
                if (!int.TryParse(txtId.Text, out int userId))
                {
                    MessageBox.Show("ID người dùng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var userDto = new UserDTO
                {
                    UserId = userId,
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = (int)cboRole.SelectedValue,
                    IsActive = (bool)cboStatus.SelectedValue,
                    CreatedDate = DateTime.Now,
                    LastLoginDate = DateTime.Now
                };

                _userService.AddUser(userDto);
                MessageBox.Show("Người dùng đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetButtonStates(true); 
                SetFormMode(EditMode.None);
                LoadListAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentMode != EditMode.Edit)
            {
                SetFormMode(EditMode.Edit);
                SetButtonStates(false);
                btnUpdate.Enabled = true;
                return;
            }
            if (!ValidateUserInput(out string msg))
            {
                MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                if (!DateTime.TryParse(txtCreatedDate.Text, out DateTime ngayTao))
                {
                    MessageBox.Show("Ngày tạo không hợp lệ!");
                    return;
                }

                var userDto = new UserDTO
                {
                    UserId = id,
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = (int)cboRole.SelectedValue,
                    IsActive = (bool)cboStatus.SelectedValue,
                    CreatedDate = ngayTao,
                    LastLoginDate = DateTime.Now

                };

                _userService.UpdateUser(userDto);
                MessageBox.Show("Cập nhật thành công!");
                SetButtonStates(true); 
                SetFormMode(EditMode.None);
                LoadListAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int userId))
            {
                MessageBox.Show("Vui lòng chọn người dùng hợp lệ để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng ID = {userId} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _userService.DeleteUser(userId);
                MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput(); // Xóa dữ liệu khỏi form
                LoadListAccount(); // Reload danh sách
                SetButtonStates(true); // Bật lại tất cả
                SetFormMode(EditMode.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadListAccount();
            MessageBox.Show("Đã load lại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ClearInput()
        {
            txtId.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtCreatedDate.Text = "";
            txtLastLoginDate.Text = "";
            cboRole.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
        }
        private void SetButtonStates(bool isEnabled)
        {
            btnADD.Enabled = isEnabled;
            btnUpdate.Enabled = isEnabled;
            btnDelete.Enabled = isEnabled;
            btnRefresh.Enabled = isEnabled;
        }
        private bool ValidateUserInput(out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                message = "Vui lòng nhập Id";
                return false; 
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                message = "Vui lòng nhập tên đăng nhập.";
                return false;
            }

            if (txtUsername.Text.Length < 4)
            {
                message = "Tên đăng nhập phải có ít nhất 4 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                message = "Vui lòng nhập mật khẩu.";
                return false;
            }

            if (cboRole.SelectedItem == null)
            {
                message = "Vui lòng chọn vai trò.";
                return false;
            }

            if (cboStatus.SelectedItem == null)
            {
                message = "Vui lòng chọn trạng thái.";
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetFormMode(EditMode.None);
            SetButtonStates(true);
            ClearInput();
            MessageBox.Show("Đã hủy thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindUsername_Click(object sender, EventArgs e)
        {
            if (rbtnUsername.Checked)
            {
                string key = txtFUsername.Text.Trim();
                if (string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<UserDTO> result = _userService.GetListUserByUsername(key);
                    if (result.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy tài khoản nào với tên đăng nhập này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        dgvInfo.DataSource = result;
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tìm kiếm theo tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             AddAccountBinding();
        }

        private void btnFindRole_Click(object sender, EventArgs e)
        {
            if (rbtnRole.Checked)
            {
                int role = (int)cboFRole.SelectedValue;
                var users = _userService.GetListUserByRole(role);
                if (users.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy tài khoản nào với vai trò này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    dgvInfo.DataSource = users;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tìm kiếm theo vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            AddAccountBinding();
        }
    }
}
