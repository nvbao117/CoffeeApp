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
using System.Windows.Input;

namespace CoffeeApp
{
    public partial class Table_form : UserControl
    {
        private readonly TableService _tableService;
        private bool isAdding = false;
        private bool isEditing = false;
        public Table_form()
        {
            InitializeComponent();
            _tableService = new TableService();
            dgvData.AutoGenerateColumns = false;
            dgvData.ReadOnly = true;  
            LoadTables();
            customizeDGV();
            BindTableFields();
            LoadStatusComboBox();
        }
        private void LoadTables()
        {
            dgvData.DataSource = _tableService.GetAllTable();
        }
        private void ClearForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            cboStatus.SelectedIndex = -1;
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
            dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 136, 229);
            dgvData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
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
                var table = new TableFoodDTO
                {
                    Id = int.TryParse(txtID.Text, out int id) ? id : 0,
                    Name = txtName.Text.Trim(),
                    Status = cboStatus.SelectedItem?.ToString() ?? ""
                };

                try
                {
                    _tableService.Add(table);
                    MessageBox.Show("Đã thêm bàn thành công!");
                    LoadTables();
                    ClearForm();
                    isAdding = false;
                    btnAdd.Text = "Thêm";
                    BindTableFields();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Lỗi trùng mã bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void BindTableFields()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dgvData.DataSource, "Id");

            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", dgvData.DataSource, "Name");

            cboStatus.DataBindings.Clear();
            cboStatus.DataBindings.Add("Text", dgvData.DataSource, "Status");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn bàn để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _tableService.Delete(id);
                MessageBox.Show("Đã xóa bàn.");
                LoadTables();
                ClearForm();
                BindTableFields();
            }
        }
        private void LoadStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Có khách");
            cboStatus.Items.Add("Trống");
            cboStatus.SelectedIndex = 1;

            cboFindStatus.Items.Clear();
            cboFindStatus.Items.Add("Có khách");
            cboFindStatus.Items.Add("Trống");
            cboFindStatus.SelectedIndex = 1;
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

                var table = new TableFoodDTO
                {
                    Id = id,
                    Name = txtName.Text.Trim(),
                    Status = cboStatus.SelectedItem?.ToString() ?? ""
                };

                try
                {
                    _tableService.Update(table);
                    MessageBox.Show("Cập nhật bàn thành công!");
                    LoadTables();
                    ClearForm();
                    isEditing = false;
                    btnEdit.Text = "Sửa";
                    BindTableFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
            else
            {
                isEditing = true;
                isAdding = false;
                btnEdit.Text = "Xác nhận";
                btnAdd.Text = "Thêm";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            isAdding = false;
            isEditing = false;
            btnAdd.Text = "Thêm";
            btnEdit.Text = "Sửa";
            BindTableFields();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (rdoFindId.Checked)
            {
                int id = int.TryParse(txtFindId.Text, out int result) ? result : 0;
                if (id == 0)
                {
                    MessageBox.Show("Vui lòng nhập ID bàn.");
                    return;
                }
                var table = _tableService.GetById(id);
                if (table == null)
                {
                    MessageBox.Show("Không tìm thấy bàn nào với ID này.");
                }
                else
                {
                    dgvData.DataSource = new List<TableFoodDTO> { table };
                    BindTableFields();
                }
            }
            else if (rdoFindName.Checked)
            {
                string name = txtFindName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn.");
                    return;
                }
                var tables = _tableService.getTablesByName(name);
                if (tables.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy bàn nào với tên này.");
                }
                else
                {
                    dgvData.DataSource = tables;
                    BindTableFields();
                }
            }
            else if (rdoFindStatus.Checked)
            {
                string status = cboFindStatus.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái bàn.");
                    return;
                }
                var tables = _tableService.getTableBysStatus(status);
                if (tables.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy bàn nào với trạng thái này.");
                }
                else
                {
                    dgvData.DataSource = tables;
                    BindTableFields();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn phương thức tìm kiếm.");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTables();
        }
    }
}
