namespace Signature
{
    partial class CreateKey
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
            this.btn_createKey = new System.Windows.Forms.Button();
            this.btn_urlSigned = new System.Windows.Forms.Button();
            this.tb_urlPrKey = new System.Windows.Forms.TextBox();
            this.lb_urlPrKey = new System.Windows.Forms.Label();
            this.tb_urlPuKey = new System.Windows.Forms.TextBox();
            this.lb_urlPuKey = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_createKey
            // 
            this.btn_createKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createKey.Location = new System.Drawing.Point(152, 112);
            this.btn_createKey.Margin = new System.Windows.Forms.Padding(2);
            this.btn_createKey.Name = "btn_createKey";
            this.btn_createKey.Size = new System.Drawing.Size(102, 27);
            this.btn_createKey.TabIndex = 4;
            this.btn_createKey.Text = "Create Key";
            this.btn_createKey.UseVisualStyleBackColor = true;
            this.btn_createKey.Click += new System.EventHandler(this.btn_createKey_Click);
            // 
            // btn_urlSigned
            // 
            this.btn_urlSigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_urlSigned.Location = new System.Drawing.Point(356, 20);
            this.btn_urlSigned.Margin = new System.Windows.Forms.Padding(2);
            this.btn_urlSigned.Name = "btn_urlSigned";
            this.btn_urlSigned.Size = new System.Drawing.Size(30, 24);
            this.btn_urlSigned.TabIndex = 12;
            this.btn_urlSigned.Text = "...";
            this.btn_urlSigned.UseVisualStyleBackColor = true;
            this.btn_urlSigned.Click += new System.EventHandler(this.btn_urlSigned_Click);
            // 
            // tb_urlPrKey
            // 
            this.tb_urlPrKey.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_urlPrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_urlPrKey.Location = new System.Drawing.Point(114, 20);
            this.tb_urlPrKey.Margin = new System.Windows.Forms.Padding(2);
            this.tb_urlPrKey.Name = "tb_urlPrKey";
            this.tb_urlPrKey.ReadOnly = true;
            this.tb_urlPrKey.Size = new System.Drawing.Size(238, 26);
            this.tb_urlPrKey.TabIndex = 11;
            this.tb_urlPrKey.Text = "private_key.pem";
            // 
            // lb_urlPrKey
            // 
            this.lb_urlPrKey.AutoSize = true;
            this.lb_urlPrKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_urlPrKey.Location = new System.Drawing.Point(18, 23);
            this.lb_urlPrKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_urlPrKey.Name = "lb_urlPrKey";
            this.lb_urlPrKey.Size = new System.Drawing.Size(91, 20);
            this.lb_urlPrKey.TabIndex = 10;
            this.lb_urlPrKey.Text = "Private Key:";
            // 
            // tb_urlPuKey
            // 
            this.tb_urlPuKey.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_urlPuKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_urlPuKey.Location = new System.Drawing.Point(114, 50);
            this.tb_urlPuKey.Margin = new System.Windows.Forms.Padding(2);
            this.tb_urlPuKey.Name = "tb_urlPuKey";
            this.tb_urlPuKey.ReadOnly = true;
            this.tb_urlPuKey.Size = new System.Drawing.Size(238, 26);
            this.tb_urlPuKey.TabIndex = 14;
            this.tb_urlPuKey.Text = "public_key.pem";
            // 
            // lb_urlPuKey
            // 
            this.lb_urlPuKey.AutoSize = true;
            this.lb_urlPuKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_urlPuKey.Location = new System.Drawing.Point(18, 52);
            this.lb_urlPuKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_urlPuKey.Name = "lb_urlPuKey";
            this.lb_urlPuKey.Size = new System.Drawing.Size(85, 20);
            this.lb_urlPuKey.TabIndex = 13;
            this.lb_urlPuKey.Text = "Public Key:";
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(114, 79);
            this.tb_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(238, 26);
            this.tb_password.TabIndex = 16;
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.Location = new System.Drawing.Point(18, 81);
            this.lb_password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(82, 20);
            this.lb_password.TabIndex = 15;
            this.lb_password.Text = "Password:";
            // 
            // CreateKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 155);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.tb_urlPuKey);
            this.Controls.Add(this.lb_urlPuKey);
            this.Controls.Add(this.btn_urlSigned);
            this.Controls.Add(this.tb_urlPrKey);
            this.Controls.Add(this.lb_urlPrKey);
            this.Controls.Add(this.btn_createKey);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(424, 194);
            this.MinimumSize = new System.Drawing.Size(424, 194);
            this.Name = "CreateKey";
            this.Text = "CREATE THE KEY";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createKey;
        private System.Windows.Forms.Button btn_urlSigned;
        private System.Windows.Forms.TextBox tb_urlPrKey;
        private System.Windows.Forms.Label lb_urlPrKey;
        private System.Windows.Forms.TextBox tb_urlPuKey;
        private System.Windows.Forms.Label lb_urlPuKey;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label lb_password;
    }
}