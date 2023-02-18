namespace CurseForgeClient
{
    partial class ShareWindow
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
            this.startServerButton = new System.Windows.Forms.Button();
            this.serverStatus = new System.Windows.Forms.Label();
            this.ipInput = new System.Windows.Forms.TextBox();
            this.downloadFromServer = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // startServerButton
            // 
            this.startServerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startServerButton.Location = new System.Drawing.Point(122, 132);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(217, 58);
            this.startServerButton.TabIndex = 1;
            this.startServerButton.Text = "Запустить сервер";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // serverStatus
            // 
            this.serverStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverStatus.Location = new System.Drawing.Point(122, 9);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(217, 41);
            this.serverStatus.TabIndex = 2;
            this.serverStatus.Text = "Сервер не работает";
            this.serverStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipInput
            // 
            this.ipInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ipInput.Location = new System.Drawing.Point(122, 84);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(217, 23);
            this.ipInput.TabIndex = 3;
            this.ipInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // downloadFromServer
            // 
            this.downloadFromServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downloadFromServer.Location = new System.Drawing.Point(122, 219);
            this.downloadFromServer.Name = "downloadFromServer";
            this.downloadFromServer.Size = new System.Drawing.Size(217, 58);
            this.downloadFromServer.TabIndex = 4;
            this.downloadFromServer.Text = "Загрузить с сервера";
            this.downloadFromServer.UseVisualStyleBackColor = true;
            this.downloadFromServer.Click += new System.EventHandler(this.downloadFromServer_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(122, 305);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(217, 40);
            this.progressBar.TabIndex = 5;
            // 
            // ShareWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 371);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloadFromServer);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.ipInput);
            this.Controls.Add(this.startServerButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShareWindow";
            this.Text = "ShareWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShareWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button startServerButton;
        private Label serverStatus;
        private TextBox ipInput;
        private Button downloadFromServer;
        private ProgressBar progressBar;
    }
}