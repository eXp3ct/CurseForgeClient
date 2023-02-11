namespace CurseForgeClient
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
            this.выбратьПапкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backStripButton = new System.Windows.Forms.ToolStripButton();
            this._pageStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.nextStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gameVersionTextStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.gameVersionStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sortFieldStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.sortFieldStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sortOrderTextStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.sortOrderStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.installModsButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            this._menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Location = new System.Drawing.Point(0, 52);
            this._dataGridView.MultiSelect = false;
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._dataGridView.RowTemplate.Height = 34;
            this._dataGridView.Size = new System.Drawing.Size(981, 670);
            this._dataGridView.TabIndex = 1;
            this._dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridView_CellDoubleClick);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1201, 24);
            this._menuStrip.TabIndex = 2;
            this._menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьПапкуToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выбратьПапкуToolStripMenuItem
            // 
            this.выбратьПапкуToolStripMenuItem.Name = "выбратьПапкуToolStripMenuItem";
            this.выбратьПапкуToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.выбратьПапкуToolStripMenuItem.Text = "Выбрать папку";
            this.выбратьПапкуToolStripMenuItem.Click += new System.EventHandler(this.выбратьПапкуToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backStripButton,
            this._pageStripLabel,
            this.nextStripButton,
            this.toolStripSeparator1,
            this.gameVersionTextStripLabel,
            this.gameVersionStripComboBox,
            this.toolStripSeparator2,
            this.sortFieldStripLabel,
            this.sortFieldStripComboBox,
            this.toolStripSeparator3,
            this.sortOrderTextStripLabel,
            this.sortOrderStripComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1201, 25);
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
            // gameVersionTextStripLabel
            // 
            this.gameVersionTextStripLabel.Name = "gameVersionTextStripLabel";
            this.gameVersionTextStripLabel.Size = new System.Drawing.Size(77, 22);
            this.gameVersionTextStripLabel.Text = "Версия игры";
            // 
            // gameVersionStripComboBox
            // 
            this.gameVersionStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameVersionStripComboBox.Name = "gameVersionStripComboBox";
            this.gameVersionStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.gameVersionStripComboBox.SelectedIndexChanged += new System.EventHandler(this.gameVersionStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // sortFieldStripLabel
            // 
            this.sortFieldStripLabel.Name = "sortFieldStripLabel";
            this.sortFieldStripLabel.Size = new System.Drawing.Size(95, 22);
            this.sortFieldStripLabel.Text = "Сортировать по";
            // 
            // sortFieldStripComboBox
            // 
            this.sortFieldStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortFieldStripComboBox.Name = "sortFieldStripComboBox";
            this.sortFieldStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.sortFieldStripComboBox.SelectedIndexChanged += new System.EventHandler(this.sortFieldStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // sortOrderTextStripLabel
            // 
            this.sortOrderTextStripLabel.Name = "sortOrderTextStripLabel";
            this.sortOrderTextStripLabel.Size = new System.Drawing.Size(149, 22);
            this.sortOrderTextStripLabel.Text = "Направление сортировки";
            // 
            // sortOrderStripComboBox
            // 
            this.sortOrderStripComboBox.Name = "sortOrderStripComboBox";
            this.sortOrderStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.sortOrderStripComboBox.SelectedIndexChanged += new System.EventHandler(this.sortOrderStripComboBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.Controls.Add(this.installModsButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(987, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 670);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // installModsButton
            // 
            this.installModsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.installModsButton.Location = new System.Drawing.Point(3, 3);
            this.installModsButton.Name = "installModsButton";
            this.installModsButton.Size = new System.Drawing.Size(197, 76);
            this.installModsButton.TabIndex = 0;
            this.installModsButton.Text = "Установить";
            this.installModsButton.UseVisualStyleBackColor = true;
            this.installModsButton.Click += new System.EventHandler(this.installModsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 722);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainForm";
            this.Text = "Minecraft ModLoader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private FlowLayoutPanel flowLayoutPanel1;
        private Button installModsButton;
        private ToolStripLabel gameVersionTextStripLabel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel sortFieldStripLabel;
        private ToolStripComboBox sortFieldStripComboBox;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel sortOrderTextStripLabel;
        private ToolStripComboBox sortOrderStripComboBox;
        private ToolStripMenuItem выбратьПапкуToolStripMenuItem;
        private FolderBrowserDialog folderBrowserDialog;
    }
}