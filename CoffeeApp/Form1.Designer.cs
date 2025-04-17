using System.Windows.Forms;

namespace CoffeeApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.form_dashboard3 = new CoffeeApp.form_dashboard();
            this.admin_Form1 = new CoffeeApp.Admin_form();
            this.form_dashboard2 = new CoffeeApp.form_dashboard();
            this.account_form1 = new CoffeeApp.Account_form();
            this.category_form1 = new CoffeeApp.Category_form();
            this.checkout_form1 = new CoffeeApp.Checkout_form();
            this.checkoutAndPrintBill_form1 = new CoffeeApp.CheckoutAndPrintBill_form();
            this.table_form1 = new CoffeeApp.Table_form();
            this.form_dashboard1 = new CoffeeApp.form_dashboard();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.pictureBox2);
            this.headerPanel.Controls.Add(this.label3);
            this.headerPanel.Controls.Add(this.label2);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.ForeColor = System.Drawing.Color.Black;
            this.headerPanel.Location = new System.Drawing.Point(266, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1054, 47);
            this.headerPanel.TabIndex = 1;
            this.headerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CoffeeApp.Properties.Resources.user_12483574;
            this.pictureBox2.Location = new System.Drawing.Point(755, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(796, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Welcom,Nguyễn Vũ Bảo";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coffee Management";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(44)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCheckout);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.btnStats);
            this.panel1.Controls.Add(this.btnAdmin);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 800);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(43, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nguyễn Vũ Bảo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(81, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = " Admin";
            // 
            // btnCheckout
            // 
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.Transparent;
            this.btnCheckout.Image = global::CoffeeApp.Properties.Resources.self_service_5025580;
            this.btnCheckout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckout.Location = new System.Drawing.Point(12, 598);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(242, 55);
            this.btnCheckout.TabIndex = 6;
            this.btnCheckout.Text = "CHECKOUT";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::CoffeeApp.Properties.Resources.log_out_10024225;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(12, 733);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(242, 55);
            this.button5.TabIndex = 5;
            this.button5.Text = "LOGOUT";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.Transparent;
            this.btnOrder.Image = global::CoffeeApp.Properties.Resources.manifest_16767941;
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(12, 537);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(242, 55);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "ORDER";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnStats
            // 
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.ForeColor = System.Drawing.Color.Transparent;
            this.btnStats.Image = global::CoffeeApp.Properties.Resources.poll_9449270;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.Location = new System.Drawing.Point(12, 476);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(242, 55);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "STATS";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.Transparent;
            this.btnAdmin.Image = global::CoffeeApp.Properties.Resources.web_development_762714;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(12, 415);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(242, 55);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Transparent;
            this.btnDashboard.Image = global::CoffeeApp.Properties.Resources.dashboard_1991103__2_;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(12, 354);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(242, 55);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CoffeeApp.Properties.Resources.Douong;
            this.pictureBox1.Location = new System.Drawing.Point(29, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.form_dashboard3);
            this.mainPanel.Controls.Add(this.admin_Form1);
            this.mainPanel.Controls.Add(this.form_dashboard2);
            this.mainPanel.Controls.Add(this.account_form1);
            this.mainPanel.Controls.Add(this.category_form1);
            this.mainPanel.Controls.Add(this.checkout_form1);
            this.mainPanel.Controls.Add(this.checkoutAndPrintBill_form1);
            this.mainPanel.Controls.Add(this.table_form1);
            this.mainPanel.Controls.Add(this.form_dashboard1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(266, 47);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1054, 753);
            this.mainPanel.TabIndex = 2;
            // 
            // form_dashboard3
            // 
            this.form_dashboard3.Location = new System.Drawing.Point(0, 0);
            this.form_dashboard3.Name = "form_dashboard3";
            this.form_dashboard3.Size = new System.Drawing.Size(1054, 753);
            this.form_dashboard3.TabIndex = 8;
            // 
            // admin_Form1
            // 
            this.admin_Form1.Location = new System.Drawing.Point(0, 0);
            this.admin_Form1.Name = "admin_Form1";
            this.admin_Form1.Size = new System.Drawing.Size(1353, 902);
            this.admin_Form1.TabIndex = 7;
            // 
            // form_dashboard2
            // 
            this.form_dashboard2.Location = new System.Drawing.Point(0, 0);
            this.form_dashboard2.Name = "form_dashboard2";
            this.form_dashboard2.Size = new System.Drawing.Size(1054, 753);
            this.form_dashboard2.TabIndex = 6;
            // 
            // account_form1
            // 
            this.account_form1.BackColor = System.Drawing.Color.Gainsboro;
            this.account_form1.Location = new System.Drawing.Point(0, 0);
            this.account_form1.Name = "account_form1";
            this.account_form1.Size = new System.Drawing.Size(1054, 753);
            this.account_form1.TabIndex = 5;
            // 
            // category_form1
            // 
            this.category_form1.Location = new System.Drawing.Point(0, 0);
            this.category_form1.Name = "category_form1";
            this.category_form1.Size = new System.Drawing.Size(1054, 753);
            this.category_form1.TabIndex = 4;
            // 
            // checkout_form1
            // 
            this.checkout_form1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(169)))));
            this.checkout_form1.Location = new System.Drawing.Point(0, 0);
            this.checkout_form1.Name = "checkout_form1";
            this.checkout_form1.Size = new System.Drawing.Size(1054, 753);
            this.checkout_form1.TabIndex = 3;
            // 
            // checkoutAndPrintBill_form1
            // 
            this.checkoutAndPrintBill_form1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(190)))), ((int)(((byte)(169)))));
            this.checkoutAndPrintBill_form1.Location = new System.Drawing.Point(0, 0);
            this.checkoutAndPrintBill_form1.Name = "checkoutAndPrintBill_form1";
            this.checkoutAndPrintBill_form1.Size = new System.Drawing.Size(1054, 753);
            this.checkoutAndPrintBill_form1.TabIndex = 2;
            // 
            // table_form1
            // 
            this.table_form1.Location = new System.Drawing.Point(0, 0);
            this.table_form1.Name = "table_form1";
            this.table_form1.Size = new System.Drawing.Size(1054, 753);
            this.table_form1.TabIndex = 1;
            // 
            // form_dashboard1
            // 
            this.form_dashboard1.Location = new System.Drawing.Point(0, 3);
            this.form_dashboard1.Name = "form_dashboard1";
            this.form_dashboard1.Size = new System.Drawing.Size(1054, 753);
            this.form_dashboard1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1320, 800);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnAdmin;
        private Button btnDashboard;
        private Button btnCheckout;
        private Button button5;
        private Button btnOrder;
        private Button btnStats;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label5;
        private Label label4;
        private Panel mainPanel;
        private Account_form account_form1;
        private Category_form category_form1;
        private Checkout_form checkout_form1;
        private CheckoutAndPrintBill_form checkoutAndPrintBill_form1;
        private Table_form table_form1;
        private form_dashboard form_dashboard1;
        private form_dashboard form_dashboard2;
        private Admin_form admin_Form1;
        private form_dashboard form_dashboard3;
    }
}

