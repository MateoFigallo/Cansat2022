
namespace cansat_app
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.btnRestore = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnMaximize = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.VerticalMenu = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnResolution = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.PictureBox();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.VerticalMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMain)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.Navy;
            this.TitleBar.Controls.Add(this.btnRestore);
            this.TitleBar.Controls.Add(this.btnMinimize);
            this.TitleBar.Controls.Add(this.btnMaximize);
            this.TitleBar.Controls.Add(this.btnClose);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(1620, 28);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore.Image")));
            this.btnRestore.Location = new System.Drawing.Point(1558, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(22, 20);
            this.btnRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestore.TabIndex = 3;
            this.btnRestore.TabStop = false;
            this.btnRestore.Visible = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1532, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(22, 20);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.Location = new System.Drawing.Point(1558, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(22, 20);
            this.btnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1587, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 20);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VerticalMenu
            // 
            this.VerticalMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VerticalMenu.Controls.Add(this.comboBox1);
            this.VerticalMenu.Controls.Add(this.label1);
            this.VerticalMenu.Controls.Add(this.btnSendData);
            this.VerticalMenu.Controls.Add(this.btnConnect);
            this.VerticalMenu.Controls.Add(this.btnResolution);
            this.VerticalMenu.Controls.Add(this.btnMain);
            this.VerticalMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.VerticalMenu.Location = new System.Drawing.Point(0, 28);
            this.VerticalMenu.Name = "VerticalMenu";
            this.VerticalMenu.Size = new System.Drawing.Size(198, 707);
            this.VerticalMenu.TabIndex = 1;
            this.VerticalMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.VerticalMenu_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 354);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Team ID = 1064";
            // 
            // btnSendData
            // 
            this.btnSendData.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSendData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendData.Font = new System.Drawing.Font("Impact", 12F);
            this.btnSendData.ForeColor = System.Drawing.Color.White;
            this.btnSendData.Location = new System.Drawing.Point(27, 545);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(144, 48);
            this.btnSendData.TabIndex = 6;
            this.btnSendData.Text = "Send Data";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Visible = false;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Impact", 12F);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(27, 438);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 48);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Visible = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnResolution
            // 
            this.btnResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResolution.FlatAppearance.BorderSize = 0;
            this.btnResolution.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btnResolution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolution.Font = new System.Drawing.Font("Impact", 12F);
            this.btnResolution.ForeColor = System.Drawing.Color.White;
            this.btnResolution.Image = ((System.Drawing.Image)(resources.GetObject("btnResolution.Image")));
            this.btnResolution.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResolution.Location = new System.Drawing.Point(0, 271);
            this.btnResolution.Name = "btnResolution";
            this.btnResolution.Size = new System.Drawing.Size(198, 45);
            this.btnResolution.TabIndex = 1;
            this.btnResolution.Text = "START";
            this.btnResolution.UseVisualStyleBackColor = false;
            this.btnResolution.Click += new System.EventHandler(this.btnResolution_Click);
            // 
            // btnMain
            // 
            this.btnMain.Image = ((System.Drawing.Image)(resources.GetObject("btnMain.Image")));
            this.btnMain.Location = new System.Drawing.Point(18, 24);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(162, 157);
            this.btnMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMain.TabIndex = 0;
            this.btnMain.TabStop = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // PanelContainer
            // 
            this.PanelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Font = new System.Drawing.Font("Impact", 12F);
            this.PanelContainer.Location = new System.Drawing.Point(198, 28);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(1422, 707);
            this.PanelContainer.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 735);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.VerticalMenu);
            this.Controls.Add(this.TitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.btnMain_Click);
            this.TitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.VerticalMenu.ResumeLayout(false);
            this.VerticalMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.PictureBox btnMaximize;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel VerticalMenu;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.PictureBox btnRestore;
        private System.Windows.Forms.PictureBox btnMain;
        private System.Windows.Forms.Button btnResolution;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

