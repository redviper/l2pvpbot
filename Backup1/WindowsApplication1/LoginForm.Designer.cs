namespace l2pvp
{
    partial class LoginForm
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_gsip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ipaddr = new System.Windows.Forms.TextBox();
            this.bt_listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(113, 111);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Local IP to listen to";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "GameServer";
            // 
            // tb_gsip
            // 
            this.tb_gsip.Location = new System.Drawing.Point(77, 54);
            this.tb_gsip.Name = "tb_gsip";
            this.tb_gsip.Size = new System.Drawing.Size(95, 20);
            this.tb_gsip.TabIndex = 11;
            this.tb_gsip.Text = "206.127.155.131";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Server IP";
            // 
            // tb_ipaddr
            // 
            this.tb_ipaddr.Location = new System.Drawing.Point(77, 28);
            this.tb_ipaddr.Name = "tb_ipaddr";
            this.tb_ipaddr.Size = new System.Drawing.Size(95, 20);
            this.tb_ipaddr.TabIndex = 9;
            this.tb_ipaddr.Text = "216.107.242.199";
            // 
            // bt_listen
            // 
            this.bt_listen.Location = new System.Drawing.Point(184, 25);
            this.bt_listen.Name = "bt_listen";
            this.bt_listen.Size = new System.Drawing.Size(75, 23);
            this.bt_listen.TabIndex = 8;
            this.bt_listen.Text = "Listen";
            this.bt_listen.UseVisualStyleBackColor = true;
            this.bt_listen.Click += new System.EventHandler(this.bt_listen_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 157);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_gsip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ipaddr);
            this.Controls.Add(this.bt_listen);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_gsip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ipaddr;
        private System.Windows.Forms.Button bt_listen;
    }
}