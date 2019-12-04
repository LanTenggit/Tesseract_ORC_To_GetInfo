namespace ImagesGraphicprocessing
{
    partial class PXDiffImg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PXDiffImg));
            this.button1 = new System.Windows.Forms.Button();
            this.bn_check = new System.Windows.Forms.Button();
            this.bn_save = new System.Windows.Forms.Button();
            this.bn_operate = new System.Windows.Forms.Button();
            this.PicDest = new System.Windows.Forms.PictureBox();
            this.PicSrc = new System.Windows.Forms.PictureBox();
            this.LblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.PicDest.Location = new System.Drawing.Point(12, 68);
            this.PicDest.Name = "PicDest";
            this.PicDest.Size = new System.Drawing.Size(688, 520);
            this.PicDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDest.TabIndex = 4;
            this.PicDest.TabStop = false;
            // 
            // PicSrc
            // 
            this.PicSrc.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc.Image")));
            this.PicSrc.Location = new System.Drawing.Point(794, 68);
            this.PicSrc.Name = "PicSrc";
            this.PicSrc.Size = new System.Drawing.Size(216, 75);
            this.PicSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc.TabIndex = 5;
            this.PicSrc.TabStop = false;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(371, 22);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(41, 12);
            this.LblInfo.TabIndex = 6;
            this.LblInfo.Text = "label1";
            // 
            // PXDiffImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 632);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.PicSrc);
            this.Controls.Add(this.PicDest);
            this.Controls.Add(this.bn_operate);
            this.Controls.Add(this.bn_save);
            this.Controls.Add(this.bn_check);
            this.Controls.Add(this.button1);
            this.Name = "PXDiffImg";
            this.Text = "PXDiffImg";
            this.Load += new System.EventHandler(this.PXDiffImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bn_check;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.Button bn_operate;
        private System.Windows.Forms.PictureBox PicDest;
        private System.Windows.Forms.PictureBox PicSrc;
        private System.Windows.Forms.Label LblInfo;
    }
}