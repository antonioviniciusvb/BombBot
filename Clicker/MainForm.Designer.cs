namespace Clicker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lvActions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TaskChekError = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNextAtt = new System.Windows.Forms.Label();
            this.rdCheckHeroesOn = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rdCheckHeroesOff = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.nCheckWorkHeroes = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdLoopOn = new System.Windows.Forms.RadioButton();
            this.nTimeLoop = new System.Windows.Forms.NumericUpDown();
            this.rdLoopOff = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nWait = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.txbEntry = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtSimilarityThreshold = new System.Windows.Forms.TextBox();
            this.pcbImages = new System.Windows.Forms.PictureBox();
            this.cmbImages = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.nSearchZoneH = new System.Windows.Forms.NumericUpDown();
            this.nSearchZoneW = new System.Windows.Forms.NumericUpDown();
            this.nSearchZoneY = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.nSearchZoneX = new System.Windows.Forms.NumericUpDown();
            this.nPsY = new System.Windows.Forms.NumericUpDown();
            this.nPsX = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.TaskWorkHeroes = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCheckWorkHeroes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTimeLoop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWait)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPsY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPsX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnCancel.Location = new System.Drawing.Point(1219, 676);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnStart.Location = new System.Drawing.Point(1139, 676);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(69, 28);
            this.btnStart.TabIndex = 1;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(1191, 4);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 28);
            this.btnClear.TabIndex = 3;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear all";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lvActions
            // 
            this.lvActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvActions.ContextMenuStrip = this.contextMenuStrip1;
            this.lvActions.FullRowSelect = true;
            this.lvActions.HideSelection = false;
            this.lvActions.Location = new System.Drawing.Point(459, 5);
            this.lvActions.Margin = new System.Windows.Forms.Padding(4);
            this.lvActions.Name = "lvActions";
            this.lvActions.Size = new System.Drawing.Size(671, 698);
            this.lvActions.TabIndex = 4;
            this.lvActions.TabStop = false;
            this.lvActions.UseCompatibleStateImageBehavior = false;
            this.lvActions.View = System.Windows.Forms.View.Details;
            this.lvActions.DoubleClick += new System.EventHandler(this.lvActions_DoubleClick);
            this.lvActions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvActions_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Point";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Click";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Wait";
            this.columnHeader3.Width = 39;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data";
            this.columnHeader4.Width = 190;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 52);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(376, 676);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 28);
            this.btnSave.TabIndex = 45;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(299, 676);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(69, 28);
            this.btnOpen.TabIndex = 44;
            this.btnOpen.TabStop = false;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(187, 688);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 46;
            this.label7.Text = "Configuration";
            // 
            // timer1
            // 
            this.timer1.Interval = 600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TaskChekError
            // 
            this.TaskChekError.Interval = 120000;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(7, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1307, 746);
            this.tabControl1.TabIndex = 56;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1299, 717);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(452, 23);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(816, 686);
            this.textBox1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblNextAtt);
            this.groupBox2.Controls.Add(this.rdCheckHeroesOn);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.rdCheckHeroesOff);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.nCheckWorkHeroes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(41, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(328, 214);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enviar Heros para Trabalhar";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(245, 106);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 8;
            this.label13.Text = "minutos";
            // 
            // lblNextAtt
            // 
            this.lblNextAtt.AutoSize = true;
            this.lblNextAtt.Location = new System.Drawing.Point(191, 178);
            this.lblNextAtt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextAtt.Name = "lblNextAtt";
            this.lblNextAtt.Size = new System.Drawing.Size(50, 20);
            this.lblNextAtt.TabIndex = 4;
            this.lblNextAtt.Text = "00:00";
            // 
            // rdCheckHeroesOn
            // 
            this.rdCheckHeroesOn.AutoSize = true;
            this.rdCheckHeroesOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCheckHeroesOn.Location = new System.Drawing.Point(197, 43);
            this.rdCheckHeroesOn.Margin = new System.Windows.Forms.Padding(4);
            this.rdCheckHeroesOn.Name = "rdCheckHeroesOn";
            this.rdCheckHeroesOn.Size = new System.Drawing.Size(52, 24);
            this.rdCheckHeroesOn.TabIndex = 7;
            this.rdCheckHeroesOn.TabStop = true;
            this.rdCheckHeroesOn.Text = "On";
            this.rdCheckHeroesOn.UseVisualStyleBackColor = true;
            this.rdCheckHeroesOn.CheckedChanged += new System.EventHandler(this.rdCheckHeroesOn_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 178);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Próxima Atualização:";
            // 
            // rdCheckHeroesOff
            // 
            this.rdCheckHeroesOff.AutoSize = true;
            this.rdCheckHeroesOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdCheckHeroesOff.Location = new System.Drawing.Point(105, 43);
            this.rdCheckHeroesOff.Margin = new System.Windows.Forms.Padding(4);
            this.rdCheckHeroesOff.Name = "rdCheckHeroesOff";
            this.rdCheckHeroesOff.Size = new System.Drawing.Size(53, 24);
            this.rdCheckHeroesOff.TabIndex = 7;
            this.rdCheckHeroesOff.TabStop = true;
            this.rdCheckHeroesOff.Text = "Off";
            this.rdCheckHeroesOff.UseVisualStyleBackColor = true;
            this.rdCheckHeroesOff.CheckedChanged += new System.EventHandler(this.rdCheckHeroesOff_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 105);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "Verificar a cada";
            // 
            // nCheckWorkHeroes
            // 
            this.nCheckWorkHeroes.Location = new System.Drawing.Point(145, 101);
            this.nCheckWorkHeroes.Margin = new System.Windows.Forms.Padding(4);
            this.nCheckWorkHeroes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nCheckWorkHeroes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCheckWorkHeroes.Name = "nCheckWorkHeroes";
            this.nCheckWorkHeroes.Size = new System.Drawing.Size(97, 26);
            this.nCheckWorkHeroes.TabIndex = 5;
            this.nCheckWorkHeroes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nCheckWorkHeroes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nCheckWorkHeroes.ValueChanged += new System.EventHandler(this.nCheckWorkHeroes_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.lvActions);
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnOpen);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.nWait);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.linkLabel);
            this.tabPage2.Controls.Add(this.txbEntry);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1299, 717);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Clicks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(8, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 61;
            this.label3.Text = "Press \'S\' to Start";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(8, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 58;
            this.label4.Text = "Press \'c\' to left click";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdLoopOn);
            this.groupBox1.Controls.Add(this.nTimeLoop);
            this.groupBox1.Controls.Add(this.rdLoopOff);
            this.groupBox1.Location = new System.Drawing.Point(215, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(232, 85);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loop (mts)";
            // 
            // rdLoopOn
            // 
            this.rdLoopOn.AutoSize = true;
            this.rdLoopOn.Location = new System.Drawing.Point(12, 50);
            this.rdLoopOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdLoopOn.Name = "rdLoopOn";
            this.rdLoopOn.Size = new System.Drawing.Size(48, 21);
            this.rdLoopOn.TabIndex = 55;
            this.rdLoopOn.Text = "On";
            this.rdLoopOn.UseVisualStyleBackColor = true;
            // 
            // nTimeLoop
            // 
            this.nTimeLoop.Location = new System.Drawing.Point(84, 38);
            this.nTimeLoop.Margin = new System.Windows.Forms.Padding(4);
            this.nTimeLoop.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nTimeLoop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTimeLoop.Name = "nTimeLoop";
            this.nTimeLoop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nTimeLoop.Size = new System.Drawing.Size(141, 22);
            this.nTimeLoop.TabIndex = 52;
            this.nTimeLoop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // rdLoopOff
            // 
            this.rdLoopOff.AutoSize = true;
            this.rdLoopOff.Checked = true;
            this.rdLoopOff.Location = new System.Drawing.Point(12, 27);
            this.rdLoopOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdLoopOff.Name = "rdLoopOff";
            this.rdLoopOff.Size = new System.Drawing.Size(48, 21);
            this.rdLoopOff.TabIndex = 54;
            this.rdLoopOff.TabStop = true;
            this.rdLoopOff.Text = "Off";
            this.rdLoopOff.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Press \'r\' to right click";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(8, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 17);
            this.label10.TabIndex = 67;
            this.label10.Text = "Press \'m\' to MouseWheel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(8, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 17);
            this.label5.TabIndex = 62;
            this.label5.Text = "Press Esc to Cancel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Press \'d\' to double click";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(220, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "Wait (sec)";
            // 
            // nWait
            // 
            this.nWait.Location = new System.Drawing.Point(301, 50);
            this.nWait.Margin = new System.Windows.Forms.Padding(4);
            this.nWait.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nWait.Name = "nWait";
            this.nWait.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nWait.Size = new System.Drawing.Size(144, 22);
            this.nWait.TabIndex = 56;
            this.nWait.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(220, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 65;
            this.label9.Text = "Add text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(8, 85);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 17);
            this.label6.TabIndex = 63;
            this.label6.Text = "Press \'t\' to SendKey";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(8, 188);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(108, 17);
            this.linkLabel.TabIndex = 64;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Sendkeys msdn";
            // 
            // txbEntry
            // 
            this.txbEntry.Location = new System.Drawing.Point(301, 18);
            this.txbEntry.Margin = new System.Windows.Forms.Padding(4);
            this.txbEntry.Name = "txbEntry";
            this.txbEntry.Size = new System.Drawing.Size(143, 22);
            this.txbEntry.TabIndex = 57;
            this.txbEntry.Text = "Add text ...";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1299, 717);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Images";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.btnTest);
            this.groupBox3.Controls.Add(this.txtSimilarityThreshold);
            this.groupBox3.Controls.Add(this.pcbImages);
            this.groupBox3.Controls.Add(this.cmbImages);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.nSearchZoneH);
            this.groupBox3.Controls.Add(this.nSearchZoneW);
            this.groupBox3.Controls.Add(this.nSearchZoneY);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.nSearchZoneX);
            this.groupBox3.Controls.Add(this.nPsY);
            this.groupBox3.Controls.Add(this.nPsX);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(22, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(929, 495);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Images";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(70, 374);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 23);
            this.button4.TabIndex = 24;
            this.button4.Text = "Print";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(487, 374);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Print Grid";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(348, 374);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(95, 23);
            this.btnTest.TabIndex = 21;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtSimilarityThreshold
            // 
            this.txtSimilarityThreshold.Location = new System.Drawing.Point(333, 174);
            this.txtSimilarityThreshold.Name = "txtSimilarityThreshold";
            this.txtSimilarityThreshold.Size = new System.Drawing.Size(129, 22);
            this.txtSimilarityThreshold.TabIndex = 20;
            // 
            // pcbImages
            // 
            this.pcbImages.Location = new System.Drawing.Point(723, 82);
            this.pcbImages.Name = "pcbImages";
            this.pcbImages.Size = new System.Drawing.Size(154, 159);
            this.pcbImages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcbImages.TabIndex = 19;
            this.pcbImages.TabStop = false;
            // 
            // cmbImages
            // 
            this.cmbImages.FormattingEnabled = true;
            this.cmbImages.Items.AddRange(new object[] {
            "HOME - BTN_TREASURE_HUNT",
            "HOME - BTN_HERO",
            "TREASURE_HUNT - BTN_OPTIONS",
            "TREASURE_HUNT - BTN_GO_TO_HOME",
            "TREASURE_HUNT - BTN_CLAIM",
            "HEROES - BTN_WORK_DISABLE",
            "HEROES - DV",
            "HEROES - BTN_CLOSE",
            "HEROES - BTN_REST",
            "HEROES - STAMINA"});
            this.cmbImages.Location = new System.Drawing.Point(67, 82);
            this.cmbImages.Name = "cmbImages";
            this.cmbImages.Size = new System.Drawing.Size(476, 24);
            this.cmbImages.TabIndex = 18;
            this.cmbImages.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(478, 260);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(140, 17);
            this.label21.TabIndex = 17;
            this.label21.Text = "SearchZone - Height";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(334, 260);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(135, 17);
            this.label20.TabIndex = 16;
            this.label20.Text = "SearchZone - Width";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(202, 260);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 17);
            this.label19.TabIndex = 15;
            this.label19.Text = "SearchZone - Y";
            // 
            // nSearchZoneH
            // 
            this.nSearchZoneH.Location = new System.Drawing.Point(478, 279);
            this.nSearchZoneH.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nSearchZoneH.Name = "nSearchZoneH";
            this.nSearchZoneH.Size = new System.Drawing.Size(120, 22);
            this.nSearchZoneH.TabIndex = 14;
            // 
            // nSearchZoneW
            // 
            this.nSearchZoneW.Location = new System.Drawing.Point(342, 279);
            this.nSearchZoneW.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nSearchZoneW.Name = "nSearchZoneW";
            this.nSearchZoneW.Size = new System.Drawing.Size(120, 22);
            this.nSearchZoneW.TabIndex = 13;
            // 
            // nSearchZoneY
            // 
            this.nSearchZoneY.Location = new System.Drawing.Point(206, 279);
            this.nSearchZoneY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nSearchZoneY.Name = "nSearchZoneY";
            this.nSearchZoneY.Size = new System.Drawing.Size(120, 22);
            this.nSearchZoneY.TabIndex = 12;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(330, 154);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 17);
            this.label18.TabIndex = 11;
            this.label18.Text = "SimilarityThreshold";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(198, 154);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 17);
            this.label17.TabIndex = 10;
            this.label17.Text = "Position - Y";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(67, 154);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 9;
            this.label16.Text = "Position - X";
            // 
            // nSearchZoneX
            // 
            this.nSearchZoneX.Location = new System.Drawing.Point(70, 279);
            this.nSearchZoneX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nSearchZoneX.Name = "nSearchZoneX";
            this.nSearchZoneX.Size = new System.Drawing.Size(120, 22);
            this.nSearchZoneX.TabIndex = 8;
            // 
            // nPsY
            // 
            this.nPsY.Location = new System.Drawing.Point(198, 173);
            this.nPsY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nPsY.Name = "nPsY";
            this.nPsY.Size = new System.Drawing.Size(120, 22);
            this.nPsY.TabIndex = 6;
            // 
            // nPsX
            // 
            this.nPsX.Location = new System.Drawing.Point(67, 173);
            this.nPsX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nPsX.Name = "nPsX";
            this.nPsX.Size = new System.Drawing.Size(120, 22);
            this.nPsX.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(70, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 17);
            this.label15.TabIndex = 4;
            this.label15.Text = "SearchZone - X";
            // 
            // TaskWorkHeroes
            // 
            this.TaskWorkHeroes.Interval = 1000;
            this.TaskWorkHeroes.Tick += new System.EventHandler(this.TaskWorkHeroes_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 752);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1162, 227);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clicer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nCheckWorkHeroes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTimeLoop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nWait)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nSearchZoneX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPsY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPsX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView lvActions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer TaskChekError;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdLoopOn;
        private System.Windows.Forms.NumericUpDown nTimeLoop;
        private System.Windows.Forms.RadioButton rdLoopOff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nWait;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.TextBox txbEntry;
        private System.Windows.Forms.Label lblNextAtt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nCheckWorkHeroes;
        private System.Windows.Forms.RadioButton rdCheckHeroesOn;
        private System.Windows.Forms.RadioButton rdCheckHeroesOff;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer TaskWorkHeroes;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nSearchZoneH;
        private System.Windows.Forms.NumericUpDown nSearchZoneW;
        private System.Windows.Forms.NumericUpDown nSearchZoneY;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nSearchZoneX;
        private System.Windows.Forms.NumericUpDown nPsY;
        private System.Windows.Forms.NumericUpDown nPsX;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pcbImages;
        private System.Windows.Forms.ComboBox cmbImages;
        private System.Windows.Forms.TextBox txtSimilarityThreshold;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
    }
}

