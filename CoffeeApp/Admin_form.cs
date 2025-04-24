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
    public partial class Admin_form : UserControl
    {
        public Admin_form()
        {
            InitializeComponent();
        }


        private void btnMenus_Click(object sender, EventArgs e)
        {

        }

        private void btnTables_Click(object sender, EventArgs e)
        {

        }

        private void btnStaffs_Click(object sender, EventArgs e)
        {

        }

        private void btnReporst_Click(object sender, EventArgs e)
        {

        }
        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void btnAccounts_Click_1(object sender, EventArgs e)
        {
            var accountUc = new Account_form();
            LoadUserControl(accountUc);
        }

        private void btnCategories_Click_1(object sender, EventArgs e)
        {
            var category_Form = new Category_form();
            LoadUserControl(category_Form);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnReporst_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTables_Click_1(object sender, EventArgs e)
        {
            var table_form = new Table_form();
            LoadUserControl(table_form);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnStaffs_Click_1(object sender, EventArgs e)
        {
            var employee_form = new Employee_Management_form();
            LoadUserControl(employee_form);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenus_Click_1(object sender, EventArgs e)
        {
            var food_form = new Food_form();
            LoadUserControl(food_form);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
