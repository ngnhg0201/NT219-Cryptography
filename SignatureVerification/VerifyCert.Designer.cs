namespace SignatureVerification
{
    partial class VerifyCert
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
            this.btn_verify = new System.Windows.Forms.Button();
            this.lb_signature = new System.Windows.Forms.Label();
            this.tb_urlSigned = new System.Windows.Forms.TextBox();
            this.btn_urlSigned = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_verify
            // 
            this.btn_verify.Location = new System.Drawing.Point(196, 77);
            this.btn_verify.Name = "btn_verify";
            this.btn_verify.Size = new System.Drawing.Size(136, 33);
            this.btn_verify.TabIndex = 0;
            this.btn_verify.Text = "Let\'s verify";
            this.btn_verify.UseVisualStyleBackColor = true;
            this.btn_verify.Click += new System.EventHandler(this.btn_verify_Click);
            // 
            // lb_signature
            // 
            this.lb_signature.AutoSize = true;
            this.lb_signature.Location = new System.Drawing.Point(31, 35);
            this.lb_signature.Name = "lb_signature";
            this.lb_signature.Size = new System.Drawing.Size(97, 20);
            this.lb_signature.TabIndex = 1;
            this.lb_signature.Text = "Signed Cert:";
            // 
            // tb_urlSigned
            // 
            this.tb_urlSigned.Location = new System.Drawing.Point(134, 32);
            this.tb_urlSigned.Name = "tb_urlSigned";
            this.tb_urlSigned.Size = new System.Drawing.Size(316, 26);
            this.tb_urlSigned.TabIndex = 5;
            // 
            // btn_urlSigned
            // 
            this.btn_urlSigned.Location = new System.Drawing.Point(456, 30);
            this.btn_urlSigned.Name = "btn_urlSigned";
            this.btn_urlSigned.Size = new System.Drawing.Size(35, 30);
            this.btn_urlSigned.TabIndex = 9;
            this.btn_urlSigned.Text = "...";
            this.btn_urlSigned.UseVisualStyleBackColor = true;
            this.btn_urlSigned.Click += new System.EventHandler(this.btn_urlSigned_Click);
            // 
            // VerifyCert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 122);
            this.Controls.Add(this.btn_urlSigned);
            this.Controls.Add(this.tb_urlSigned);
            this.Controls.Add(this.lb_signature);
            this.Controls.Add(this.btn_verify);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VerifyCert";
            this.Text = "VERIFY THE CERTIFICATE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Button btn_verify;
        private System.Windows.Forms.Label lb_signature;
        private System.Windows.Forms.TextBox tb_urlSigned;
        private System.Windows.Forms.Button btn_urlSigned;
    }
}

