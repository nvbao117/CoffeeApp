namespace CoffeeApp
{
    partial class Test
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.category_form1 = new CoffeeApp.Category_form();
            this.SuspendLayout();
            // 
            // category_form1
            // 
            this.category_form1.Location = new System.Drawing.Point(117, 32);
            this.category_form1.Name = "category_form1";
            this.category_form1.Size = new System.Drawing.Size(1054, 753);
            this.category_form1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1220, 834);
            this.Controls.Add(this.category_form1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Category_form category_form1;
    }
}