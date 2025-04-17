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
    public partial class CreateAccount_Form : Form
    {
        private readonly UserService _userService;
        public CreateAccount_Form()
        {
            _userService = new UserService();
            InitializeComponent();
            
            loadCombobox();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void loadCombobox()
        {
            List<RoleDTO> roleDTOs = new List<RoleDTO>();
            roleDTOs = _userService.getAllRole();
            cboRole.DataSource = roleDTOs;
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "RoleId";
        }
        
        public bool Register(string username , string password, string confirmpassword , int role)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                lblError.Text = "Please enter a username.";
                lblError.Visible = true;
                return false; 
            }
            if(string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter a password.";
                lblError.Visible = true;

                return false;
            }
            if (string.IsNullOrWhiteSpace(confirmpassword))
            {
                lblError.Text = "Please enter a confirm password.";
                lblError.Visible = true;
                return false;
            }
            if (password != confirmpassword)
            {
                lblError.Text = "Password and Confirm Password do not match!";
                lblError.Visible = true;
                return false;
            }

            var existingUser = _userService.GetUserByUsername(username);
            if (existingUser != null)
            {
                lblError.Text = "Username already exists!";
                lblError.Visible = true;
                return false;
            }

            UserDTO newUser = new UserDTO
            {
                Username = username,
                Password = password,
                CreatedDate = DateTime.Now,
                Role = (int)cboRole.SelectedValue,
                IsActive = true
            };

            _userService.AddUser(newUser);
            return true; 

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmpassword = txtConfirmPassword.Text.Trim();
            int role = (int)cboRole.SelectedValue;

            if(Register(username, password, confirmpassword, role))
            {
                var message = MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (message == DialogResult.OK)
                {
                    var loginForm = new form_login();
                    loginForm.Show();
                }
                this.Hide();
            }

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
