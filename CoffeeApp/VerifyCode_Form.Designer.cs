namespace CoffeeApp
{
    partial class VerifyCode_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyCode_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnXacMinh = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnResend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "OTP Verification ";
            // 
            // txtOTP
            // 
            this.txtOTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP.ForeColor = System.Drawing.Color.Silver;
            this.txtOTP.Location = new System.Drawing.Point(41, 179);
            this.txtOTP.Multiline = true;
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(280, 46);
            this.txtOTP.TabIndex = 1;
            this.txtOTP.Text = "Nhập mã xác nhận";
            this.txtOTP.Enter += new System.EventHandler(this.txtOTP_Enter);
            // 
            // btnXacMinh
            // 
            this.btnXacMinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnXacMinh.FlatAppearance.BorderSize = 0;
            this.btnXacMinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacMinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacMinh.ForeColor = System.Drawing.Color.White;
            this.btnXacMinh.Location = new System.Drawing.Point(41, 260);
            this.btnXacMinh.Name = "btnXacMinh";
            this.btnXacMinh.Size = new System.Drawing.Size(129, 39);
            this.btnXacMinh.TabIndex = 3;
            this.btnXacMinh.Text = "Xác Minh";
            this.btnXacMinh.UseVisualStyleBackColor = false;
            this.btnXacMinh.Click += new System.EventHandler(this.btnXacMinh_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(37, 145);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(105, 19);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "Message Error";
            this.lblError.Visible = false;
            // 
            // btnResend
            // 
            this.btnResend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnResend.FlatAppearance.BorderSize = 0;
            this.btnResend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResend.ForeColor = System.Drawing.Color.White;
            this.btnResend.Location = new System.Drawing.Point(192, 260);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(129, 39);
            this.btnResend.TabIndex = 5;
            this.btnResend.Text = "Gửi lại mã ";
            this.btnResend.UseVisualStyleBackColor = false;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // VerifyCode_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 378);
            this.Controls.Add(this.btnResend);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnXacMinh);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerifyCode_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTP Code Verification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnXacMinh;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnResend;
    }
}