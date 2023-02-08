﻿namespace CurseForgeClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backStripButton = new System.Windows.Forms.ToolStripButton();
            this._pageStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.nextStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gameVersionStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            this._menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(0, 52);
            this._dataGridView.MultiSelect = false;
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowTemplate.Height = 25;
            this._dataGridView.Size = new System.Drawing.Size(800, 398);
            this._dataGridView.TabIndex = 1;
            this._dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridView_CellDoubleClick);
            this._dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dataGridView_CellFormatting);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(800, 24);
            this._menuStrip.TabIndex = 2;
            this._menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backStripButton,
            this._pageStripLabel,
            this.nextStripButton,
            this.toolStripSeparator1,
            this.gameVersionStripComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // backStripButton
            // 
            this.backStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.backStripButton.Image = ((System.Drawing.Image)(resources.GetObject("backStripButton.Image")));
            this.backStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backStripButton.Name = "backStripButton";
            this.backStripButton.Size = new System.Drawing.Size(23, 22);
            this.backStripButton.Text = "<";
            this.backStripButton.Click += new System.EventHandler(this.backStripButton_Click);
            // 
            // _pageStripLabel
            // 
            this._pageStripLabel.Enabled = false;
            this._pageStripLabel.Name = "_pageStripLabel";
            this._pageStripLabel.Size = new System.Drawing.Size(13, 22);
            this._pageStripLabel.Text = "1";
            // 
            // nextStripButton
            // 
            this.nextStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nextStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nextStripButton.Image")));
            this.nextStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextStripButton.Name = "nextStripButton";
            this.nextStripButton.Size = new System.Drawing.Size(23, 22);
            this.nextStripButton.Text = ">";
            this.nextStripButton.Click += new System.EventHandler(this.nextStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // gameVersionStripComboBox
            // 
            this.gameVersionStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameVersionStripComboBox.Items.AddRange(new object[] {
            "1.7.10",
            "1.12.2",
            "1.16.5",
            "1.19.2"});
            this.gameVersionStripComboBox.Name = "gameVersionStripComboBox";
            this.gameVersionStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.gameVersionStripComboBox.SelectedIndexChanged += new System.EventHandler(this.gameVersionStripComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView _dataGridView;
        private BindingSource _bindingSource;
        private MenuStrip _menuStrip;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton backStripButton;
        private ToolStripLabel _pageStripLabel;
        private ToolStripButton nextStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox gameVersionStripComboBox;
    }
}