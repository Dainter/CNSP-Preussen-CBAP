namespace CNSP.ComBehavior
{
    partial class FrmComBehavior
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComBehavior));
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TabStructure = new System.Windows.Forms.TabPage();
            this.PanelPic = new System.Windows.Forms.Panel();
            this.PicCam = new System.Windows.Forms.PictureBox();
            this.PaintButton = new System.Windows.Forms.Button();
            this.MainLayout.SuspendLayout();
            this.TabMain.SuspendLayout();
            this.TabStructure.SuspendLayout();
            this.PanelPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCam)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Controls.Add(this.TabMain, 1, 0);
            this.MainLayout.Controls.Add(this.PaintButton, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(739, 424);
            this.MainLayout.TabIndex = 16;
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.TabStructure);
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(228, 3);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(508, 418);
            this.TabMain.TabIndex = 15;
            // 
            // TabStructure
            // 
            this.TabStructure.BackColor = System.Drawing.SystemColors.Control;
            this.TabStructure.Controls.Add(this.PanelPic);
            this.TabStructure.Location = new System.Drawing.Point(4, 22);
            this.TabStructure.Name = "TabStructure";
            this.TabStructure.Padding = new System.Windows.Forms.Padding(3);
            this.TabStructure.Size = new System.Drawing.Size(500, 392);
            this.TabStructure.TabIndex = 0;
            this.TabStructure.Text = "网络结构图";
            // 
            // PanelPic
            // 
            this.PanelPic.AutoScroll = true;
            this.PanelPic.Controls.Add(this.PicCam);
            this.PanelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPic.Location = new System.Drawing.Point(3, 3);
            this.PanelPic.Name = "PanelPic";
            this.PanelPic.Size = new System.Drawing.Size(494, 386);
            this.PanelPic.TabIndex = 14;
            // 
            // PicCam
            // 
            this.PicCam.BackColor = System.Drawing.Color.White;
            this.PicCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicCam.Location = new System.Drawing.Point(3, 3);
            this.PicCam.Name = "PicCam";
            this.PicCam.Size = new System.Drawing.Size(591, 434);
            this.PicCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicCam.TabIndex = 4;
            this.PicCam.TabStop = false;
            // 
            // PaintButton
            // 
            this.PaintButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PaintButton.Location = new System.Drawing.Point(63, 201);
            this.PaintButton.Name = "PaintButton";
            this.PaintButton.Size = new System.Drawing.Size(98, 22);
            this.PaintButton.TabIndex = 16;
            this.PaintButton.Text = "绘图";
            this.PaintButton.UseVisualStyleBackColor = true;
            this.PaintButton.Click += new System.EventHandler(this.PaintButton_Click);
            // 
            // FrmComBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 424);
            this.Controls.Add(this.MainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmComBehavior";
            this.Text = "通信行为仿真";
            this.Load += new System.EventHandler(this.FrmComBehavior_Load);
            this.MainLayout.ResumeLayout(false);
            this.TabMain.ResumeLayout(false);
            this.TabStructure.ResumeLayout(false);
            this.PanelPic.ResumeLayout(false);
            this.PanelPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel MainLayout;
        internal System.Windows.Forms.TabControl TabMain;
        internal System.Windows.Forms.TabPage TabStructure;
        internal System.Windows.Forms.Panel PanelPic;
        internal System.Windows.Forms.PictureBox PicCam;
        private System.Windows.Forms.Button PaintButton;
    }
}