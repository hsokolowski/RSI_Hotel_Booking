namespace RSI_Hotel_Booking.Auth
{
    partial class Register
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
            this.registerBtn = new System.Windows.Forms.Button();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.surnameTb = new System.Windows.Forms.TextBox();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.registerBtn.Location = new System.Drawing.Point(192, 383);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(162, 39);
            this.registerBtn.TabIndex = 0;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(192, 96);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(162, 22);
            this.nameTb.TabIndex = 1;
            // 
            // surnameTb
            // 
            this.surnameTb.Location = new System.Drawing.Point(192, 154);
            this.surnameTb.Name = "surnameTb";
            this.surnameTb.Size = new System.Drawing.Size(162, 22);
            this.surnameTb.TabIndex = 2;
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(192, 213);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(162, 22);
            this.emailTb.TabIndex = 3;
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(192, 275);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(162, 22);
            this.passwordTb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Surname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(549, 458);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.emailTb);
            this.Controls.Add(this.surnameTb);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.registerBtn);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.TextBox surnameTb;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}