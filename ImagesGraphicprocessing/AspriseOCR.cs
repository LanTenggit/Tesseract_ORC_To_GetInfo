﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesGraphicprocessing
{
    public partial class AspriseOCR : Form
    {
        public AspriseOCR()
        {
            InitializeComponent();
        }

        #region DllImport
        [DllImport("AspriseOCR.dll", EntryPoint = "OCR", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OCR(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpart", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRpart(string file, int type, int startX, int startY, int width, int height);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRBarCodes", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRBarCodes(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpartBarCodes", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRpartBarCodes(string file, int type, int startX, int startY, int width, int height);
        #endregion

        #region 转换按钮事件

        #endregion
        private void btn_imgpath_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txt_imgpath.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int startX = 0;
            int startY = 0;
            int width = -1;
            int height = -1;

            string img_path = txt_imgpath.Text; // 图片路径
            if (String.IsNullOrEmpty(img_path)) // 图片非空验证
            {
                MessageBox.Show("请先选择图片！");
                return;
            }
            try
            {
                Image img = Image.FromFile(img_path);
                width = img.Width;
                height = img.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            txt_result.Text = Marshal.PtrToStringAnsi(OCRpart(img_path, -1, startX, startY, width, height));
        }



        private void txt_result_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_imgpath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
