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
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CP";
            // 
            // lb_CPMAX
            // 
            this.lb_CPMAX.AutoSize = true;
            this.lb_CPMAX.Location = new System.Drawing.Point(86, 45);
            this.lb_CPMAX.Name = "lb_CPMAX";
            this.lb_CPMAX.Size = new System.Drawing.Size(35, 13);
            this.lb_CPMAX.TabIndex = 4;
            this.lb_CPMAX.Text = "label3";
            // 
            // lb_HPMAX
            // 
            this.lb_HPMAX.AutoSize = true;
            this.lb_HPMAX.Location = new System.Drawing.Point(86, 23);
            this.lb_HPMAX.Name = "lb_HPMAX";
            this.lb_HPMAX.Size = new System.Drawing.Size(35, 13);
            this.lb_HPMAX.TabIndex = 3;
            this.lb_HPMAX.Text = "label4";
            // 
            // lb_CP
            // 
            this.lb_CP.AutoSize = true;
            this.lb_CP.Location = new System.Drawing.Point(45, 45);
            this.lb_CP.Name = "lb_CP";
            this.lb_CP.Size = new System.Drawing.Size(35, 13);
            this.lb_CP.TabIndex = 6;
            this.lb_CP.Text = "label5";
            // 
            // lb_HP
            // 
            this.lb_HP.AutoSize = true;
            this.lb_HP.Location = new System.Drawing.Point(45, 23);
            this.lb_HP.Name = "lb_HP";
            this.lb_HP.Size = new System.Drawing.Size(35, 13);
            this.lb_HP.TabIndex = 5;
            this.lb_HP.Text = "label6";
            // 
            // tb_Attackdistance
            // 
            this.tb_Attackdistance.Location = new System.Drawing.Point(464, 35);
            this.tb_Attackdistance.Name = "tb_Attackdistance";
            this.tb_Attackdistance.Size = new System.Drawing.Size(76, 20);
            this.tb_Attackdistance.TabIndex = 7;
            this.tb_Attackdistance.Text = "900";
            this.tb_Attackdistance.TextChanged += new System.EventHandler(this.tb_Attackdistance_TextChanged);
            // 
            // cb_Attack
            // 
            this.cb_Attack.AutoSize = true;
            this.cb_Attack.Location = new System.Drawing.Point(513, 12);
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
            this.cb_Shift.Location = new System.Drawing.Point(450, 12);
            this.cb_Shift.Name = "cb_Shift";
            this.cb_Shift.Size = new System.Drawing.Size(47, 17);
            this.cb_Shift.TabIndex = 9;
            this.cb_Shift.Text = "Shift";
            this.cb_Shift.UseVisualStyleBackColor = true;
            this.cb_Shift.CheckedChanged += new System.EventHandler(this.cb_Shift_CheckedChanged);
            // 
            // bt_Buffs
            // 
            this.bt_Buffs.Location = new System.Drawing.Point(250, 3);
            this.bt_Buffs.Name = "bt_Buffs";
            this.bt_Buffs.Size = new System.Drawing.Size(75, 23);
            this.bt_Buffs.TabIndex = 10;
            this.bt_Buffs.Text = "Buffs";
            this.bt_Buffs.UseVisualStyleBackColor = true;
            this.bt_Buffs.Click += new System.EventHandler(this.bt_Buffs_Click);
            // 
            // bt_Skills
            // 
            this.bt_Skills.Location = new System.Drawing.Point(355, 35);
            this.bt_Skills.Name = "bt_Skills";
            this.bt_Skills.Size = new System.Drawing.Size(75, 23);
            this.bt_Skills.TabIndex = 11;
            this.bt_Skills.Text = "Skills";
            this.bt_Skills.UseVisualStyleBackColor = true;
            this.bt_Skills.Click += new System.EventHandler(this.bt_Skills_Click);
            // 
            // bt_Party
            // 
            this.bt_Party.Location = new System.Drawing.Point(250, 35);
            this.bt_Party.Name = "bt_Party";
            this.bt_Party.Size = new System.Drawing.Size(75, 23);
            this.bt_Party.TabIndex = 12;
            this.bt_Party.Text = "Party";
            this.bt_Party.UseVisualStyleBackColor = true;
            this.bt_Party.Click += new System.EventHandler(this.bt_Party_Click);
            // 
            // bt_Defense
            // 
            this.bt_Defense.Location = new System.Drawing.Point(149, 35);
            this.bt_Defense.Name = "bt_Defense";
            this.bt_Defense.Size = new System.Drawing.Size(75, 23);
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
            this.bskills.Location = new System.Drawing.Point(358, 12);
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
            this.bdefend.Location = new System.Drawing.Point(152, 12);
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
            this.shotbox.Location = new System.Drawing.Point(570, 49);
            this.shotbox.Name = "shotbox";
            this.shotbox.Size = new System.Drawing.Size(121, 21);
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
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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

    }
}
