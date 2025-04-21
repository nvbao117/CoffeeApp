using BLL.BusinessComponents;
using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeApp
{
    public partial class Food_form : UserControl
    {
        private readonly FoodService _foodService; 
        private readonly CategoryService _categoryService;
        private string selectedImagePath = string.Empty;

        public Food_form()
        {
            InitializeComponent();
            _foodService = new FoodService();
            _categoryService = new CategoryService();
            InitUI();
        }
        private void InitUI()
        {
            dgvData.AutoGenerateColumns = false;
            dgvData.ReadOnly = true;
            customizeDGV();
            LoadCombobox();
            LoadFoods();
            BindFoodFields();
        }


        public void LoadFoods()
        {
            dgvData.DataSource = _foodService.Foods();
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
        private void LoadCombobox()
        {
            var categories = _categoryService.GetAll();

            // ComboBox ngoài form
            cboCategory.DataSource = categories.ToList();
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            // ComboBox trong DataGridView
            colCategory.DataSource = categories.ToList();
            colCategory.DisplayMember = "Name";
            colCategory.ValueMember = "Id";
            colCategory.DataPropertyName = "FoodCategoryId";
        }
        public void BindFoodFields()
        {
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add("Text", dgvData.DataSource, "Id");
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", dgvData.DataSource, "Name");
            txtPrice.DataBindings.Clear();
            txtPrice.DataBindings.Add("Text", dgvData.DataSource, "Price");
            cboCategory.DataBindings.Clear();
            cboCategory.DataBindings.Add("SelectedValue", dgvData.DataSource, "FoodCategoryId");

            picImage.DataBindings.Clear();
            picImage.DataBindings.Add("ImageLocation", dgvData.DataSource, "Image");
        }

        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picImage.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }
            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Giá không hợp lệ.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên món không được để trống.");
                return;
            }

            var existing = _foodService.GetFoodById(id);
            if (existing != null)
            {
                MessageBox.Show("ID đã tồn tại. Vui lòng chọn ID khác.");
                return;
            }

            var food = new FoodDTO
            {
                Id = id,
                Name = txtName.Text.Trim(),
                Price = price,
                FoodCategoryId = (int)cboCategory.SelectedValue,
                Image = SaveImageToResources(selectedImagePath, id)
            };

            _foodService.AddFood(food);
            LoadFoods();
            BindFoodFields();
            MessageBox.Show("Đã thêm thành công!");
        }
        private string SaveImageToResources(string imagePath, int foodId)
        {
            if(!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                string fileName = $"prd{foodId}{Path.GetExtension(imagePath)}";
                string relativePath = Path.Combine("Resources", "imgProduct", fileName);
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                File.Copy(imagePath, fullPath, true);
                return relativePath;
            }
            else
            {
                return Path.Combine("Resources", "imgProduct", "default.png");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }
            if (!double.TryParse(txtPrice.Text, out double price))
            {
                MessageBox.Show("Giá không hợp lệ.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên món không được để trống.");
                return;
            }

            var existing = _foodService.GetFoodById(id);
            if (existing == null)
            {
                MessageBox.Show("Không tìm thấy món ăn để cập nhật.");
                return;
            }

            var food = new FoodDTO
            {
                Id = id,
                Name = txtName.Text.Trim(),
                Price = price,
                FoodCategoryId = (int)cboCategory.SelectedValue,
                Image = SaveImageToResources(selectedImagePath, id)
            };

            _foodService.Update(food);
            LoadFoods();
            BindFoodFields();
            MessageBox.Show("Cập nhật thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn món cần xoá.");
                return;
            }
            var existing = _foodService.GetFoodById(id);
            if (existing == null)
            {
                MessageBox.Show("Không tìm thấy món ăn để xoá.");
                return;
            }
            _foodService.Delete(id);
            LoadFoods();
            BindFoodFields();
            MessageBox.Show("Đã xoá món ăn!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            cboCategory.SelectedIndex = 0;
            picImage.Image = null;
            selectedImagePath = string.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFoods();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string Name = txtFind.Text.Trim();

            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn để tìm kiếm.");
                return;
            }
            var foods = _foodService.GetListFoodByName(Name);
            if (foods.Count == 0)
            {
                MessageBox.Show("Không tìm thấy món ăn nào.");
                return;
            }
            dgvData.DataSource = foods;
            BindFoodFields();
        }
    }
}
