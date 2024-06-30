namespace FMGAPP.AllForms
{
    partial class FormSettingsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.expTitles = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewExpTitle = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddExpTitle = new System.Windows.Forms.Button();
            this.btnEditExpTitle = new System.Windows.Forms.Button();
            this.btnDeleteExpTitle = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtExpenditureTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.offStatus = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewOffStatus = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddOffStatus = new System.Windows.Forms.Button();
            this.btnEditOffStatus = new System.Windows.Forms.Button();
            this.btnDeleteOffStatus = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.txtOffStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.expTitles.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpTitle)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.offStatus.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffStatus)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.expTitles);
            this.tabControl1.Controls.Add(this.offStatus);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1278, 911);
            this.tabControl1.TabIndex = 0;
            // 
            // expTitles
            // 
            this.expTitles.Controls.Add(this.tableLayoutPanel1);
            this.expTitles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expTitles.Location = new System.Drawing.Point(4, 41);
            this.expTitles.Name = "expTitles";
            this.expTitles.Padding = new System.Windows.Forms.Padding(3);
            this.expTitles.Size = new System.Drawing.Size(1270, 866);
            this.expTitles.TabIndex = 0;
            this.expTitles.Text = "Expenditure Titles     ";
            this.expTitles.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewExpTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 860);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // dataGridViewExpTitle
            // 
            this.dataGridViewExpTitle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewExpTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExpTitle.Location = new System.Drawing.Point(4, 67);
            this.dataGridViewExpTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewExpTitle.Name = "dataGridViewExpTitle";
            this.dataGridViewExpTitle.RowHeadersWidth = 62;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewExpTitle.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExpTitle.RowTemplate.Height = 35;
            this.dataGridViewExpTitle.Size = new System.Drawing.Size(1256, 668);
            this.dataGridViewExpTitle.TabIndex = 0;
            this.dataGridViewExpTitle.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExpTitle_RowEnter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 745);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1256, 110);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Controls.Add(this.btnAddExpTitle, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEditExpTitle, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDeleteExpTitle, 5, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 38);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1248, 67);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnAddExpTitle
            // 
            this.btnAddExpTitle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddExpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddExpTitle.FlatAppearance.BorderSize = 0;
            this.btnAddExpTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExpTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExpTitle.ForeColor = System.Drawing.Color.White;
            this.btnAddExpTitle.Location = new System.Drawing.Point(308, 5);
            this.btnAddExpTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddExpTitle.Name = "btnAddExpTitle";
            this.btnAddExpTitle.Size = new System.Drawing.Size(187, 57);
            this.btnAddExpTitle.TabIndex = 0;
            this.btnAddExpTitle.Text = "Add";
            this.btnAddExpTitle.UseVisualStyleBackColor = false;
            this.btnAddExpTitle.Click += new System.EventHandler(this.btnAddExpTitle_Click_1);
            // 
            // btnEditExpTitle
            // 
            this.btnEditExpTitle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEditExpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditExpTitle.FlatAppearance.BorderSize = 0;
            this.btnEditExpTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditExpTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditExpTitle.ForeColor = System.Drawing.Color.White;
            this.btnEditExpTitle.Location = new System.Drawing.Point(529, 5);
            this.btnEditExpTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditExpTitle.Name = "btnEditExpTitle";
            this.btnEditExpTitle.Size = new System.Drawing.Size(187, 57);
            this.btnEditExpTitle.TabIndex = 0;
            this.btnEditExpTitle.Text = "Edit";
            this.btnEditExpTitle.UseVisualStyleBackColor = false;
            this.btnEditExpTitle.Click += new System.EventHandler(this.btnEditExpTitle_Click);
            // 
            // btnDeleteExpTitle
            // 
            this.btnDeleteExpTitle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteExpTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteExpTitle.FlatAppearance.BorderSize = 0;
            this.btnDeleteExpTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteExpTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteExpTitle.ForeColor = System.Drawing.Color.White;
            this.btnDeleteExpTitle.Location = new System.Drawing.Point(750, 5);
            this.btnDeleteExpTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteExpTitle.Name = "btnDeleteExpTitle";
            this.btnDeleteExpTitle.Size = new System.Drawing.Size(187, 57);
            this.btnDeleteExpTitle.TabIndex = 0;
            this.btnDeleteExpTitle.Text = "Delete";
            this.btnDeleteExpTitle.UseVisualStyleBackColor = false;
            this.btnDeleteExpTitle.Click += new System.EventHandler(this.btnDeleteExpTitle_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.txtExpenditureTitle, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1256, 52);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // txtExpenditureTitle
            // 
            this.txtExpenditureTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpenditureTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenditureTitle.Location = new System.Drawing.Point(569, 5);
            this.txtExpenditureTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExpenditureTitle.Name = "txtExpenditureTitle";
            this.txtExpenditureTitle.Size = new System.Drawing.Size(368, 39);
            this.txtExpenditureTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expenditure Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offStatus
            // 
            this.offStatus.Controls.Add(this.tableLayoutPanel5);
            this.offStatus.Location = new System.Drawing.Point(4, 41);
            this.offStatus.Name = "offStatus";
            this.offStatus.Padding = new System.Windows.Forms.Padding(3);
            this.offStatus.Size = new System.Drawing.Size(1270, 866);
            this.offStatus.TabIndex = 1;
            this.offStatus.Text = "Offering Status     ";
            this.offStatus.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.dataGridViewOffStatus, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1264, 860);
            this.tableLayoutPanel5.TabIndex = 32;
            // 
            // dataGridViewOffStatus
            // 
            this.dataGridViewOffStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOffStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOffStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOffStatus.Location = new System.Drawing.Point(4, 67);
            this.dataGridViewOffStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewOffStatus.Name = "dataGridViewOffStatus";
            this.dataGridViewOffStatus.RowHeadersWidth = 62;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewOffStatus.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOffStatus.RowTemplate.Height = 35;
            this.dataGridViewOffStatus.Size = new System.Drawing.Size(1256, 668);
            this.dataGridViewOffStatus.TabIndex = 0;
            this.dataGridViewOffStatus.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOffStatus_RowEnter);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 745);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1256, 110);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 7;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel7.Controls.Add(this.btnAddOffStatus, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnEditOffStatus, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnDeleteOffStatus, 5, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(4, 38);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1248, 67);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btnAddOffStatus
            // 
            this.btnAddOffStatus.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddOffStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddOffStatus.FlatAppearance.BorderSize = 0;
            this.btnAddOffStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOffStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOffStatus.ForeColor = System.Drawing.Color.White;
            this.btnAddOffStatus.Location = new System.Drawing.Point(308, 5);
            this.btnAddOffStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddOffStatus.Name = "btnAddOffStatus";
            this.btnAddOffStatus.Size = new System.Drawing.Size(187, 57);
            this.btnAddOffStatus.TabIndex = 0;
            this.btnAddOffStatus.Text = "Add";
            this.btnAddOffStatus.UseVisualStyleBackColor = false;
            this.btnAddOffStatus.Click += new System.EventHandler(this.btnAddOffStatus_Click);
            // 
            // btnEditOffStatus
            // 
            this.btnEditOffStatus.BackColor = System.Drawing.Color.SeaGreen;
            this.btnEditOffStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditOffStatus.FlatAppearance.BorderSize = 0;
            this.btnEditOffStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOffStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOffStatus.ForeColor = System.Drawing.Color.White;
            this.btnEditOffStatus.Location = new System.Drawing.Point(529, 5);
            this.btnEditOffStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditOffStatus.Name = "btnEditOffStatus";
            this.btnEditOffStatus.Size = new System.Drawing.Size(187, 57);
            this.btnEditOffStatus.TabIndex = 0;
            this.btnEditOffStatus.Text = "Edit";
            this.btnEditOffStatus.UseVisualStyleBackColor = false;
            this.btnEditOffStatus.Click += new System.EventHandler(this.btnEditOffStatus_Click);
            // 
            // btnDeleteOffStatus
            // 
            this.btnDeleteOffStatus.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDeleteOffStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteOffStatus.FlatAppearance.BorderSize = 0;
            this.btnDeleteOffStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOffStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOffStatus.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOffStatus.Location = new System.Drawing.Point(750, 5);
            this.btnDeleteOffStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteOffStatus.Name = "btnDeleteOffStatus";
            this.btnDeleteOffStatus.Size = new System.Drawing.Size(187, 57);
            this.btnDeleteOffStatus.TabIndex = 0;
            this.btnDeleteOffStatus.Text = "Delete";
            this.btnDeleteOffStatus.UseVisualStyleBackColor = false;
            this.btnDeleteOffStatus.Click += new System.EventHandler(this.btnDeleteOffStatus_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.81818F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Controls.Add(this.txtOffStatus, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1256, 52);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // txtOffStatus
            // 
            this.txtOffStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOffStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffStatus.Location = new System.Drawing.Point(546, 5);
            this.txtOffStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOffStatus.Name = "txtOffStatus";
            this.txtOffStatus.Size = new System.Drawing.Size(391, 39);
            this.txtOffStatus.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Offering Status";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSettingsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 911);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormSettingsList";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettingsList_Load);
            this.tabControl1.ResumeLayout(false);
            this.expTitles.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpTitle)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.offStatus.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOffStatus)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage expTitles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewExpTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnAddExpTitle;
        private System.Windows.Forms.Button btnEditExpTitle;
        private System.Windows.Forms.Button btnDeleteExpTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txtExpenditureTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage offStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dataGridViewOffStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button btnAddOffStatus;
        private System.Windows.Forms.Button btnEditOffStatus;
        private System.Windows.Forms.Button btnDeleteOffStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox txtOffStatus;
        private System.Windows.Forms.Label label2;
    }
}