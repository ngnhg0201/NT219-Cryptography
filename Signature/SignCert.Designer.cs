
namespace Signature
{
    partial class SignCert
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
            this.btn_sign = new System.Windows.Forms.Button();
            this.lb_file = new System.Windows.Forms.Label();
            this.lb_privatekey = new System.Windows.Forms.Label();
            this.tb_urlCert = new System.Windows.Forms.TextBox();
            this.tb_urlKey = new System.Windows.Forms.TextBox();
            this.btn_urlCert = new System.Windows.Forms.Button();
            this.btn_urlKey = new System.Windows.Forms.Button();
            this.btn_urlSigned = new System.Windows.Forms.Button();
            this.tb_urlSigned = new System.Windows.Forms.TextBox();
            this.lb_urlSigned = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_create = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sign
            // 
            this.btn_sign.Location = new System.Drawing.Point(232, 255);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(136, 33);
            this.btn_sign.TabIndex = 0;
            this.btn_sign.Text = "Let\'s sign ";
            this.btn_sign.UseVisualStyleBackColor = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // lb_file
            // 
            this.lb_file.AutoSize = true;
            this.lb_file.Location = new System.Drawing.Point(40, 27);
            this.lb_file.Name = "lb_file";
            this.lb_file.Size = new System.Drawing.Size(85, 20);
            this.lb_file.TabIndex = 1;
            this.lb_file.Text = "Certificate:";
            // 
            // lb_privatekey
            // 
            this.lb_privatekey.AutoSize = true;
            this.lb_privatekey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_privatekey.Location = new System.Drawing.Point(6, 26);
            this.lb_privatekey.Name = "lb_privatekey";
            this.lb_privatekey.Size = new System.Drawing.Size(78, 20);
            this.lb_privatekey.TabIndex = 2;
            this.lb_privatekey.Text = "Filename:";
            // 
            // tb_urlCert
            // 
            this.tb_urlCert.Location = new System.Drawing.Point(163, 24);
            this.tb_urlCert.Name = "tb_urlCert";
            this.tb_urlCert.Size = new System.Drawing.Size(375, 26);
            this.tb_urlCert.TabIndex = 3;
            // 
            // tb_urlKey
            // 
            this.tb_urlKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_urlKey.Location = new System.Drawing.Point(127, 23);
            this.tb_urlKey.Name = "tb_urlKey";
            this.tb_urlKey.Size = new System.Drawing.Size(375, 26);
            this.tb_urlKey.TabIndex = 4;
            // 
            // btn_urlCert
            // 
            this.btn_urlCert.Location = new System.Drawing.Point(544, 24);
            this.btn_urlCert.Name = "btn_urlCert";
            this.btn_urlCert.Size = new System.Drawing.Size(42, 30);
            this.btn_urlCert.TabIndex = 5;
            this.btn_urlCert.Text = "...";
            this.btn_urlCert.UseVisualStyleBackColor = true;
            this.btn_urlCert.Click += new System.EventHandler(this.btn_urlCert_Click);
            // 
            // btn_urlKey
            // 
            this.btn_urlKey.Location = new System.Drawing.Point(510, 23);
            this.btn_urlKey.Name = "btn_urlKey";
            this.btn_urlKey.Size = new System.Drawing.Size(42, 31);
            this.btn_urlKey.TabIndex = 6;
            this.btn_urlKey.Text = "...";
            this.btn_urlKey.UseVisualStyleBackColor = true;
            this.btn_urlKey.Click += new System.EventHandler(this.btn_urlKey_Click);
            // 
            // btn_urlSigned
            // 
            this.btn_urlSigned.Location = new System.Drawing.Point(544, 60);
            this.btn_urlSigned.Name = "btn_urlSigned";
            this.btn_urlSigned.Size = new System.Drawing.Size(42, 30);
            this.btn_urlSigned.TabIndex = 10;
            this.btn_urlSigned.Text = "...";
            this.btn_urlSigned.UseVisualStyleBackColor = true;
            this.btn_urlSigned.Click += new System.EventHandler(this.btn_urlSigned_Click);
            // 
            // tb_urlSigned
            // 
            this.tb_urlSigned.Location = new System.Drawing.Point(163, 60);
            this.tb_urlSigned.Name = "tb_urlSigned";
            this.tb_urlSigned.Size = new System.Drawing.Size(375, 26);
            this.tb_urlSigned.TabIndex = 9;
            // 
            // lb_urlSigned
            // 
            this.lb_urlSigned.AutoSize = true;
            this.lb_urlSigned.Location = new System.Drawing.Point(40, 63);
            this.lb_urlSigned.Name = "lb_urlSigned";
            this.lb_urlSigned.Size = new System.Drawing.Size(97, 20);
            this.lb_urlSigned.TabIndex = 8;
            this.lb_urlSigned.Text = "Signed Cert:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_create);
            this.groupBox1.Controls.Add(this.tb_password);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_password);
            this.groupBox1.Controls.Add(this.tb_urlKey);
            this.groupBox1.Controls.Add(this.lb_privatekey);
            this.groupBox1.Controls.Add(this.btn_urlKey);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 134);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Private key:";
            // 
            // lb_create
            // 
            this.lb_create.AutoSize = true;
            this.lb_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_create.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_create.Location = new System.Drawing.Point(446, 101);
            this.lb_create.Name = "lb_create";
            this.lb_create.Size = new System.Drawing.Size(91, 17);
            this.lb_create.TabIndex = 13;
            this.lb_create.Text = "Create key.";
            this.lb_create.Click += new System.EventHandler(this.lb_create_Click);
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(127, 59);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(375, 26);
            this.tb_password.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Do not have a key pair?";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.Location = new System.Drawing.Point(6, 62);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(82, 20);
            this.lb_password.TabIndex = 7;
            this.lb_password.Text = "Password:";
            // 
            // SignCert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 314);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_urlSigned);
            this.Controls.Add(this.tb_urlSigned);
            this.Controls.Add(this.lb_urlSigned);
            this.Controls.Add(this.btn_urlCert);
            this.Controls.Add(this.tb_urlCert);
            this.Controls.Add(this.lb_file);
            this.Controls.Add(this.btn_sign);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SignCert";
            this.Text = "SIGN THE CERTIFICATE";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sign;
        private System.Windows.Forms.Label lb_file;
        private System.Windows.Forms.Label lb_privatekey;
        private System.Windows.Forms.TextBox tb_urlCert;
        private System.Windows.Forms.TextBox tb_urlKey;
        private System.Windows.Forms.Button btn_urlCert;
        private System.Windows.Forms.Button btn_urlKey;
        private System.Windows.Forms.Button btn_urlSigned;
        private System.Windows.Forms.TextBox tb_urlSigned;
        private System.Windows.Forms.Label lb_urlSigned;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_create;
    }
}

