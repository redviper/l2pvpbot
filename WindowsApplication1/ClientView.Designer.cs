namespace l2pvp
{
    partial class ClientView
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
            this.lb_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_CPMAX = new System.Windows.Forms.Label();
            this.lb_HPMAX = new System.Windows.Forms.Label();
            this.lb_CP = new System.Windows.Forms.Label();
            this.lb_HP = new System.Windows.Forms.Label();
            this.tb_Attackdistance = new System.Windows.Forms.TextBox();
            this.cb_Attack = new System.Windows.Forms.CheckBox();
            this.cb_Shift = new System.Windows.Forms.CheckBox();
            this.bt_Buffs = new System.Windows.Forms.Button();
            this.bt_Skills = new System.Windows.Forms.Button();
            this.bt_Party = new System.Windows.Forms.Button();
            this.bt_Defense = new System.Windows.Forms.Button();
            this.bt_logout = new System.Windows.Forms.Button();
            this.bt_Leader = new System.Windows.Forms.Button();
            this.bskills = new System.Windows.Forms.CheckBox();
            this.bdefend = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.shotbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rebuff = new System.Windows.Forms.Button();
            this.itbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(0, 0);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(35, 13);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CP";
            // 
            // lb_CPMAX
            // 
            this.lb_CPMAX.AutoSize = true;
            this.lb_CPMAX.Location = new System.Drawing.Point(68, 45);
            this.lb_CPMAX.Name = "lb_CPMAX";
            this.lb_CPMAX.Size = new System.Drawing.Size(35, 13);
            this.lb_CPMAX.TabIndex = 4;
            this.lb_CPMAX.Text = "label3";
            // 
            // lb_HPMAX
            // 
            this.lb_HPMAX.AutoSize = true;
            this.lb_HPMAX.Location = new System.Drawing.Point(68, 23);
            this.lb_HPMAX.Name = "lb_HPMAX";
            this.lb_HPMAX.Size = new System.Drawing.Size(35, 13);
            this.lb_HPMAX.TabIndex = 3;
            this.lb_HPMAX.Text = "label4";
            // 
            // lb_CP
            // 
            this.lb_CP.AutoSize = true;
            this.lb_CP.Location = new System.Drawing.Point(27, 45);
            this.lb_CP.Name = "lb_CP";
            this.lb_CP.Size = new System.Drawing.Size(35, 13);
            this.lb_CP.TabIndex = 6;
            this.lb_CP.Text = "label5";
            // 
            // lb_HP
            // 
            this.lb_HP.AutoSize = true;
            this.lb_HP.Location = new System.Drawing.Point(27, 23);
            this.lb_HP.Name = "lb_HP";
            this.lb_HP.Size = new System.Drawing.Size(35, 13);
            this.lb_HP.TabIndex = 5;
            this.lb_HP.Text = "label6";
            // 
            // tb_Attackdistance
            // 
            this.tb_Attackdistance.Location = new System.Drawing.Point(283, 48);
            this.tb_Attackdistance.Name = "tb_Attackdistance";
            this.tb_Attackdistance.Size = new System.Drawing.Size(39, 20);
            this.tb_Attackdistance.TabIndex = 7;
            this.tb_Attackdistance.Text = "900";
            this.tb_Attackdistance.TextChanged += new System.EventHandler(this.tb_Attackdistance_TextChanged);
            // 
            // cb_Attack
            // 
            this.cb_Attack.AutoSize = true;
            this.cb_Attack.Location = new System.Drawing.Point(229, 51);
            this.cb_Attack.Name = "cb_Attack";
            this.cb_Attack.Size = new System.Drawing.Size(57, 17);
            this.cb_Attack.TabIndex = 8;
            this.cb_Attack.Text = "Attack";
            this.cb_Attack.UseVisualStyleBackColor = true;
            this.cb_Attack.CheckedChanged += new System.EventHandler(this.cb_Attack_CheckedChanged);
            // 
            // cb_Shift
            // 
            this.cb_Shift.AutoSize = true;
            this.cb_Shift.Location = new System.Drawing.Point(229, 35);
            this.cb_Shift.Name = "cb_Shift";
            this.cb_Shift.Size = new System.Drawing.Size(47, 17);
            this.cb_Shift.TabIndex = 9;
            this.cb_Shift.Text = "Shift";
            this.cb_Shift.UseVisualStyleBackColor = true;
            this.cb_Shift.CheckedChanged += new System.EventHandler(this.cb_Shift_CheckedChanged);
            // 
            // bt_Buffs
            // 
            this.bt_Buffs.Location = new System.Drawing.Point(110, 4);
            this.bt_Buffs.Name = "bt_Buffs";
            this.bt_Buffs.Size = new System.Drawing.Size(51, 23);
            this.bt_Buffs.TabIndex = 10;
            this.bt_Buffs.Text = "Dances";
            this.bt_Buffs.UseVisualStyleBackColor = true;
            this.bt_Buffs.Click += new System.EventHandler(this.bt_Buffs_Click);
            // 
            // bt_Skills
            // 
            this.bt_Skills.Location = new System.Drawing.Point(167, 4);
            this.bt_Skills.Name = "bt_Skills";
            this.bt_Skills.Size = new System.Drawing.Size(51, 23);
            this.bt_Skills.TabIndex = 11;
            this.bt_Skills.Text = "Skills";
            this.bt_Skills.UseVisualStyleBackColor = true;
            this.bt_Skills.Click += new System.EventHandler(this.bt_Skills_Click);
            // 
            // bt_Party
            // 
            this.bt_Party.Location = new System.Drawing.Point(110, 46);
            this.bt_Party.Name = "bt_Party";
            this.bt_Party.Size = new System.Drawing.Size(51, 23);
            this.bt_Party.TabIndex = 12;
            this.bt_Party.Text = "Buffs";
            this.bt_Party.UseVisualStyleBackColor = true;
            this.bt_Party.Click += new System.EventHandler(this.bt_Party_Click);
            // 
            // bt_Defense
            // 
            this.bt_Defense.Location = new System.Drawing.Point(110, 25);
            this.bt_Defense.Name = "bt_Defense";
            this.bt_Defense.Size = new System.Drawing.Size(51, 23);
            this.bt_Defense.TabIndex = 13;
            this.bt_Defense.Text = "Defense";
            this.bt_Defense.UseVisualStyleBackColor = true;
            this.bt_Defense.Click += new System.EventHandler(this.bt_Defense_Click);
            // 
            // bt_logout
            // 
            this.bt_logout.Location = new System.Drawing.Point(697, 3);
            this.bt_logout.Name = "bt_logout";
            this.bt_logout.Size = new System.Drawing.Size(23, 23);
            this.bt_logout.TabIndex = 16;
            this.bt_logout.Text = "X";
            this.bt_logout.UseVisualStyleBackColor = true;
            this.bt_logout.Click += new System.EventHandler(this.bt_logout_Click);
            // 
            // bt_Leader
            // 
            this.bt_Leader.Location = new System.Drawing.Point(697, 35);
            this.bt_Leader.Name = "bt_Leader";
            this.bt_Leader.Size = new System.Drawing.Size(23, 23);
            this.bt_Leader.TabIndex = 17;
            this.bt_Leader.Text = "L";
            this.bt_Leader.UseVisualStyleBackColor = true;
            this.bt_Leader.Click += new System.EventHandler(this.bt_Leader_Click);
            // 
            // bskills
            // 
            this.bskills.AutoSize = true;
            this.bskills.Location = new System.Drawing.Point(229, 3);
            this.bskills.Name = "bskills";
            this.bskills.Size = new System.Drawing.Size(72, 17);
            this.bskills.TabIndex = 18;
            this.bskills.Text = "Use Skills";
            this.bskills.UseVisualStyleBackColor = true;
            this.bskills.CheckedChanged += new System.EventHandler(this.bskills_CheckedChanged);
            // 
            // bdefend
            // 
            this.bdefend.AutoSize = true;
            this.bdefend.Location = new System.Drawing.Point(229, 19);
            this.bdefend.Name = "bdefend";
            this.bdefend.Size = new System.Drawing.Size(61, 17);
            this.bdefend.TabIndex = 19;
            this.bdefend.Text = "Defend";
            this.bdefend.UseVisualStyleBackColor = true;
            this.bdefend.CheckedChanged += new System.EventHandler(this.bdefend_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(626, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Blessing";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // shotbox
            // 
            this.shotbox.FormattingEnabled = true;
            this.shotbox.Location = new System.Drawing.Point(604, 49);
            this.shotbox.Name = "shotbox";
            this.shotbox.Size = new System.Drawing.Size(87, 21);
            this.shotbox.TabIndex = 21;
            this.shotbox.SelectedIndexChanged += new System.EventHandler(this.shotbox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Shots";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(304, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 17);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "Auto Follow";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(304, 24);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 17);
            this.checkBox3.TabIndex = 24;
            this.checkBox3.Text = "Auto Talk";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(391, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 20);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "100";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(391, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(39, 20);
            this.textBox2.TabIndex = 26;
            this.textBox2.Text = "1";
            // 
            // rebuff
            // 
            this.rebuff.Location = new System.Drawing.Point(333, 45);
            this.rebuff.Name = "rebuff";
            this.rebuff.Size = new System.Drawing.Size(23, 23);
            this.rebuff.TabIndex = 27;
            this.rebuff.Text = "R";
            this.rebuff.UseVisualStyleBackColor = true;
            this.rebuff.Click += new System.EventHandler(this.rebuff_Click);
            // 
            // itbtn
            // 
            this.itbtn.Location = new System.Drawing.Point(362, 45);
            this.itbtn.Name = "itbtn";
            this.itbtn.Size = new System.Drawing.Size(23, 23);
            this.itbtn.TabIndex = 28;
            this.itbtn.Text = "I";
            this.itbtn.UseVisualStyleBackColor = true;
            this.itbtn.Click += new System.EventHandler(this.itbtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Items";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "F Buffs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.itbtn);
            this.Controls.Add(this.rebuff);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shotbox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bdefend);
            this.Controls.Add(this.bskills);
            this.Controls.Add(this.bt_Leader);
            this.Controls.Add(this.bt_logout);
            this.Controls.Add(this.bt_Defense);
            this.Controls.Add(this.bt_Party);
            this.Controls.Add(this.bt_Skills);
            this.Controls.Add(this.bt_Buffs);
            this.Controls.Add(this.cb_Shift);
            this.Controls.Add(this.cb_Attack);
            this.Controls.Add(this.tb_Attackdistance);
            this.Controls.Add(this.lb_CP);
            this.Controls.Add(this.lb_HP);
            this.Controls.Add(this.lb_CPMAX);
            this.Controls.Add(this.lb_HPMAX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_name);
            this.Name = "ClientView";
            this.Size = new System.Drawing.Size(725, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lb_name;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lb_CPMAX;
        public System.Windows.Forms.Label lb_HPMAX;
        public System.Windows.Forms.Label lb_CP;
        public System.Windows.Forms.Label lb_HP;
        public System.Windows.Forms.TextBox tb_Attackdistance;
        public System.Windows.Forms.CheckBox cb_Attack;
        public System.Windows.Forms.CheckBox cb_Shift;
        public System.Windows.Forms.Button bt_Buffs;
        public System.Windows.Forms.Button bt_Skills;
        public System.Windows.Forms.Button bt_Party;
        public System.Windows.Forms.Button bt_Defense;
        public System.Windows.Forms.Button bt_logout;
        public System.Windows.Forms.Button bt_Leader;
        public System.Windows.Forms.CheckBox bskills;
        public System.Windows.Forms.CheckBox bdefend;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox shotbox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox3;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Button rebuff;
        public System.Windows.Forms.Button itbtn;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;

    }
}
