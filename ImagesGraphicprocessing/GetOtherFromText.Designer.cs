namespace ImagesGraphicprocessing
{
    partial class GetOtherFromText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetOtherFromText));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_boty = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bn_set = new System.Windows.Forms.Button();
            this.tb_faild = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_success = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MESInfoIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.S_orther_num = new System.Windows.Forms.Label();
            this.F_orther_num = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "端  口";
            // 
            // cb_port
            // 
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Location = new System.Drawing.Point(65, 19);
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(121, 20);
            this.cb_port.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率";
            // 
            // cb_boty
            // 
            this.cb_boty.FormattingEnabled = true;
            this.cb_boty.Location = new System.Drawing.Point(284, 19);
            this.cb_boty.Name = "cb_boty";
            this.cb_boty.Size = new System.Drawing.Size(121, 20);
            this.cb_boty.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bn_set);
            this.groupBox1.Controls.Add(this.tb_faild);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_success);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_boty);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_port);
            this.groupBox1.Location = new System.Drawing.Point(34, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "传出信息设置";
            // 
            // bn_set
            // 
            this.bn_set.Location = new System.Drawing.Point(293, 119);
            this.bn_set.Name = "bn_set";
            this.bn_set.Size = new System.Drawing.Size(75, 23);
            this.bn_set.TabIndex = 6;
            this.bn_set.Text = "打开";
            this.bn_set.UseVisualStyleBackColor = true;
            this.bn_set.Click += new System.EventHandler(this.bn_set_Click);
            // 
            // tb_faild
            // 
            this.tb_faild.Location = new System.Drawing.Point(284, 79);
            this.tb_faild.Name = "tb_faild";
            this.tb_faild.Size = new System.Drawing.Size(121, 21);
            this.tb_faild.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "失败指令";
            // 
            // tb_success
            // 
            this.tb_success.Location = new System.Drawing.Point(65, 79);
            this.tb_success.Name = "tb_success";
            this.tb_success.Size = new System.Drawing.Size(121, 21);
            this.tb_success.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "成功指令";
            // 
            // MESInfoIcon
            // 
            this.MESInfoIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.MESInfoIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MESInfoIcon.Icon")));
            this.MESInfoIcon.Text = "MES信息获取系统";
            this.MESInfoIcon.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.关闭ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "成功指令发送次数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "失败指令发送次数：";
            // 
            // S_orther_num
            // 
            this.S_orther_num.AutoSize = true;
            this.S_orther_num.Location = new System.Drawing.Point(166, 206);
            this.S_orther_num.Name = "S_orther_num";
            this.S_orther_num.Size = new System.Drawing.Size(11, 12);
            this.S_orther_num.TabIndex = 8;
            this.S_orther_num.Text = "0";
            // 
            // F_orther_num
            // 
            this.F_orther_num.AutoSize = true;
            this.F_orther_num.Location = new System.Drawing.Point(404, 206);
            this.F_orther_num.Name = "F_orther_num";
            this.F_orther_num.Size = new System.Drawing.Size(11, 12);
            this.F_orther_num.TabIndex = 9;
            this.F_orther_num.Text = "0";
            // 
            // GetOtherFromText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 242);
            this.Controls.Add(this.F_orther_num);
            this.Controls.Add(this.S_orther_num);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetOtherFromText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES信息获取系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetOtherFromText_FormClosing);
            this.Load += new System.EventHandler(this.GetOtherFromText_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_boty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bn_set;
        private System.Windows.Forms.TextBox tb_faild;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_success;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon MESInfoIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label S_orther_num;
        private System.Windows.Forms.Label F_orther_num;
    }
}