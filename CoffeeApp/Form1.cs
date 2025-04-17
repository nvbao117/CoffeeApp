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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnAdmin.Click += new EventHandler(this.btnAdmin_Click);
            UIHelper uIHelper = new UIHelper(this); 
            uIHelper.EnableDragging(this.panel1, this.mainPanel, this.headerPanel);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void form_dashboard1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
            mainPanel.Controls.Clear();
            form_dashboard dashboard_Form = new form_dashboard();
            dashboard_Form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(dashboard_Form);
        }

        //private void btnAdmin_Click(object sender, EventArgs e)
        //{
        //    mainPanel.Controls.Clear();
        //    Admin_form admin_Form = new Admin_form();
        //    admin_Form.Dock = DockStyle.Fill;
        //    mainPanel.Controls.Add(admin_Form);
        //}

        private void btnStats_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            Checkout_form checkout_Form = new Checkout_form();
            checkout_Form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(checkout_Form);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin_form ucAdmin = new Admin_form();
            ucAdmin.Dock = DockStyle.Fill;

            ucAdmin.LoadContentRequested += (uc) =>
            {
                mainPanel.Controls.Clear();
                uc.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(uc);
            };

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(ucAdmin);
        }
    }
}
