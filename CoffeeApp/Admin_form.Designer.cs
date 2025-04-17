namespace CoffeeApp
{
    partial class Admin_form
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(124, 71);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(374, 172);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Account";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnFood
            // 
            this.btnFood.Location = new System.Drawing.Point(124, 323);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(374, 172);
            this.btnFood.TabIndex = 1;
            this.btnFood.Text = "Food";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(640, 323);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(374, 172);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(640, 71);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(374, 172);
            this.btnTable.TabIndex = 3;
            this.btnTable.Text = "Table";
            this.btnTable.UseVisualStyleBackColor = true;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // Admin_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnFood);
            this.Controls.Add(this.btnAccount);
            this.Name = "Admin_Form";
            this.Size = new System.Drawing.Size(1353, 902);
            this.Load += new System.EventHandler(this.Admin_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnTable;
    }
}
