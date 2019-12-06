namespace ImagesGraphicprocessing
{
    partial class Photopipei
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Photopipei));
            this.bn_check = new System.Windows.Forms.Button();
            this.bn_save = new System.Windows.Forms.Button();
            this.bn_operate = new System.Windows.Forms.Button();
            this.PicDest = new System.Windows.Forms.PictureBox();
            this.PicSrc = new System.Windows.Forms.PictureBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.gr_info = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicSrc1 = new System.Windows.Forms.PictureBox();
            this.PicSrc2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).BeginInit();
            this.gr_info.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc2)).BeginInit();
            this.SuspendLayout();
            // 
            // bn_check
            // 
            this.bn_check.Location = new System.Drawing.Point(12, 12);
            this.bn_check.Name = "bn_check";
            this.bn_check.Size = new System.Drawing.Size(75, 23);
            this.bn_check.TabIndex = 1;
            this.bn_check.Text = "选择图片";
            this.bn_check.UseVisualStyleBackColor = true;
            this.bn_check.Click += new System.EventHandler(this.bn_check_Click);
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(107, 12);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 2;
            this.bn_save.Text = "保存图片";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
            // 
            // bn_operate
            // 
            this.bn_operate.Location = new System.Drawing.Point(217, 12);
            this.bn_operate.Name = "bn_operate";
            this.bn_operate.Size = new System.Drawing.Size(75, 23);
            this.bn_operate.TabIndex = 3;
            this.bn_operate.Text = "处理";
            this.bn_operate.UseVisualStyleBackColor = true;
            this.bn_operate.Click += new System.EventHandler(this.bn_operate_Click);
            // 
            // PicDest
            // 
            this.PicDest.Image = ((System.Drawing.Image)(resources.GetObject("PicDest.Image")));
            this.PicDest.Location = new System.Drawing.Point(12, 51);
            this.PicDest.Name = "PicDest";
            this.PicDest.Size = new System.Drawing.Size(688, 520);
            this.PicDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDest.TabIndex = 4;
            this.PicDest.TabStop = false;
            // 
            // PicSrc
            // 
            this.PicSrc.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc.Image")));
            this.PicSrc.Location = new System.Drawing.Point(20, 29);
            this.PicSrc.Name = "PicSrc";
            this.PicSrc.Size = new System.Drawing.Size(180, 75);
            this.PicSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc.TabIndex = 5;
            this.PicSrc.TabStop = false;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(6, 29);
            this.LblInfo.MaximumSize = new System.Drawing.Size(230, 0);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(41, 12);
            this.LblInfo.TabIndex = 6;
            this.LblInfo.Text = "提示：";
            // 
            // gr_info
            // 
            this.gr_info.Controls.Add(this.LblInfo);
            this.gr_info.Location = new System.Drawing.Point(6, 381);
            this.gr_info.Name = "gr_info";
            this.gr_info.Size = new System.Drawing.Size(235, 133);
            this.gr_info.TabIndex = 7;
            this.gr_info.TabStop = false;
            this.gr_info.Text = "匹配信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicSrc2);
            this.groupBox1.Controls.Add(this.gr_info);
            this.groupBox1.Controls.Add(this.PicSrc1);
            this.groupBox1.Controls.Add(this.PicSrc);
            this.groupBox1.Location = new System.Drawing.Point(726, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 520);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板";
            // 
            // PicSrc1
            // 
            this.PicSrc1.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc1.Image")));
            this.PicSrc1.Location = new System.Drawing.Point(20, 142);
            this.PicSrc1.Name = "PicSrc1";
            this.PicSrc1.Size = new System.Drawing.Size(167, 50);
            this.PicSrc1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc1.TabIndex = 6;
            this.PicSrc1.TabStop = false;
            // 
            // PicSrc2
            // 
            this.PicSrc2.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc2.Image")));
            this.PicSrc2.Location = new System.Drawing.Point(20, 255);
            this.PicSrc2.Name = "PicSrc2";
            this.PicSrc2.Size = new System.Drawing.Size(180, 75);
            this.PicSrc2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc2.TabIndex = 7;
            this.PicSrc2.TabStop = false;
            // 
            // Photopipei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PicDest);
            this.Controls.Add(this.bn_operate);
            this.Controls.Add(this.bn_save);
            this.Controls.Add(this.bn_check);
            this.Name = "Photopipei";
            this.Text = "PXDiffImg";
            this.Load += new System.EventHandler(this.PXDiffImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).EndInit();
            this.gr_info.ResumeLayout(false);
            this.gr_info.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bn_check;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.Button bn_operate;
        private System.Windows.Forms.PictureBox PicDest;
        private System.Windows.Forms.PictureBox PicSrc;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.GroupBox gr_info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PicSrc2;
        private System.Windows.Forms.PictureBox PicSrc1;
    }
}