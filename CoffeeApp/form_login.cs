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
    public partial class form_login : Form
    {
        private readonly AuthService _authService;

        // Constructor nhận các service qua Dependency Injection
        public form_login()
        {
            InitializeComponent();
            UIHelper uIHelper = new UIHelper(this);
            uIHelper.EnableDragging(this.panel1, this.panel2);

            _authService = new AuthService();
        }

        private void form_login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void Login()
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                lblError.Visible = false;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    lblError.Text = "Please enter both username and password.";
                    lblError.Visible = true;
                    return;
                }

                btnLogin.Enabled = false;
                btnLogin.Text = "Logging in...";

                bool isAuthenticated = _authService.Authenticate(username, password);
                if (isAuthenticated)
                {
                    // Login successful, open the main form
                    var mainForm = new Form1();
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    lblError.Text = "Invalid username or password";
                    lblError.Visible = true;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                Application.Exit();
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            var createAccount_Form = new CreateAccount_Form();
            createAccount_Form.ShowDialog();
        }


        private void lblSignUp_MouseHover(object sender, EventArgs e)
        {
            lblSignUp.ForeColor = Color.AliceBlue;
        }

        private void lblSignUp_MouseLeave(object sender, EventArgs e)
        {
            lblSignUp.ForeColor = Color.Black;
        }

        private void lblForgotPsw_MouseHover(object sender, EventArgs e)
        {
            lblForgotPsw.ForeColor = Color.White;
        }

        private void lblForgotPsw_MouseLeave(object sender, EventArgs e)
        {
            lblForgotPsw.ForeColor = Color.Maroon; 
        }

        private void lblForgotPsw_Click(object sender, EventArgs e)
        {
            var forgotPassword_form = new FogotPassword_Form();
            forgotPassword_form.ShowDialog();
        }
    }
}
