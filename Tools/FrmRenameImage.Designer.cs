namespace Tools
{
    partial class FrmRenameImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRenameImage));
            this.button1 = new System.Windows.Forms.Button();
            this.tbxOrginal = new System.Windows.Forms.TextBox();
            this.tbxConfig = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.ofdConfigFile = new System.Windows.Forms.OpenFileDialog();
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTarget = new System.Windows.Forms.TextBox();
            this.tbxMsg = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "btnSel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbxOrginal
            // 
            this.tbxOrginal.Location = new System.Drawing.Point(80, 48);
            this.tbxOrginal.Name = "tbxOrginal";
            this.tbxOrginal.Size = new System.Drawing.Size(395, 21);
            this.tbxOrginal.TabIndex = 1;
            this.tbxOrginal.Text = "E:\\workspace\\document\\receiveFromOA\\网站图片重命名\\东南亚产品图片Part1";
            // 
            // tbxConfig
            // 
            this.tbxConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxConfig.Location = new System.Drawing.Point(0, 107);
            this.tbxConfig.Multiline = true;
            this.tbxConfig.Name = "tbxConfig";
            this.tbxConfig.Size = new System.Drawing.Size(568, 126);
            this.tbxConfig.TabIndex = 2;
            this.tbxConfig.Text = resources.GetString("tbxConfig.Text");
            // 
            // btnRename
            // 
            this.btnRename.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRename.Location = new System.Drawing.Point(0, 233);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(568, 30);
            this.btnRename.TabIndex = 0;
            this.btnRename.Text = "开始";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // ofdConfigFile
            // 
            this.ofdConfigFile.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件文件夹";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "功能: 根据配置文件 批量重命名.\r\n配置文件格式:\r\n     原始文件名---新文件名 (不带扩展名)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbxTarget);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxOrginal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 107);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(481, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "btnSel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "文件文件夹";
            // 
            // tbxTarget
            // 
            this.tbxTarget.Location = new System.Drawing.Point(80, 75);
            this.tbxTarget.Name = "tbxTarget";
            this.tbxTarget.Size = new System.Drawing.Size(395, 21);
            this.tbxTarget.TabIndex = 5;
            this.tbxTarget.Text = "E:\\workspace\\document\\receiveFromOA\\网站图片重命名\\新名称";
            // 
            // tbxMsg
            // 
            this.tbxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbxMsg.Location = new System.Drawing.Point(0, 263);
            this.tbxMsg.Multiline = true;
            this.tbxMsg.Name = "tbxMsg";
            this.tbxMsg.Size = new System.Drawing.Size(568, 114);
            this.tbxMsg.TabIndex = 5;
            // 
            // FrmRenameImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 377);
            this.Controls.Add(this.tbxConfig);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.tbxMsg);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRenameImage";
            this.Text = "FrmRenameImage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxOrginal;
        private System.Windows.Forms.TextBox tbxConfig;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.OpenFileDialog ofdConfigFile;
        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTarget;
        private System.Windows.Forms.TextBox tbxMsg;
    }
}