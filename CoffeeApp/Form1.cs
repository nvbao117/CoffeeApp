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
using BLL.BusinessComponents;
namespace CoffeeApp
{
    public partial class Form1 : Form
    {
        private readonly UserService _userService;
        private readonly EmployeeService _employeeService;
        private Button currentButton = null;
        public Form1()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _userService = new UserService();
            this.btnAdmin.Click += new EventHandler(this.btnAdmin_Click);
            UIHelper uIHelper = new UIHelper(this); 
            uIHelper.EnableDragging(this.panel1, this.mainPanel, this.headerPanel);
            var form_db = new form_dashboard(); 
            LoadUserControl(form_db);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UserDTO currentUser = AuthService.CurrentUser;
            if (currentUser == null) 
            { 
                return;
            }
            string name = _userService.getFullName(currentUser.UserId);
            lblName.Text = name;
            List<RoleDTO> roles = _userService.getAllRole();
            lblRole.Text = roles.Where(u => u.RoleId == currentUser.Role).Select(u => u.RoleName).FirstOrDefault();
            lblHeaderName.Text = "Welcom," + name;

            string linkImage = _employeeService.getLinkImage(currentUser.UserId);
            if (string.IsNullOrEmpty(linkImage))
            {
                ptrAvatar.Image = Properties.Resources.defaultAVT;
            }
            else
            {
                // Ảnh từ đường dẫn trên máy
                ptrAvatar.Image = Image.FromFile(linkImage);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            LoadUserControl(new form_dashboard());
        }

        
        private void btnStats_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            ActivateButton(btnCheckout);
            LoadUserControl(new Checkout_form());
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ActivateButton(btnAdmin);
            LoadUserControl(new Admin_form());
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            var message = MessageBox.Show("Bạn có muốn thoát không ?", "Oke", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var messgage = MessageBox.Show("Bạn có muốn đăng xuất?", "Oke", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messgage == DialogResult.Yes)
            {
                var login = new form_login();
                login.Show();
                this.Close();
                AuthService.Logout();
            }
        }
        private void ActivateButton(Button clickedButton)
        {
            if (currentButton != null)
            {
                ResetButtonStyles(currentButton); // Reset cái cũ
            }

            // Đổi style button mới
            currentButton = clickedButton;
            currentButton.BackColor = Color.FromArgb(30, 136, 229); 
            currentButton.ForeColor = Color.White;
            currentButton.Font = new Font(currentButton.Font, FontStyle.Bold);
        }

        private void ResetButtonStyles(Button btn)
        {
            btn.BackColor = Color.FromArgb(102, 44, 33); 
            btn.ForeColor = Color.White;
            btn.Font = new Font(btn.Font, FontStyle.Regular);
        }
        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }
    }
}
