namespace Tasker
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dgTasks = new System.Windows.Forms.DataGridView();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTimeType = new System.Windows.Forms.ComboBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbMonth = new System.Windows.Forms.TextBox();
            this.tbDay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHour = new System.Windows.Forms.TextBox();
            this.tbSecond = new System.Windows.Forms.TextBox();
            this.tbMinute = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRegBegin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.tbRegEnd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnClearTime = new System.Windows.Forms.Button();
            this.tbTips = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbEncoding = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnUpDown = new System.Windows.Forms.Button();
            this.btnDoItNow = new System.Windows.Forms.Button();
            this.cbDebug = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.tbData = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbWeek = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDel = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasks)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "玲娜贝儿";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 36);
            this.contextMenuStrip1.SizeChanged += new System.EventHandler(this.contextMenuStrip1_SizeChanged);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(126, 32);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(16, 626);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(112, 34);
            this.btnAddTask.TabIndex = 16;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // dgTasks
            // 
            this.dgTasks.AllowUserToAddRows = false;
            this.dgTasks.AllowUserToDeleteRows = false;
            this.dgTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTasks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.dgTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasks.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTasks.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgTasks.EnableHeadersVisualStyles = false;
            this.dgTasks.GridColor = System.Drawing.Color.White;
            this.dgTasks.Location = new System.Drawing.Point(16, 18);
            this.dgTasks.Margin = new System.Windows.Forms.Padding(4);
            this.dgTasks.MultiSelect = false;
            this.dgTasks.Name = "dgTasks";
            this.dgTasks.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTasks.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgTasks.RowHeadersVisible = false;
            this.dgTasks.RowHeadersWidth = 62;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.dgTasks.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgTasks.RowTemplate.Height = 23;
            this.dgTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTasks.Size = new System.Drawing.Size(1605, 430);
            this.dgTasks.TabIndex = 22;
            this.dgTasks.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTasks_CellMouseDown);
            this.dgTasks.DoubleClick += new System.EventHandler(this.dgTasks_DoubleClick);
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "WebTask",
            "TipsTask",
            "ExeTask"});
            this.cbType.Location = new System.Drawing.Point(76, 462);
            this.cbType.Margin = new System.Windows.Forms.Padding(4);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(103, 26);
            this.cbType.TabIndex = 0;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(16, 468);
            this.lable1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(62, 18);
            this.lable1.TabIndex = 23;
            this.lable1.Text = "类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 468);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "时间：";
            // 
            // cbTimeType
            // 
            this.cbTimeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeType.FormattingEnabled = true;
            this.cbTimeType.Items.AddRange(new object[] {
            "EveryDay",
            "EveryWeek",
            "EveryMonth",
            "Sometimes"});
            this.cbTimeType.Location = new System.Drawing.Point(249, 462);
            this.cbTimeType.Margin = new System.Windows.Forms.Padding(4);
            this.cbTimeType.Name = "cbTimeType";
            this.cbTimeType.Size = new System.Drawing.Size(103, 26);
            this.cbTimeType.TabIndex = 1;
            this.cbTimeType.SelectedIndexChanged += new System.EventHandler(this.cbTimeType_SelectedIndexChanged);
            // 
            // tbYear
            // 
            this.tbYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbYear.Location = new System.Drawing.Point(357, 462);
            this.tbYear.Margin = new System.Windows.Forms.Padding(4);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(46, 28);
            this.tbYear.TabIndex = 2;
            this.tbYear.Text = "2013";
            // 
            // tbMonth
            // 
            this.tbMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbMonth.Location = new System.Drawing.Point(413, 462);
            this.tbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.tbMonth.Name = "tbMonth";
            this.tbMonth.Size = new System.Drawing.Size(25, 28);
            this.tbMonth.TabIndex = 3;
            this.tbMonth.Text = "06";
            // 
            // tbDay
            // 
            this.tbDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbDay.Location = new System.Drawing.Point(448, 462);
            this.tbDay.Margin = new System.Windows.Forms.Padding(4);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(25, 28);
            this.tbDay.TabIndex = 4;
            this.tbDay.Text = "14";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 468);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 468);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "/";
            // 
            // tbHour
            // 
            this.tbHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbHour.Location = new System.Drawing.Point(560, 462);
            this.tbHour.Margin = new System.Windows.Forms.Padding(4);
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(25, 28);
            this.tbHour.TabIndex = 5;
            this.tbHour.Text = "14";
            // 
            // tbSecond
            // 
            this.tbSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbSecond.Location = new System.Drawing.Point(625, 462);
            this.tbSecond.Margin = new System.Windows.Forms.Padding(4);
            this.tbSecond.Name = "tbSecond";
            this.tbSecond.Size = new System.Drawing.Size(25, 28);
            this.tbSecond.TabIndex = 7;
            this.tbSecond.Text = "00";
            // 
            // tbMinute
            // 
            this.tbMinute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbMinute.Location = new System.Drawing.Point(593, 462);
            this.tbMinute.Margin = new System.Windows.Forms.Padding(4);
            this.tbMinute.Name = "tbMinute";
            this.tbMinute.Size = new System.Drawing.Size(25, 28);
            this.tbMinute.TabIndex = 6;
            this.tbMinute.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 467);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 467);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = ":";
            // 
            // btnAddTime
            // 
            this.btnAddTime.Location = new System.Drawing.Point(654, 459);
            this.btnAddTime.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(48, 34);
            this.btnAddTime.TabIndex = 8;
            this.btnAddTime.Text = "Add";
            this.btnAddTime.UseVisualStyleBackColor = true;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbTitle.Location = new System.Drawing.Point(76, 504);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(306, 28);
            this.tbTitle.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 552);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "URL：";
            // 
            // tbUrl
            // 
            this.tbUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbUrl.Location = new System.Drawing.Point(76, 544);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(4);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(306, 28);
            this.tbUrl.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 590);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "开始：";
            // 
            // tbRegBegin
            // 
            this.tbRegBegin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbRegBegin.Location = new System.Drawing.Point(76, 585);
            this.tbRegBegin.Margin = new System.Windows.Forms.Padding(4);
            this.tbRegBegin.Name = "tbRegBegin";
            this.tbRegBegin.Size = new System.Drawing.Size(306, 28);
            this.tbRegBegin.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(417, 590);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "结束：";
            // 
            // tbPreview
            // 
            this.tbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbPreview.Location = new System.Drawing.Point(1207, 486);
            this.tbPreview.Margin = new System.Windows.Forms.Padding(4);
            this.tbPreview.Multiline = true;
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPreview.Size = new System.Drawing.Size(414, 168);
            this.tbPreview.TabIndex = 21;
            // 
            // tbRegEnd
            // 
            this.tbRegEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbRegEnd.Location = new System.Drawing.Point(477, 585);
            this.tbRegEnd.Margin = new System.Windows.Forms.Padding(4);
            this.tbRegEnd.Name = "tbRegEnd";
            this.tbRegEnd.Size = new System.Drawing.Size(295, 28);
            this.tbRegEnd.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 508);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "Title：";
            // 
            // btnDelTask
            // 
            this.btnDelTask.Location = new System.Drawing.Point(138, 626);
            this.btnDelTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(57, 34);
            this.btnDelTask.TabIndex = 17;
            this.btnDelTask.Text = "Del";
            this.btnDelTask.UseVisualStyleBackColor = true;
            this.btnDelTask.Click += new System.EventHandler(this.btnDelTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.Location = new System.Drawing.Point(204, 626);
            this.btnEditTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(57, 34);
            this.btnEditTask.TabIndex = 18;
            this.btnEditTask.Text = "Edit";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnClearTime
            // 
            this.btnClearTime.Location = new System.Drawing.Point(706, 459);
            this.btnClearTime.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearTime.Name = "btnClearTime";
            this.btnClearTime.Size = new System.Drawing.Size(65, 34);
            this.btnClearTime.TabIndex = 9;
            this.btnClearTime.Text = "Clear";
            this.btnClearTime.UseVisualStyleBackColor = true;
            this.btnClearTime.Click += new System.EventHandler(this.btnClearTime_Click);
            // 
            // tbTips
            // 
            this.tbTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbTips.Location = new System.Drawing.Point(480, 504);
            this.tbTips.Margin = new System.Windows.Forms.Padding(4);
            this.tbTips.Name = "tbTips";
            this.tbTips.Size = new System.Drawing.Size(292, 28);
            this.tbTips.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 508);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 18);
            this.label10.TabIndex = 30;
            this.label10.Text = "Tips/Arg：";
            // 
            // tbEncoding
            // 
            this.tbEncoding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbEncoding.Location = new System.Drawing.Point(677, 544);
            this.tbEncoding.Margin = new System.Windows.Forms.Padding(4);
            this.tbEncoding.Name = "tbEncoding";
            this.tbEncoding.Size = new System.Drawing.Size(95, 28);
            this.tbEncoding.TabIndex = 13;
            this.tbEncoding.Text = "GB2312";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(599, 549);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 32;
            this.label11.Text = "Encode：";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbLog.Location = new System.Drawing.Point(16, 668);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(1605, 195);
            this.tbLog.TabIndex = 27;
            // 
            // btnUpDown
            // 
            this.btnUpDown.Location = new System.Drawing.Point(393, 626);
            this.btnUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpDown.Name = "btnUpDown";
            this.btnUpDown.Size = new System.Drawing.Size(28, 34);
            this.btnUpDown.TabIndex = 20;
            this.btnUpDown.Text = "↓";
            this.btnUpDown.UseVisualStyleBackColor = true;
            this.btnUpDown.Click += new System.EventHandler(this.btnUpDown_Click);
            // 
            // btnDoItNow
            // 
            this.btnDoItNow.Location = new System.Drawing.Point(272, 626);
            this.btnDoItNow.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoItNow.Name = "btnDoItNow";
            this.btnDoItNow.Size = new System.Drawing.Size(112, 34);
            this.btnDoItNow.TabIndex = 35;
            this.btnDoItNow.Text = "Do It Now";
            this.btnDoItNow.UseVisualStyleBackColor = true;
            this.btnDoItNow.Click += new System.EventHandler(this.btnDoItNow_Click);
            // 
            // cbDebug
            // 
            this.cbDebug.AutoSize = true;
            this.cbDebug.Checked = true;
            this.cbDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDebug.Location = new System.Drawing.Point(432, 632);
            this.cbDebug.Margin = new System.Windows.Forms.Padding(4);
            this.cbDebug.Name = "cbDebug";
            this.cbDebug.Size = new System.Drawing.Size(124, 22);
            this.cbDebug.TabIndex = 36;
            this.cbDebug.Text = "Debug Mode";
            this.cbDebug.UseVisualStyleBackColor = true;
            this.cbDebug.CheckedChanged += new System.EventHandler(this.cbDebug_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(399, 549);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 38;
            this.label12.Text = "Method：";
            // 
            // cbMethod
            // 
            this.cbMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.cbMethod.Location = new System.Drawing.Point(477, 546);
            this.cbMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(103, 26);
            this.cbMethod.TabIndex = 39;
            // 
            // tbData
            // 
            this.tbData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tbData.Location = new System.Drawing.Point(782, 486);
            this.tbData.Margin = new System.Windows.Forms.Padding(4);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbData.Size = new System.Drawing.Size(414, 168);
            this.tbData.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(780, 459);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "Post Data：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1204, 459);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 18);
            this.label14.TabIndex = 38;
            this.label14.Text = "Preview：";
            // 
            // cbWeek
            // 
            this.cbWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeek.FormattingEnabled = true;
            this.cbWeek.Items.AddRange(new object[] {
            "Mon",
            "Tues",
            "Wed",
            "Thur",
            "Fri",
            "Sat",
            "Sun"});
            this.cbWeek.Location = new System.Drawing.Point(475, 462);
            this.cbWeek.Margin = new System.Windows.Forms.Padding(4);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(82, 26);
            this.cbWeek.TabIndex = 1;
            this.cbWeek.SelectedIndexChanged += new System.EventHandler(this.cbTimeType_SelectedIndexChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEdit,
            this.tsDel});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(123, 68);
            // 
            // tsEdit
            // 
            this.tsEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsEdit.Image")));
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(122, 32);
            this.tsEdit.Text = "Edit";
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
            // 
            // tsDel
            // 
            this.tsDel.Image = ((System.Drawing.Image)(resources.GetObject("tsDel.Image")));
            this.tsDel.Name = "tsDel";
            this.tsDel.Size = new System.Drawing.Size(122, 32);
            this.tsDel.Text = "Del";
            this.tsDel.Click += new System.EventHandler(this.tsDel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1634, 666);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbDebug);
            this.Controls.Add(this.btnDoItNow);
            this.Controls.Add(this.btnUpDown);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.tbEncoding);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnDelTask);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbRegEnd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbPreview);
            this.Controls.Add(this.tbRegBegin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTips);
            this.Controls.Add(this.btnAddTime);
            this.Controls.Add(this.btnClearTime);
            this.Controls.Add(this.tbMinute);
            this.Controls.Add(this.tbSecond);
            this.Controls.Add(this.tbHour);
            this.Controls.Add(this.tbDay);
            this.Controls.Add(this.tbMonth);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.cbWeek);
            this.Controls.Add(this.cbTimeType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.dgTasks);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "玲娜贝儿营业中……";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTasks)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dgTasks;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTimeType;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbMonth;
        private System.Windows.Forms.TextBox tbDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHour;
        private System.Windows.Forms.TextBox tbSecond;
        private System.Windows.Forms.TextBox tbMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRegBegin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.TextBox tbRegEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDelTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnClearTime;
        private System.Windows.Forms.TextBox tbTips;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbEncoding;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnUpDown;
        private System.Windows.Forms.Button btnDoItNow;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbWeek;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsEdit;
        private System.Windows.Forms.ToolStripMenuItem tsDel;
    }
}

