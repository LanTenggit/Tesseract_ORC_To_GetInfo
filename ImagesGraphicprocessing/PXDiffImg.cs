using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesGraphicprocessing
{
    public partial class PXDiffImg : Form
    {


        enum IS_DEPTH
        {
            IS_DEPTH_8U = 0,
            IS_DEPTH_8S = 1,
            IS_DEPTH_16S = 2,
            IS_DEPTH_32S = 3,
            IS_DEPTH_32F = 4,
            IS_DEPTH_64F = 5,
        };

        enum IS_RET
        {
            IS_RET_OK,
            IS_RET_ERR_OUTOFMEMORY,
            IS_RET_ERR_STACKOVERFLOW,
            IS_RET_ERR_NULLREFERENCE,
            IS_RET_ERR_ARGUMENTOUTOFRANGE,
            IS_RET_ERR_PARAMISMATCH,
            IS_RET_ERR_DIVIDEBYZERO,
            IS_RET_ERR_INDEXOUTOFRANGE,
            IS_RET_ERR_NOTSUPPORTED,
            IS_RET_ERR_OVERFLOW,
            IS_RET_ERR_FILENOTFOUND,
            IS_RET_ERR_UNKNOWN
        };


        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct TMatrix
        {
            public int Width;
            public int Height;
            public int WidthStep;
            public int Channel;
            public int Depth;
            public byte* Data;
            public int Reserved;

            public TMatrix(int Width, int Height, int WidthStep, int Depth, int Channel, byte* Scan0)
            {
                this.Width = Width;
                this.Height = Height;
                this.WidthStep = WidthStep;
                this.Depth = Depth;
                this.Channel = Channel;
                this.Data = Scan0;
                this.Reserved = 0;
            }
        };

        // dll的代码中用的是StdCall，这里也要用StdCall，如果用Cdecl，则会出现对 PInvoke 函数“....”的调用导致堆栈不对称错误，再次按F5又可以运行

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe private static extern IS_RET MatchTemplate(ref TMatrix Src, ref TMatrix Template, ref TMatrix* Dest);

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IS_RET MinMaxLoc(ref TMatrix Src, ref int Min_PosX, ref int Min_PosY, ref int Max_PosX, ref int Max_PosY);

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe private static extern IS_RET IS_FreeMatrix(TMatrix** DstImg);

        Bitmap SrcBmp, DstBmp;
        TMatrix SrcImg, DestImg;







        public PXDiffImg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Contrast_picturePath = Path.GetFullPath("images");
            Contrast_picturePath += "\\11.png";

            string Contrast_picturePath1 = Path.GetFullPath("images");
            Contrast_picturePath1 += "\\11.png";




          byte [] imgbyte  =  FunctionClass.GetImageByte(Contrast_picturePath);
          byte [] imgbyte1 =  FunctionClass.GetImageByte(Contrast_picturePath1);


            string imgstr = FunctionClass.ByteArrayToHexString(imgbyte);
            string imgstr1 = FunctionClass.ByteArrayToHexString(imgbyte1);


            if (imgstr.Contains(imgstr1))
            {
                MessageBox.Show("图片存在！");
            }


          








        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_check_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                DstBmp = (Bitmap)Bmp.Clone();
                Bmp.Dispose();
                PicDest.Image = DstBmp;

            }
        }

        private void PXDiffImg_Load(object sender, EventArgs e)
        {

            ///m_img
            SrcBmp = (Bitmap)PicSrc.Image;
            ///d_img
            DstBmp = (Bitmap)PicDest.Image;

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            saveFileDialog.FilterIndex = 3;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                else if (saveFileDialog.FilterIndex == 2)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                else if (saveFileDialog.FilterIndex == 3)
                    DstBmp.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }
        /// <summary>
        /// 处理图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void bn_operate_Click(object sender, EventArgs e)
        {
            int Min_PosX = 0, Min_PosY = 0, Max_PosX = 0, Max_PosY = 0;
            ///model
            BitmapData SrcBmpData = SrcBmp.LockBits(new Rectangle(0, 0, SrcBmp.Width, SrcBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            ///D-img
            BitmapData DstBmpData = DstBmp.LockBits(new Rectangle(0, 0, DstBmp.Width, DstBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            Stopwatch Sw = new Stopwatch();
            Sw.Start();
            ///model
            SrcImg = new TMatrix(SrcBmp.Width, SrcBmp.Height, SrcBmpData.Stride, (int)IS_DEPTH.IS_DEPTH_8U, 3, (byte*)SrcBmpData.Scan0);
            ///D-img
            DestImg = new TMatrix(DstBmp.Width, DstBmp.Height, DstBmpData.Stride, (int)IS_DEPTH.IS_DEPTH_8U, 3, (byte*)DstBmpData.Scan0);

            TMatrix* Dest = null;
            MatchTemplate(ref DestImg, ref SrcImg, ref Dest);
            MinMaxLoc(ref *Dest, ref Min_PosX, ref Min_PosY, ref Max_PosX, ref Max_PosY);
            IS_FreeMatrix(&Dest);
            SrcBmp.UnlockBits(SrcBmpData);
            DstBmp.UnlockBits(DstBmpData);

            Pen P = new Pen(Color.Red);
            Graphics G = Graphics.FromImage(DstBmp);
            ///绘制矩形框
            G.DrawRectangle(P, new Rectangle(Min_PosX, Min_PosY, SrcImg.Width, SrcImg.Height));
            P.Dispose();
            G.Dispose();

            LblInfo.Text = "图像大小: " + PicSrc.Image.Width.ToString() + " X " + PicSrc.Image.Height.ToString() + ",算法处理用时" + Sw.ElapsedMilliseconds.ToString() + "ms."+DateTime.Now.ToString();
            PicDest.Refresh();
        }
    }
}
