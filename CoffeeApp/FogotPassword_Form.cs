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

namespace CoffeeApp
{
    public partial class FogotPassword_Form : Form
    {
        private readonly ForgotPasswordService _forgotPasswordService;
        private readonly UserService _userService;
        public FogotPassword_Form()
        {
            InitializeComponent();
            _userService = new UserService();
            _forgotPasswordService = new ForgotPasswordService();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string username = txtUsername.Text;

            if(string.IsNullOrWhiteSpace(email) )
            {
                MessageBox.Show("Vui lòng nhập email.","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var (user,useremail) = _userService.GetUserAndEmailByUsername(username);
            if(user == null)
            {
                Console.WriteLine($"User: {user}, Email: {email}");
                return;
            }
            if (!string.Equals(useremail, email, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Email không khớp với tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string token = _forgotPasswordService.GenerateResetToken(username);
            if (token == null) 
            {
                MessageBox.Show("Không thể tạo mã xác nhận.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var verifyForm = new VerifyCode_Form(email);
            verifyForm.Show();
            this.Hide();
        }
    }
}
