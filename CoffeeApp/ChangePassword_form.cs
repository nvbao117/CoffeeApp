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
using BLL.BusinessEntities;
namespace CoffeeApp
{
    public partial class ChangePassword_form : Form
    {
        private string _username;
        private UserService _userService;

        public ChangePassword_form(string username)
        {
            InitializeComponent();
            _username = username;
            _userService = new UserService();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNPasswrod.Text;
            bool checkInput = ValidateInput();
            if (checkInput)
            {
                UserDTO user = _userService.GetUserByUsername(_username);
                user.Password = newPassword;
                if (user != null)
                {
                    _userService.UpdateUser(user);
                    MessageBox.Show("Đã Cập Nhật Mật Khẩu", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    this.Close();
                }
                else
                {
                    lblError.Text = "User không tồn tại";
                    lblError.Visible = true;
                }

            }
        }
        public bool ValidateInput()
        {
            string password = txtNPasswrod.Text;
            string cpassword = txtCPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Vui lòng nhập mật khẩu";
                lblError.Visible = true; 
                return false;
            }
            if(string.IsNullOrWhiteSpace(cpassword))
            {
                lblError.Text = "Vui lòng xác nhận mật khẩu";
                lblError.Visible = true;
                return false;
            }
            if (password != cpassword)
            {
                lblError.Text = "Mật khẩu và xác nhận mật khẩu không trùng khớp.";
                lblError.Visible = true;
                return false;
            }
            return true;

        }

    }
}
