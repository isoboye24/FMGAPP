namespace FMGAPP.AllForms
{
    partial class FormAddSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.iconClose = new FontAwesome.Sharp.IconPictureBox();
            this.title = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelSettings = new System.Windows.Forms.Label();
            this.txtSettingsText = new System.Windows.Forms.TextBox();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 320);
            this.panel1.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkOrange;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(661, 86);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 320);
            this.panel3.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 406);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 8);
            this.panel2.TabIndex = 31;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.DarkOrange;
            this.panelTitleBar.Controls.Add(this.iconMinimize);
            this.panelTitleBar.Controls.Add(this.iconClose);
            this.panelTitleBar.Controls.Add(this.title);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(669, 86);
            this.panelTitleBar.TabIndex = 30;
            // 
            // iconMinimize
            // 
            this.iconMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMinimize.BackColor = System.Drawing.Color.Transparent;
            this.iconMinimize.ForeColor = System.Drawing.Color.Black;
            this.iconMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconMinimize.IconColor = System.Drawing.Color.Black;
            this.iconMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMinimize.IconSize = 48;
            this.iconMinimize.Location = new System.Drawing.Point(528, 18);
            this.iconMinimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconMinimize.Name = "iconMinimize";
            this.iconMinimize.Size = new System.Drawing.Size(48, 49);
            this.iconMinimize.TabIndex = 13;
            this.iconMinimize.TabStop = false;
            // 
            // iconClose
            // 
            this.iconClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconClose.BackColor = System.Drawing.Color.Transparent;
            this.iconClose.ForeColor = System.Drawing.Color.Black;
            this.iconClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.iconClose.IconColor = System.Drawing.Color.Black;
            this.iconClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconClose.IconSize = 48;
            this.iconClose.Location = new System.Drawing.Point(606, 18);
            this.iconClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.iconClose.Name = "iconClose";
            this.iconClose.Size = new System.Drawing.Size(48, 49);
            this.iconClose.TabIndex = 15;
            this.iconClose.TabStop = false;
            this.iconClose.Click += new System.EventHandler(this.iconClose_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Black;
            this.title.Location = new System.Drawing.Point(27, 18);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(386, 48);
            this.title.TabIndex = 12;
            this.title.Text = "Add Expenditure Title";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(342, 285);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 58);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkRed;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(120, 285);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(186, 58);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(114, 149);
            this.labelSettings.Margin = new System.Windows.Forms.Padding(4, 8, 4, 0);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(209, 32);
            this.labelSettings.TabIndex = 35;
            this.labelSettings.Text = "Expenditure Title";
            this.labelSettings.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSettingsText
            // 
            this.txtSettingsText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsText.Location = new System.Drawing.Point(120, 189);
            this.txtSettingsText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSettingsText.Name = "txtSettingsText";
            this.txtSettingsText.Size = new System.Drawing.Size(406, 39);
            this.txtSettingsText.TabIndex = 36;
            // 
            // FormAddSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 414);
            this.Controls.Add(this.txtSettingsText);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAddSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Expenditure Title";
            this.Load += new System.EventHandler(this.FormExpenditureTitle_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconMinimize;
        private FontAwesome.Sharp.IconPictureBox iconClose;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.TextBox txtSettingsText;
    }
}