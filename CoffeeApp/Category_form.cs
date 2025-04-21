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
    public partial class Category_form : UserControl
    {
        private readonly CategoryService _categoryService;
        private bool checkAdd = false;
        private bool checkUpdate = false;

        public Category_form()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            dgvData.AutoGenerateColumns = false;
            customizeDGV();
            LoadCategoryData();
            LoadCombobox(); 
        }

        public void LoadCombobox()
        {
            var category = _categoryService.GetAll();
            cboCategory.DataSource = category;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id"; 
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
            if (checkAdd)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Tên danh mục không được để trống.");
                    return;
                }

                var dto = new FoodCategoryDTO
                {
                    Name = txtName.Text.Trim()
                };

                _categoryService.Add(dto);
                MessageBox.Show("Thêm danh mục thành công!");
                LoadCategoryData();
                ClearInput();
                checkAdd = false;
                txtId.Enabled = true;
                btnAdd.Text = "Thêm";
                btnCancel.Visible = false;
            }
            else
            {
                checkAdd = true;
                ClearInput();
                txtId.Enabled = false;
                btnAdd.Text = "Xác nhận";
                btnCancel.Visible = true;
            }
        }
        private void LoadCategoryData()
        {
            dgvData.DataSource = _categoryService.GetAll();
        }

        private void ClearInput()
        {
            txtId.Text = "";
            txtName.Text = "";
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (!checkUpdate)
            {
                checkUpdate = true;
                txtId.Enabled = false;
                btnUpdate.Text = "Xác nhận";
                btnCancel.Visible = true;
                return;
            }

            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn danh mục hợp lệ để cập nhật.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống.");
                return;
            }

            var dto = new FoodCategoryDTO
            {
                Id = id,
                Name = txtName.Text.Trim()
            };

            _categoryService.Update(dto);
            MessageBox.Show("Cập nhật danh mục thành công!");
            LoadCategoryData();
            ClearInput();
            checkUpdate = false;
            txtId.Enabled = true;
            btnUpdate.Text = "Sửa";
            btnCancel.Visible = false;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn danh mục hợp lệ để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _categoryService.Delete(id);
                MessageBox.Show("Xóa danh mục thành công!");
                LoadCategoryData();
                ClearInput();
                btnCancel.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInput();
            txtId.Enabled = true;
            checkAdd = false;
            checkUpdate = false;
            btnAdd.Text = "Thêm";
            btnUpdate.Text = "Sửa";
            btnCancel.Visible = false;
        }

        private void dgvData_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString();
                txtName.Text = dgvData.Rows[e.RowIndex].Cells["colName"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoCategory.Checked)
            {
                int key = (int)cboCategory.SelectedValue; 
                var result  = _categoryService.GetById(key);
                if (result != null)
                {
                    List<FoodCategoryDTO> list = new List<FoodCategoryDTO>();
                    list.Add(result);
                    dgvData.DataSource = list;
                   
                }
                else
                {
                    MessageBox.Show("Không tìm thấy danh mục nào với ID đã nhập.");
                    LoadCategoryData();
                }
            }
            else if(rdoName.Checked)
            {
                string key = txtFName.Text.Trim();
                if (string.IsNullOrWhiteSpace(key))
                {
                    MessageBox.Show("Vui lòng nhập tên danh mục để tìm kiếm.");
                }
                else
                {
                    var result = _categoryService.GetFoodCategoriesByName(key);
                    if(result != null && result.Count > 0)
                    {
                        dgvData.DataSource = result;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy danh mục nào với tên đã nhập.");
                        LoadCategoryData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm.");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategoryData();
        }
    }
}
