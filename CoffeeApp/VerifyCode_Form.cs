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
    public partial class VerifyCode_Form : Form
    {
        private string username;
        private readonly ForgotPasswordService _passwordService;
        public VerifyCode_Form(string username,string email)
        {
            InitializeComponent();
            this.username = username;
            _passwordService = new ForgotPasswordService();
        }

        private void txtOTP_Enter(object sender, EventArgs e)
        {
            if(txtOTP.Text == "Nhập mã xác nhận")
            {
                txtOTP.Text = ""; 
                txtOTP.ForeColor = Color.Black;
            }
        }

        private void btnXacMinh_Click(object sender, EventArgs e)
        {
            string token = txtOTP.Text;
            bool check = _passwordService.CheckValidate(username, token);
            if (check)
            {
                var changePassword_form = new ChangePassword_form(username);
                changePassword_form.ShowDialog();
                this.Hide();
            }
            else
            {
                lblError.Text = "OTP sai , vui lòng nhập lại";
                lblError.Visible = true; 
            }

        }
        private void btnResend_Click(object sender, EventArgs e)
        {
            _passwordService.GenerateResetToken(username);
        }
    }
}
