using Emgu.CV;
using Emgu.CV.Structure;
using ImagesGraphicprocessing.INIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesGraphicprocessing
{
    public partial class PhotoModelSimilarityMatching : Form
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
        public PhotoModelSimilarityMatching()
        {
            InitializeComponent();
        }



        // dll的代码中用的是StdCall，这里也要用StdCall，如果用Cdecl，则会出现对 PInvoke 函数“....”的调用导致堆栈不对称错误，再次按F5又可以运行

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe private static extern IS_RET MatchTemplate(ref TMatrix Src, ref TMatrix Template, ref TMatrix* Dest);

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern IS_RET MinMaxLoc(ref TMatrix Src, ref int Min_PosX, ref int Min_PosY, ref int Max_PosX, ref int Max_PosY);

        [DllImport("ImageProcessing.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe private static extern IS_RET IS_FreeMatrix(TMatrix** DstImg);

        Bitmap SrcBmp, DstBmp;
        TMatrix SrcImg, DestImg;

        Bitmap SuccessBmp;
        Bitmap FaildBmp;

        /// <summary>
        /// 最大相似度
        /// </summary>
        double MaxsImilarity = 0;
        /// <summary>
        /// 最小相似度
        /// </summary>
        double MInImilarity = 0;
        /// <summary>
        /// 传输数据串口
        /// </summary>
        SerialPort serial = new SerialPort();
        /// <summary>
        /// ini方法类
        /// </summary>
        INIClassFunction ini = new INIClassFunction();
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
        /// <summary>
        /// 保存图片
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
        /// 图片处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        unsafe private void bn_operate_Click(object sender, EventArgs e)
        {

            try
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

                Image<Bgr, Byte> SrcimageCV = new Image<Bgr, byte>(SrcBmp); //Image Class from Emgu.CV
                Mat srcmat = SrcimageCV.Mat;
                Image<Bgr, Byte> DstimageCV = new Image<Bgr, byte>(DstBmp); //Image Class from Emgu.CV
                Mat Dstmat = DstimageCV.Mat;
                ///矩阵最大最小相似度
                GetMatchPos(srcmat, Dstmat);

                Pen P = new Pen(Color.Red);
                Graphics G = Graphics.FromImage(DstBmp);
                ///绘制矩形框
                G.DrawRectangle(P, new Rectangle(Min_PosX, Min_PosY, SrcImg.Width, SrcImg.Height));
                P.Dispose();
                G.Dispose();

                LblInfo.Text = "最大相似度：" + MaxsImilarity + "最小相似度：" + MInImilarity + "图像大小: " + PicSrc.Image.Width.ToString() + " X " + PicSrc.Image.Height.ToString() + ",算法处理用时" + Sw.ElapsedMilliseconds.ToString() + "ms." + DateTime.Now.ToString();
                PicDest.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 串口打开关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_com_Click(object sender, EventArgs e)
        {

            if (serial.IsOpen)
            {

                this.cb_port.Enabled = true;
                this.cb_boty.Enabled = true;
                this.tb_success.Enabled = true;
                this.tb_fail.Enabled = true;
                serial.Close();
                this.bn_com.Text = "打开";

            }
            else
            {

                serial.PortName = this.cb_port.SelectedItem.ToString();
                serial.BaudRate = Convert.ToInt32(this.cb_boty.SelectedItem.ToString());
                serial.StopBits = StopBits.One;
                serial.Parity = Parity.None;
                serial.Handshake = Handshake.None;
                ini.IniWriteValue("config", "port", cb_port.Text);
                ini.IniWriteValue("config", "boty", cb_boty.Text);
                ini.IniWriteValue("config", "success", tb_success.Text);
                ini.IniWriteValue("config", "faild", tb_fail.Text);
                this.cb_port.Enabled = false;
                this.cb_boty.Enabled = false;
                this.tb_success.Enabled = false;
                this.tb_fail.Enabled = false;
                this.bn_com.Text = "关闭";
                serial.Open();
            }




        }
        /// <summary>
        /// 加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhotoModelSimilarityMatching_Load(object sender, EventArgs e)
        {

            //'判断程序是否打开并只允许一个软件运行
            Process[] _processes = Process.GetProcessesByName("ImagesGraphicprocessing");
            if (_processes.Length>1)
            {
                Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
            }

            ///m_img
            SrcBmp = (Bitmap)PicSrc.Image;
            ///d_img
            DstBmp = (Bitmap)PicDest.Image;
            string[] prot = SerialPort.GetPortNames();
            for (int i = 0; i < prot.Count(); i++)
            {
                cb_port.Items.Add(prot[i]);
            }

            int[] boty = { 1200, 2400, 4800, 9600, 115200 };

            for (int i = 0; i < boty.Count(); i++)
            {
                cb_boty.Items.Add(boty[i]);
            }

            if (ini.IniReadValue("config", "port") == "" || ini.IniReadValue("config", "port") == string.Empty)
            {
                cb_port.SelectedItem = cb_port.Items[0];
            }
            else
            {
                cb_port.SelectedItem = ini.IniReadValue("config", "port").ToString();
            }

            if (ini.IniReadValue("config", "boty") == "" || ini.IniReadValue("config", "boty") == string.Empty)
            {
                cb_boty.SelectedItem = cb_boty.Items[0];
            }
            else
            {
                //string z = ini.IniReadValue("config", "boty").ToString();
                cb_boty.SelectedItem = Convert.ToInt32(ini.IniReadValue("config", "boty").ToString());
            }

            if (ini.IniReadValue("config", "success") == "" || ini.IniReadValue("config", "success") == string.Empty)
            {
                tb_success.Text = "";
            }
            else
            {
                tb_success.Text = ini.IniReadValue("config", "success").ToString();
            }

            if (ini.IniReadValue("config", "faild") == "" || ini.IniReadValue("config", "faild") == string.Empty)
            {
                tb_fail.Text = "";
            }
            else
            {
                tb_fail.Text = ini.IniReadValue("config", "faild").ToString();
            }

            bn_com_Click(sender, e);


            ///成功图片路径
            string Success_picturePath = Path.GetFullPath("ImgConfig");
            Success_picturePath += "\\3.png";
            SuccessBmp = (Bitmap)Bitmap.FromFile(Success_picturePath);
            ///失败图片路径
            string Faild_picturePath = Path.GetFullPath("ImgConfig");
            Faild_picturePath += "\\4.png";
            FaildBmp = (Bitmap)Bitmap.FromFile(Faild_picturePath);


            Thread th_template_matching = new Thread(JietuSendOrther);
            th_template_matching.Start();
        }





        /// <summary>
        /// 获取匹配图像的位置
        /// </summary>
        /// <param name="Src">被匹配的源图像</param>
        /// <param name="Template">模板图像</param>
        /// <returns>匹配位置</returns>
        Rectangle GetMatchPos(Mat Src, Mat Template)
        {
            Mat MatchResult = new Mat();//匹配结果
            CvInvoke.MatchTemplate(Src, Template, MatchResult, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);//使用相关系数法匹配
            Point max_loc = new Point();
            Point min_loc = new Point();
            double max = 0, min = 0;
            CvInvoke.MinMaxLoc(MatchResult, ref min, ref max, ref min_loc, ref max_loc);//获得极值信息
            //this.label1.Text = "\r\nX:" + max_loc.X + " Y:" + max_loc.Y + " 最大相似度:" + max + " 最小相似度:" + min;
            MaxsImilarity = max;
            MInImilarity = min;
            return new Rectangle(max_loc, Template.Size);
        }


        double Successmax = 0;
        /// <summary>
        ///  获取相似图片模板匹配信息
        /// </summary>
        /// <param name="Success">过站成功的图形矩阵</param>
        /// <param name="Fail">过站失败的图形矩阵</param>
        /// <param name="Template">匹配模板</param>
        /// <returns></returns>
        public string GetResemble(Mat Success, Mat Fail, Mat Template)
        {
            Mat MatchResultSuccess = new Mat();//匹配结果
            Mat MatchResultFaild = new Mat();//匹配结果
            CvInvoke.MatchTemplate(Success, Template, MatchResultSuccess, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);//使用相关系数法匹配
            CvInvoke.MatchTemplate(Fail, Template, MatchResultFaild, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);//使用相关系数法匹配
            Point max_loc = new Point();
            Point min_loc = new Point();
            double Successmin = 0;
            double Faildmax = 0, Faildmin = 0;
            //this.label1.Text = "\r\nX:" + max_loc.X + " Y:" + max_loc.Y + " 最大相似度:" + max + " 最小相似度:" + min;
            CvInvoke.MinMaxLoc(MatchResultSuccess, ref Successmin, ref Successmax, ref min_loc, ref max_loc);//获得极值信息
            CvInvoke.MinMaxLoc(MatchResultFaild, ref Faildmin, ref Faildmax, ref min_loc, ref max_loc);//获得极值信息
            string TemplatePipei = "";

            if (Successmax >= 0.99)
            {
                TemplatePipei = "Success";
                MaxsImilarity = Successmax;
                MInImilarity = Successmin;
            }
            if (Faildmax >= 0.99)
            {
                TemplatePipei = "Faild";
                MaxsImilarity = Faildmax;
                MInImilarity = Faildmin;
            }
            return TemplatePipei;

        }








        /// <summary>
        /// 保存的图片
        /// </summary>
        byte[] SaveimgByte;
        /// <summary>
        /// 截图并比较模板发送指令
        /// </summary>
        unsafe public void JietuSendOrther()
        {

            //获得当前屏幕的分辨率   
            Screen scr = Screen.PrimaryScreen;
            Rectangle rc = scr.Bounds;
            int iWidth = rc.Width;
            int iHeight = rc.Height;
            //创建一个和屏幕一样大的Bitmap  
            Image myImage = new Bitmap(iWidth, iHeight - 50);
            //Image myImage = new Bitmap(688, 520);
            //从一个继承自Image类的对象中创建Graphics对象  
            Graphics g = Graphics.FromImage(myImage);
            while (true)
            {
                try
                {
                    if (serial.IsOpen)
                    {
                        Thread.Sleep(1000);

                        string FilePath = Path.GetFullPath("images");
                        int FileNum = FunctionClass.GetFileNum(FilePath);
                        if (FileNum>30*60)
                        {
                            FunctionClass.DelectDir(FilePath);
                        }
                        string imgpath = Path.GetFullPath("images");
                        imgpath += "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                       
                        //抓屏并拷贝到myimage里 
                        g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
                        //保存为文件
                        myImage.Save(imgpath);
                        string Contrast_picturePath = imgpath;

                        byte[] JieTuByte = FunctionClass.GetImageByte(Contrast_picturePath);
                        if (JieTuByte == SaveimgByte)
                        {

                        }
                        else
                        {
                            SaveimgByte = JieTuByte;
                            #region"second"

                            //Bitmap Bmp = (Bitmap)Bitmap.FromFile(Contrast_picturePath);
                            //DstBmp = (Bitmap)Bmp.Clone();


                            ////int Min_PosX = 0, Min_PosY = 0, Max_PosX = 0, Max_PosY = 0;
                            /////model
                            ////BitmapData SrcBmpData = SrcBmp.LockBits(new Rectangle(0, 0, SrcBmp.Width, SrcBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                            ///////D-img
                            ////BitmapData DstBmpData = DstBmp.LockBits(new Rectangle(0, 0, DstBmp.Width, DstBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                            ////Stopwatch Sw = new Stopwatch();
                            ////Sw.Start();
                            ///////model
                            ////SrcImg = new TMatrix(SrcBmp.Width, SrcBmp.Height, SrcBmpData.Stride, (int)IS_DEPTH.IS_DEPTH_8U, 3, (byte*)SrcBmpData.Scan0);
                            ///////D-img
                            ////DestImg = new TMatrix(DstBmp.Width, DstBmp.Height, DstBmpData.Stride, (int)IS_DEPTH.IS_DEPTH_8U, 3, (byte*)DstBmpData.Scan0);
                            ////TMatrix* Dest = null;
                            ////MatchTemplate(ref DestImg, ref SrcImg, ref Dest);

                            ////MinMaxLoc(ref *Dest, ref Min_PosX, ref Min_PosY, ref Max_PosX, ref Max_PosY);
                            ////IS_FreeMatrix(&Dest);
                            ////SrcBmp.UnlockBits(SrcBmpData);
                            ////DstBmp.UnlockBits(DstBmpData);

                            //Image<Bgr, Byte> SrcimageCV = new Image<Bgr, byte>(SrcBmp); //Image Class from Emgu.CV
                            //Mat srcmat = SrcimageCV.Mat;
                            //Image<Bgr, Byte> DstimageCV = new Image<Bgr, byte>(DstBmp); //Image Class from Emgu.CV
                            //Mat Dstmat = DstimageCV.Mat;
                            /////矩阵最大最小相似度
                            //GetMatchPos(srcmat, Dstmat);



                            //string Successstr = " tb_success" + MaxsImilarity;
                            //Byte[] buffer = FunctionClass.StringTobyte(Successstr);
                            //serial.Write(buffer, 0, buffer.Count());

                            #endregion

                            #region"old"
                            Mat SuccessMat = null;
                            Mat FailMat = null;
                            Mat JieTuMat = null;
                            ///截图矩阵
                            Bitmap JieTuBmp = (Bitmap)Bitmap.FromFile(Contrast_picturePath);
                            Image<Bgr, Byte> JieTuimageCV = new Image<Bgr, byte>(JieTuBmp);
                            JieTuMat = JieTuimageCV.Mat;

                            ///成功模板矩阵
                            Image<Bgr, Byte> SuccessimageCV = new Image<Bgr, byte>(SuccessBmp);
                            SuccessMat = SuccessimageCV.Mat;
                            ///失败模板矩阵
                            Image<Bgr, Byte> FaildBmpimageCV = new Image<Bgr, byte>(FaildBmp);
                            FailMat = FaildBmpimageCV.Mat;
                            string ISSuccess = GetResemble(SuccessMat, FailMat, JieTuMat);

                            //string Successstr = " tb_success" + Successmax;
                            //Byte[] buffer = FunctionClass.StringTobyte(Successstr);
                            //serial.Write(buffer, 0, buffer.Count());


                            if (ISSuccess == "Success")
                            {
                                SuccessOrther();
                            }
                            else if (ISSuccess == "Faild")
                            {
                                FaildOrther();
                            }
                            else
                            {
                                string orther = "0";
                                Byte[] buffer = FunctionClass.StringTobyte(orther);
                                serial.Write(buffer, 0, buffer.Count());
                            }

                            #endregion



                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }


            }



        }
        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;


        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process.GetCurrentProcess().Kill();

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhotoModelSimilarityMatching_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }


        /// <summary>
        /// 成功指令
        /// </summary>
        /// <returns></returns>
        public void SuccessOrther()
        {
            try
            {
                string Successstr = tb_success.Text;
                Byte[] buffer = FunctionClass.StringTobyte(Successstr);
                serial.Write(buffer, 0, buffer.Count());
            }
            catch (Exception ex)
            {


            }

        }

        /// <summary>
        /// 失败指令
        /// </summary>
        /// <returns></returns>
        public void FaildOrther()
        {
            try
            {
                string faildstr = tb_fail.Text;
                Byte[] buffer = FunctionClass.StringTobyte(faildstr);
                serial.Write(buffer, 0, buffer.Count());
            }
            catch (Exception ex)
            {
            }


        }
        /// <summary>
        /// 设置成功模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_setSuccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                SuccessBmp = (Bitmap)Bmp.Clone();
                Bmp.Dispose();
                PicSrc.Image = SuccessBmp;

            }



        }
        /// <summary>
        /// 设置失败模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_setFaild_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files(*.*) |*.*|Bitmap files (*.Bitmap)|*.Bmp|Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap Bmp = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                FaildBmp = (Bitmap)Bmp.Clone();
                Bmp.Dispose();
                PicSrc1.Image = FaildBmp;

            }
        }


        /// <summary>
        /// 二值化
        /// </summary>
        /// <returns></returns>
        public Bitmap binarization(Bitmap bitImage)
        {
            //Bitmap bitImage = new Bitmap(pictureBox1.Image);//二值化pictureBox1中的图片
            Color c;
            int height = bitImage.Height; 

            int width = bitImage.Width;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    c = bitImage.GetPixel(j, i);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    if ((r + g + b) / 3 >= 127)
                    {
                        bitImage.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        bitImage.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            return bitImage;

        }


        /// <summary>
        /// Resize图片
        /// </summary>
        /// <param name="bmp">原始Bitmap</param>
        /// <param name="newW">新的宽度</param>
        /// <param name="newH">新的高度</param>
        /// <returns>处理以后的Bitmap</returns>
        public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }


    }
}
