namespace l2pvp
{
    partial class BotView
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pdistance = new System.Windows.Forms.ColumnHeader();
            this.pname = new System.Windows.Forms.ColumnHeader();
            this.pclan = new System.Windows.Forms.ColumnHeader();
            this.pid = new System.Windows.Forms.ColumnHeader();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.checkBox33 = new System.Windows.Forms.CheckBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.cb_Elixirs = new System.Windows.Forms.CheckBox();
            this.cb_HPpots = new System.Windows.Forms.CheckBox();
            this.cb_CPpots = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lb_targetname = new System.Windows.Forms.Label();
            this.targethp = new System.Windows.Forms.Label();
            this.targetmaxhp = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pdistance,
            this.pname,
            this.pclan,
            this.pid});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(845, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(323, 613);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // pdistance
            // 
            this.pdistance.Text = "Distance";
            this.pdistance.Width = 88;
            // 
            // pname
            // 
            this.pname.Text = "Player Name";
            this.pname.Width = 139;
            // 
            // pclan
            // 
            this.pclan.Text = "Clan";
            this.pclan.Width = 89;
            // 
            // pid
            // 
            this.pid.Text = "ID";
            this.pid.Width = 0;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Checked = true;
            this.checkBox22.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox22.Location = new System.Drawing.Point(845, 631);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(311, 17);
            this.checkBox22.TabIndex = 17;
            this.checkBox22.Text = "Update Distances (Important not to uncheck this during pvp)";
            this.checkBox22.UseVisualStyleBackColor = true;
            this.checkBox22.CheckedChanged += new System.EventHandler(this.checkBox22_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(827, 768);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 23);
            this.button4.TabIndex = 56;
            this.button4.Text = "Load";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(769, 768);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 23);
            this.button3.TabIndex = 55;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(769, 747);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 20);
            this.textBox15.TabIndex = 54;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(706, 759);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(57, 20);
            this.textBox12.TabIndex = 53;
            this.textBox12.Text = "2000";
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(643, 759);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(57, 20);
            this.textBox14.TabIndex = 52;
            this.textBox14.Text = "1000";
            this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(643, 738);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(57, 20);
            this.textBox13.TabIndex = 51;
            this.textBox13.Text = "400";
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(376, 755);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(83, 13);
            this.label54.TabIndex = 50;
            this.label54.Text = "Attack Distance";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(379, 774);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(73, 20);
            this.textBox11.TabIndex = 49;
            this.textBox11.Text = "1200";
            this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // checkBox33
            // 
            this.checkBox33.AutoSize = true;
            this.checkBox33.Location = new System.Drawing.Point(470, 751);
            this.checkBox33.Name = "checkBox33";
            this.checkBox33.Size = new System.Drawing.Size(95, 17);
            this.checkBox33.TabIndex = 48;
            this.checkBox33.Text = "Main Targetter";
            this.checkBox33.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(470, 774);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 20);
            this.textBox10.TabIndex = 47;
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(208, 776);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(165, 17);
            this.checkBox23.TabIndex = 46;
            this.checkBox23.Text = "Follow Player 1 (experimental)";
            this.checkBox23.UseVisualStyleBackColor = true;
            this.checkBox23.CheckedChanged += new System.EventHandler(this.checkBox23_CheckedChanged);
            // 
            // cb_Elixirs
            // 
            this.cb_Elixirs.AutoSize = true;
            this.cb_Elixirs.Checked = true;
            this.cb_Elixirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Elixirs.Location = new System.Drawing.Point(576, 763);
            this.cb_Elixirs.Name = "cb_Elixirs";
            this.cb_Elixirs.Size = new System.Drawing.Size(52, 17);
            this.cb_Elixirs.TabIndex = 45;
            this.cb_Elixirs.Text = "Elixirs";
            this.cb_Elixirs.UseVisualStyleBackColor = true;
            this.cb_Elixirs.CheckedChanged += new System.EventHandler(this.cb_Elixirs_CheckedChanged);
            // 
            // cb_HPpots
            // 
            this.cb_HPpots.AutoSize = true;
            this.cb_HPpots.Checked = true;
            this.cb_HPpots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_HPpots.Location = new System.Drawing.Point(576, 743);
            this.cb_HPpots.Name = "cb_HPpots";
            this.cb_HPpots.Size = new System.Drawing.Size(61, 17);
            this.cb_HPpots.TabIndex = 44;
            this.cb_HPpots.Text = "hp pots";
            this.cb_HPpots.UseVisualStyleBackColor = true;
            this.cb_HPpots.CheckedChanged += new System.EventHandler(this.cb_HPpots_CheckedChanged);
            // 
            // cb_CPpots
            // 
            this.cb_CPpots.AutoSize = true;
            this.cb_CPpots.Checked = true;
            this.cb_CPpots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CPpots.Location = new System.Drawing.Point(576, 725);
            this.cb_CPpots.Name = "cb_CPpots";
            this.cb_CPpots.Size = new System.Drawing.Size(63, 17);
            this.cb_CPpots.TabIndex = 43;
            this.cb_CPpots.Text = "CP pots";
            this.cb_CPpots.UseVisualStyleBackColor = true;
            this.cb_CPpots.CheckedChanged += new System.EventHandler(this.cb_CPpots_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(885, 729);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 42;
            this.button2.Text = "Stop Attack";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(885, 758);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "Start Attack";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(966, 768);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Clans: Check if you want to kill them";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(968, 654);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(200, 109);
            this.checkedListBox1.Sorted = true;
            this.checkedListBox1.TabIndex = 39;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel.Location = new System.Drawing.Point(13, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(826, 711);
            this.panel.TabIndex = 57;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lb_targetname
            // 
            this.lb_targetname.AutoSize = true;
            this.lb_targetname.Location = new System.Drawing.Point(30, 747);
            this.lb_targetname.Name = "lb_targetname";
            this.lb_targetname.Size = new System.Drawing.Size(35, 13);
            this.lb_targetname.TabIndex = 58;
            this.lb_targetname.Text = "label2";
            // 
            // targethp
            // 
            this.targethp.AutoSize = true;
            this.targethp.Location = new System.Drawing.Point(13, 774);
            this.targethp.Name = "targethp";
            this.targethp.Size = new System.Drawing.Size(35, 13);
            this.targethp.TabIndex = 59;
            this.targethp.Text = "label3";
            // 
            // targetmaxhp
            // 
            this.targetmaxhp.AutoSize = true;
            this.targetmaxhp.Location = new System.Drawing.Point(54, 774);
            this.targetmaxhp.Name = "targetmaxhp";
            this.targetmaxhp.Size = new System.Drawing.Size(35, 13);
            this.targetmaxhp.TabIndex = 60;
            this.targetmaxhp.Text = "label4";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(121, 743);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 17);
            this.checkBox1.TabIndex = 61;
            this.checkBox1.Text = "Flag Fight";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(121, 772);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(70, 17);
            this.checkBox2.TabIndex = 62;
            this.checkBox2.Text = "Kill 2 way";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(208, 743);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(100, 17);
            this.checkBox3.TabIndex = 63;
            this.checkBox3.Text = "Bsoe at 50% cp";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(576, 782);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(49, 17);
            this.checkBox4.TabIndex = 64;
            this.checkBox4.Text = "QHP";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(643, 779);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 20);
            this.textBox1.TabIndex = 65;
            this.textBox1.Text = "2500";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1180, 806);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.targetmaxhp);
            this.Controls.Add(this.targethp);
            this.Controls.Add(this.lb_targetname);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.checkBox33);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.checkBox23);
            this.Controls.Add(this.cb_Elixirs);
            this.Controls.Add(this.cb_HPpots);
            this.Controls.Add(this.cb_CPpots);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.checkBox22);
            this.Controls.Add(this.listView1);
            this.Name = "BotView";
            this.Text = "BotView";
            this.Load += new System.EventHandler(this.BotView_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BotView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader pid;
        private System.Windows.Forms.ColumnHeader pname;
        private System.Windows.Forms.ColumnHeader pclan;
        private System.Windows.Forms.ColumnHeader pdistance;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.CheckBox checkBox33;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox cb_Elixirs;
        private System.Windows.Forms.CheckBox cb_HPpots;
        private System.Windows.Forms.CheckBox cb_CPpots;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lb_targetname;
        private System.Windows.Forms.Label targethp;
        private System.Windows.Forms.Label targetmaxhp;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox1;
    }
}