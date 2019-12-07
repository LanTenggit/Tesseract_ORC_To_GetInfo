namespace ImagesGraphicprocessing
{
    partial class PhotoModelSimilarityMatching
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoModelSimilarityMatching));
            this.PicSrc1 = new System.Windows.Forms.PictureBox();
            this.PicDest = new System.Windows.Forms.PictureBox();
            this.bn_operate = new System.Windows.Forms.Button();
            this.bn_save = new System.Windows.Forms.Button();
            this.bn_check = new System.Windows.Forms.Button();
            this.PicSrc = new System.Windows.Forms.PictureBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.gr_info = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_fail = new System.Windows.Forms.TextBox();
            this.tb_success = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_boty = new System.Windows.Forms.ComboBox();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.bn_com = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MesInfo = new System.Windows.Forms.NotifyIcon(this.components);
            this.right_icon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bn_setSuccess = new System.Windows.Forms.Button();
            this.bn_setFaild = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).BeginInit();
            this.gr_info.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.right_icon.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicSrc1
            // 
            this.PicSrc1.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc1.Image")));
            this.PicSrc1.Location = new System.Drawing.Point(6, 33);
            this.PicSrc1.Name = "PicSrc1";
            this.PicSrc1.Size = new System.Drawing.Size(167, 50);
            this.PicSrc1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PicSrc1.TabIndex = 6;
            this.PicSrc1.TabStop = false;
            // 
            // PicDest
            // 
            this.PicDest.Image = ((System.Drawing.Image)(resources.GetObject("PicDest.Image")));
            this.PicDest.Location = new System.Drawing.Point(30, 134);
            this.PicDest.Name = "PicDest";
            this.PicDest.Size = new System.Drawing.Size(688, 520);
            this.PicDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDest.TabIndex = 12;
            this.PicDest.TabStop = false;
            // 
            // bn_operate
            // 
            this.bn_operate.Location = new System.Drawing.Point(235, 105);
            this.bn_operate.Name = "bn_operate";
            this.bn_operate.Size = new System.Drawing.Size(75, 23);
            this.bn_operate.TabIndex = 11;
            this.bn_operate.Text = "处理";
            this.bn_operate.UseVisualStyleBackColor = true;
            this.bn_operate.Click += new System.EventHandler(this.bn_operate_Click);
            // 
            // bn_save
            // 
            this.bn_save.Location = new System.Drawing.Point(125, 105);
            this.bn_save.Name = "bn_save";
            this.bn_save.Size = new System.Drawing.Size(75, 23);
            this.bn_save.TabIndex = 10;
            this.bn_save.Text = "保存图片";
            this.bn_save.UseVisualStyleBackColor = true;
            this.bn_save.Click += new System.EventHandler(this.bn_save_Click);
            // 
            // bn_check
            // 
            this.bn_check.Location = new System.Drawing.Point(30, 105);
            this.bn_check.Name = "bn_check";
            this.bn_check.Size = new System.Drawing.Size(75, 23);
            this.bn_check.TabIndex = 9;
            this.bn_check.Text = "选择图片";
            this.bn_check.UseVisualStyleBackColor = true;
            this.bn_check.Click += new System.EventHandler(this.bn_check_Click);
            // 
            // PicSrc
            // 
            this.PicSrc.Image = ((System.Drawing.Image)(resources.GetObject("PicSrc.Image")));
            this.PicSrc.Location = new System.Drawing.Point(6, 20);
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
            this.gr_info.Location = new System.Drawing.Point(6, 362);
            this.gr_info.Name = "gr_info";
            this.gr_info.Size = new System.Drawing.Size(235, 152);
            this.gr_info.TabIndex = 7;
            this.gr_info.TabStop = false;
            this.gr_info.Text = "匹配信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.gr_info);
            this.groupBox1.Location = new System.Drawing.Point(748, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 520);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模板";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_fail);
            this.groupBox2.Controls.Add(this.tb_success);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_boty);
            this.groupBox2.Controls.Add(this.cb_port);
            this.groupBox2.Controls.Add(this.bn_com);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(33, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 87);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口设置";
            // 
            // tb_fail
            // 
            this.tb_fail.Location = new System.Drawing.Point(391, 60);
            this.tb_fail.Name = "tb_fail";
            this.tb_fail.Size = new System.Drawing.Size(120, 21);
            this.tb_fail.TabIndex = 8;
            // 
            // tb_success
            // 
            this.tb_success.Location = new System.Drawing.Point(391, 22);
            this.tb_success.Name = "tb_success";
            this.tb_success.Size = new System.Drawing.Size(120, 21);
            this.tb_success.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "失败指令";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "成功指令";
            // 
            // cb_boty
            // 
            this.cb_boty.FormattingEnabled = true;
            this.cb_boty.Location = new System.Drawing.Point(107, 61);
            this.cb_boty.Name = "cb_boty";
            this.cb_boty.Size = new System.Drawing.Size(121, 20);
            this.cb_boty.TabIndex = 4;
            // 
            // cb_port
            // 
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new System.Drawing.Point(107, 23);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(121, 20);
            this.cb_port.TabIndex = 3;
            // 
            // bn_com
            // 
            this.bn_com.Location = new System.Drawing.Point(610, 38);
            this.bn_com.Name = "bn_com";
            this.bn_com.Size = new System.Drawing.Size(75, 23);
            this.bn_com.TabIndex = 2;
            this.bn_com.Text = "打开";
            this.bn_com.UseVisualStyleBackColor = true;
            this.bn_com.Click += new System.EventHandler(this.bn_com_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口";
            // 
            // MesInfo
            // 
            this.MesInfo.ContextMenuStrip = this.right_icon;
            this.MesInfo.Icon = ((System.Drawing.Icon)(resources.GetObject("MesInfo.Icon")));
            this.MesInfo.Text = "MES信息获取";
            this.MesInfo.Visible = true;
            // 
            // right_icon
            // 
            this.right_icon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.right_icon.Name = "right_icon";
            this.right_icon.Size = new System.Drawing.Size(101, 48);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // bn_setSuccess
            // 
            this.bn_setSuccess.Location = new System.Drawing.Point(192, 20);
            this.bn_setSuccess.Name = "bn_setSuccess";
            this.bn_setSuccess.Size = new System.Drawing.Size(37, 75);
            this.bn_setSuccess.TabIndex = 8;
            this.bn_setSuccess.Text = "设置模板";
            this.bn_setSuccess.UseVisualStyleBackColor = true;
            this.bn_setSuccess.Click += new System.EventHandler(this.bn_setSuccess_Click);
            // 
            // bn_setFaild
            // 
            this.bn_setFaild.Location = new System.Drawing.Point(179, 33);
            this.bn_setFaild.Name = "bn_setFaild";
            this.bn_setFaild.Size = new System.Drawing.Size(54, 50);
            this.bn_setFaild.TabIndex = 9;
            this.bn_setFaild.Text = "设置模板";
            this.bn_setFaild.UseVisualStyleBackColor = true;
            this.bn_setFaild.Click += new System.EventHandler(this.bn_setFaild_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PicSrc);
            this.groupBox3.Controls.Add(this.bn_setSuccess);
            this.groupBox3.Location = new System.Drawing.Point(6, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 116);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "过站成功";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PicSrc1);
            this.groupBox4.Controls.Add(this.bn_setFaild);
            this.groupBox4.Location = new System.Drawing.Point(6, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 100);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "过站失败";
            // 
            // PhotoModelSimilarityMatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 699);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.PicDest);
            this.Controls.Add(this.bn_operate);
            this.Controls.Add(this.bn_save);
            this.Controls.Add(this.bn_check);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhotoModelSimilarityMatching";
            this.Text = "PhotoModelSimilarityMatching";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhotoModelSimilarityMatching_FormClosing);
            this.Load += new System.EventHandler(this.PhotoModelSimilarityMatching_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSrc)).EndInit();
            this.gr_info.ResumeLayout(false);
            this.gr_info.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.right_icon.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicSrc1;
        private System.Windows.Forms.PictureBox PicDest;
        private System.Windows.Forms.Button bn_operate;
        private System.Windows.Forms.Button bn_save;
        private System.Windows.Forms.Button bn_check;
        private System.Windows.Forms.PictureBox PicSrc;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.GroupBox gr_info;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bn_com;
        private System.Windows.Forms.ComboBox cb_boty;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.TextBox tb_fail;
        private System.Windows.Forms.TextBox tb_success;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NotifyIcon MesInfo;
        private System.Windows.Forms.ContextMenuStrip right_icon;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bn_setFaild;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bn_setSuccess;
    }
}