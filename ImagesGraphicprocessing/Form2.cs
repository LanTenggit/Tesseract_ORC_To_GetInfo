using ImagesGraphicprocessing.INIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace ImagesGraphicprocessing
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        INIClassFunction ini = new INIClassFunction();
        SerialPort serial = new SerialPort();




        string SaveOrcstr = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string imgpath = Path.GetFullPath("images");
            imgpath += "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            try
            {
                //获得当前屏幕的分辨率   
                Screen scr = Screen.PrimaryScreen;
                Rectangle rc = scr.Bounds;
                int iWidth = rc.Width;
                int iHeight = rc.Height;
                //创建一个和屏幕一样大的Bitmap  
                Image myImage = new Bitmap(iWidth, iHeight);
                //从一个继承自Image类的对象中创建Graphics对象  
                Graphics g = Graphics.FromImage(myImage);
                //抓屏并拷贝到myimage里 
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
                //保存为文件 
                myImage.Save(imgpath);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            //MessageBox.Show("截图成功！文件保存路径为:" + imgpath);
            string saveimgPath = Path.GetFullPath("images") + "\\save" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            //CaptureImage(imgpath,100,100, saveimgPath,500,500);

            //byte[] jieimg = FunctionClass.GetImageByte(imgpath);
            //string jieimgstr = FunctionClass.ByteArrayToHexString(jieimg);
            string Contrast_picturePath = Path.GetFullPath("images");
            Contrast_picturePath += "\\12.png";

            #region tessract_orc文字识别
            string ocrTtxt = "";
            //chi_sim是中文库
            const string language = "chi_sim";
            //Nuget安装的Tessract版本为3.20，tessdata的版本必须与其匹配，另外路径最后必须以"\"或者"/"结尾
            string TessractData = AppDomain.CurrentDomain.BaseDirectory + @"tessdata\";
            TesseractEngine test = new TesseractEngine(TessractData, language);
            //创建一个图片对象
            Bitmap tmpVal = new Bitmap(Contrast_picturePath);
            //灰度化，可以提高识别率
            var tmpImage = FunctionClass.ToGray(tmpVal);
            Page tmpPage = test.Process(tmpImage);
            ocrTtxt = tmpPage.GetText();
            tmpVal.Dispose();
            #endregion
            string ISSuccessContain = "";
            if (ocrTtxt.Contains("逗站完肱"))
            {
                ISSuccessContain = "Success";
            }
            if (ocrTtxt.Contains("二 手动芳茁湿"))
            {
                ISSuccessContain = "Fail";
            }

            if (ocrTtxt != SaveOrcstr)
            {
                SaveOrcstr = ocrTtxt;
                if (ISSuccessContain == "Success")
                {
                    SuccessOrther();
                    MessageBox.Show("SendSuccessOrther!");
                }
                else if (ISSuccessContain == "Fail")
                {
                    FaildOrther();
                    MessageBox.Show("SendFaildOrther!");

                }
            }
            else
            {
                MessageBox.Show("文件相同！");
            }




            //string Contraststr = FunctionClass.ByteArrayToHexString(FunctionClass.GetImageByte(Contrast_picturePath));


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            string[] port = SerialPort.GetPortNames();
            foreach (var item in port)
            {
                cb_port.Items.Add(item);
            }
            if (ini.IniReadValue("config", "port") == "" || ini.IniReadValue("config", "port") == string.Empty)
            {
                cb_port.SelectedItem = cb_port.Items[0];
            }
            else
            {
                cb_port.SelectedItem = ini.IniReadValue("config", "port").ToString();
            }

            int[] boty = { 2400, 4800, 9600, 115200 };
            foreach (var item in boty)
            {
                cb_boty.Items.Add(item);
            }

            if (ini.IniReadValue("config", "boty") == "" || ini.IniReadValue("config", "boty") == string.Empty)
            {
                cb_boty.SelectedItem = cb_boty.Items[2];
            }
            else
            {
                string a = ini.IniReadValue("config", "boty").ToString();
                cb_boty.SelectedItem = Convert.ToInt32(ini.IniReadValue("config", "boty").ToString());
            }

            if (ini.IniReadValue("config", "success") == "" || ini.IniReadValue("config", "success") == string.Empty)
            {

            }
            else
            {
                tb_success.Text = ini.IniReadValue("config", "success").ToString();
            }

            if (ini.IniReadValue("config", "faild") == "" || ini.IniReadValue("config", "faild") == string.Empty)
            {

            }
            else
            {
                tb_faild.Text = ini.IniReadValue("config", "faild").ToString();
            }

            bn_set_Click(sender, e);


            Thread th_sendOrther = new Thread(Th_Send);
            th_sendOrther.Start();

        }


        #region 从大图中截取一部分图片
        /// <summary>
        /// 从大图中截取一部分图片
        /// </summary>
        /// <param name="fromImagePath">来源图片地址</param>        
        /// <param name="offsetX">从偏移X坐标位置开始截取</param>
        /// <param name="offsetY">从偏移Y坐标位置开始截取</param>
        /// <param name="toImagePath">保存图片地址</param>
        /// <param name="width">保存图片的宽度</param>
        /// <param name="height">保存图片的高度</param>
        /// <returns></returns>
        public void CaptureImage(string fromImagePath, int offsetX, int offsetY, string toImagePath, int width, int height)
        {
            //原图片文件
            Image fromImage = Image.FromFile(fromImagePath);
            //创建新图位图
            Bitmap bitmap = new Bitmap(width, height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            graphic.DrawImage(fromImage, 0, 0, new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //保存图片
            saveImage.Save(toImagePath, System.Drawing.Imaging.ImageFormat.Png);
            //释放资源 
            fromImage.Dispose();
            saveImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();
        }


        #endregion
        /// <summary>
        /// 设置通讯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bn_set_Click(object sender, EventArgs e)
        {
            try
            {
                if (serial.IsOpen == false)
                {
                    serial.PortName = cb_port.SelectedItem.ToString();
                    serial.BaudRate = Convert.ToInt32(cb_boty.SelectedItem.ToString());
                    serial.Parity = Parity.None;
                    serial.StopBits = StopBits.One;
                    serial.Handshake = Handshake.None;

                    if (tb_success.Text == "" || tb_success.Text == string.Empty || tb_faild.Text == "" || tb_faild.Text == string.Empty)
                    {
                        MessageBox.Show("指令不可为空！");
                        return;
                    }
                    serial.Open();
                    ini.IniWriteValue("config", "port", cb_port.Text);
                    ini.IniWriteValue("config", "boty", cb_boty.Text);
                    ini.IniWriteValue("config", "success", tb_success.Text);
                    ini.IniWriteValue("config", "faild", tb_faild.Text);
                    this.cb_port.Enabled = false;
                    this.cb_boty.Enabled = false;
                    this.tb_success.Enabled = false;
                    this.tb_faild.Enabled = false;
                    this.bn_set.Text = "关闭";

                }
                else
                {
                    serial.Close();
                    this.cb_port.Enabled = true;
                    this.cb_boty.Enabled = true;
                    this.tb_success.Enabled = true;
                    this.tb_faild.Enabled = true;
                    this.bn_set.Text = "打开";

                }
            }
            catch (Exception)
            {

                MessageBox.Show("串口不存在或被占用！");
            }
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
                string faildstr = tb_faild.Text;
                Byte[] buffer = FunctionClass.StringTobyte(faildstr);
                serial.Write(buffer, 0, buffer.Count());
            }
            catch (Exception ex)
            {
            }


        }

        /// <summary>
        /// 指令线程
        /// </summary>
        public void Th_Send()
        {


            //获得当前屏幕的分辨率   
            Screen scr = Screen.PrimaryScreen;
            Rectangle rc = scr.Bounds;
            int iWidth = rc.Width;
            int iHeight = rc.Height;
            //创建一个和屏幕一样大的Bitmap  
            Image myImage = new Bitmap(iWidth, iHeight);
            //从一个继承自Image类的对象中创建Graphics对象  
            Graphics g = Graphics.FromImage(myImage);

            while (true)
            {
                try
                {

                    if (serial.IsOpen)
                    {

                   
                    string imgpath = Path.GetFullPath("images");
                    imgpath += "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                    //this.Invoke(new Action(() =>
                    //{
                    //Thread.Sleep(1000);
                    //抓屏并拷贝到myimage里 
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
                    //保存为文件 

                    //Bitmap map =(Bitmap) myImage;
                    //map= FunctionClass.ToGray(map);
                    //myImage = map;
                    myImage.Save(imgpath);
                    string Contrast_picturePath = Path.GetFullPath("images");
                    Contrast_picturePath += "\\3.png";

                    #region tessract_orc文字识别
                    string ocrTtxt = "";
                    //chi_sim是中文库
                    const string language = "chi_sim";
                    //Nuget安装的Tessract版本为3.20，tessdata的版本必须与其匹配，另外路径最后必须以"\"或者"/"结尾

                    //this.Invoke(new Action(() =>
                    //{
                        string TessractData = AppDomain.CurrentDomain.BaseDirectory + @"tessdata\";
                        TesseractEngine test = new TesseractEngine(TessractData, language);

                        //创建一个图片对象
                        Bitmap tmpVal = new Bitmap(Contrast_picturePath);
                        //灰度化，可以提高识别率
                        var tmpImage = FunctionClass.ToGray(tmpVal);
                        Page tmpPage = test.Process(tmpImage);
                        //ocrTtxt = tmpPage.GetText();
                        ocrTtxt = tmpPage.GetText();

                        test.Dispose();
                        tmpVal.Dispose();
                    //}));
                    #endregion
                    string ISSuccessContain = "";
                    if (ocrTtxt.Contains("逗站完肱"))
                    {
                        ISSuccessContain = "Success";
                    }
                    if (ocrTtxt.Contains("二 手动芳茁湿"))
                    {
                        ISSuccessContain = "Fail";
                    }
                    //if (ocrTtxt != SaveOrcstr)
                    //{
                    SaveOrcstr = ocrTtxt;
                    if (ISSuccessContain == "Success")
                    {
                        SuccessOrther();
                        //MessageBox.Show("SendSuccessOrther!");
                    }
                    else if (ISSuccessContain == "Fail")
                    {
                        FaildOrther();
                        //MessageBox.Show("SendFaildOrther!");
                    }
                    else if (ISSuccessContain == "")
                    {
                        string orther = "0";
                        Byte[] buffer = FunctionClass.StringTobyte(orther);
                        serial.Write(buffer, 0, buffer.Count());
                    }
                        //}
                        //else
                        //{

                        //    string orther = "相同文件";
                        //    Byte[] buffer = FunctionClass.StringTobyte(orther);
                        //    serial.Write(buffer, 0, buffer.Count());
                        //    //MessageBox.Show("文件相同！");
                        //}
                        //}));


                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    //throw;
                }
            }

        }

        static void Thresholding(Bitmap img1)
        {
            int[] histogram = new int[256];
            int minGrayValue = 255, maxGrayValue = 0;
            //求取直方图
            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    Color pixelColor = img1.GetPixel(i, j);
                    histogram[pixelColor.R]++;
                    if (pixelColor.R > maxGrayValue) maxGrayValue = pixelColor.R;
                    if (pixelColor.R < minGrayValue) minGrayValue = pixelColor.R;
                }
            }
            //迭代计算阀值
            int threshold = -1;
            int newThreshold = (minGrayValue + maxGrayValue) / 2;
            for (int iterationTimes = 0; threshold != newThreshold && iterationTimes < 100; iterationTimes++)
            {
                threshold = newThreshold;
                int lP1 = 0;
                int lP2 = 0;
                int lS1 = 0;
                int lS2 = 0;
                //求两个区域的灰度的平均值
                for (int i = minGrayValue; i < threshold; i++)
                {
                    lP1 += histogram[i] * i;
                    lS1 += histogram[i];
                }
                int mean1GrayValue = (lP1 / lS1);
                for (int i = threshold + 1; i < maxGrayValue; i++)
                {
                    lP2 += histogram[i] * i;
                    lS2 += histogram[i];
                }
                int mean2GrayValue = (lP2 / lS2);
                newThreshold = (mean1GrayValue + mean2GrayValue) / 2;
            }
            //计算二值化
            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    Color pixelColor = img1.GetPixel(i, j);
                    if (pixelColor.R > threshold) img1.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    else img1.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
        }


    }
}
