using ImagesGraphicprocessing.INIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ImagesGraphicprocessing.ReaSonEXENameFindHandle;

namespace ImagesGraphicprocessing
{
    public partial class GetOtherFromText : Form
    {

        const int buffer_size = 1024;
        StringBuilder buffer = new StringBuilder(buffer_size);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindEx")]
        public static extern IntPtr FindEx(IntPtr hwnd, IntPtr hwndChild, string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        [DllImport("user32.dll ", EntryPoint = "GetDlgItem")]
        public static extern IntPtr GetDlgItem(IntPtr hParent, int controlid);
        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int cch);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);
        const int WM_GETTEXT = 0xd;

        public GetOtherFromText()
        {
            InitializeComponent();
        }

        SerialPort serial = new SerialPort();
        INIClassFunction ini = new INIClassFunction();

        int SuccessNum = 0;
        int FaildNum = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr maindHwnd = FindWindow(null, "电子秤与SN信息绑定"); //获得句柄   

            //maindHwnd= GetHandleByProcessName("javaw.exe");


            if (maindHwnd != IntPtr.Zero)
            {
                List<IntPtr> childlist = FindAllChild(maindHwnd);
                for (int j = 0; j < childlist.Count; j++)
                {
                    const int buffer_size = 1024;
                    StringBuilder buffer = new StringBuilder(buffer_size);
                    SendMessage(childlist[j], WM_GETTEXT, buffer_size, buffer);
                    string childstr = buffer.ToString();
                    if (childstr.Contains("过站成功"))
                    {
                        MessageBox.Show("OK!");
                    }
                }
            }
        }





        private void GetOtherFromText_Load(object sender, EventArgs e)
        {
            //button1.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

            string[] port = SerialPort.GetPortNames();
            foreach (var item in port)
            {
                cb_port.Items.Add(item);
            }
            if (ini.IniReadValue("config","port")==""|| ini.IniReadValue("config", "port") == string.Empty)
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
                string a= ini.IniReadValue("config", "boty").ToString();
                cb_boty.SelectedItem = Convert.ToInt32( ini.IniReadValue("config", "boty").ToString());
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

            bn_set_Click(sender,e);


            Thread th_GetHwndInfoSend = new Thread(GetHwndInfoSend);
            th_GetHwndInfoSend.Start();

        }



        ///<summary>
        /// 获取 当前拥有焦点的控件
        ///</summary>
        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
                focusedControl = Control.FromChildHandle(focusedHandle);
            return focusedControl;

        }


        /// <summary>
        /// 获取监控句柄信息并发送指令
        /// </summary>
        public void GetHwndInfoSend()
        {
            string SaveChildstr = null;
            IntPtr NodeHwnd = (IntPtr)0;
            while (true)
            {
                try
                {
                    if (serial.IsOpen)
                    {
                        Thread.Sleep(3000);
                        this.Invoke(new Action(() =>
                        {
                            ///通过标题找句柄
                            IntPtr maindHwnd = FindWindow(null, "电子秤信息解析"); //获得句柄   
                            //maindHwnd= Process.GetProcessesByName("Data_parsing")[0].MainWindowHandle;
                            ///通过进程
                            Process[] pro = Process.GetProcessesByName("javaw");
                            maindHwnd = Process.GetProcessesByName("javaw")[0].MainWindowHandle;

                            if (maindHwnd != IntPtr.Zero)
                            {
                                const int Nodebuffer_size = 1024;
                                StringBuilder Nodebuffer = new StringBuilder(Nodebuffer_size);
                                SendMessage(NodeHwnd, WM_GETTEXT, Nodebuffer_size, Nodebuffer);
                                if (Nodebuffer.ToString() != "" || Nodebuffer.ToString() != string.Empty)
                                {
                                    string NodeChildstr = Nodebuffer.ToString();
                                    if (NodeChildstr.Contains("过站成功"))
                                    {

                                        if (SaveChildstr == NodeChildstr)
                                        {
                                            //MessageBox.Show("不发送指令！");
                                        }
                                        else
                                        {

                                            SuccessNum++;
                                            SuccessOrther();
                                            S_orther_num.Text = SuccessNum.ToString();
                                            //MessageBox.Show("发送成功指令！");
                                            SaveChildstr = NodeChildstr;
                                        }
                                    }

                                    if (NodeChildstr.Contains("过站失败"))
                                    {
                                        if (SaveChildstr == NodeChildstr)
                                        {
                                            //MessageBox.Show("不发送指令！");
                                        }
                                        else
                                        {
                                            FaildNum++;
                                            FaildOrther();
                                            F_orther_num.Text = FaildNum.ToString();
                                            //MessageBox.Show("发送失败指令！");
                                            SaveChildstr = NodeChildstr;
                                        }
                                    }
                                }
                                else
                                {
                                    List<IntPtr> ChildList = FindAllChild(maindHwnd);
                                    for (int j = 0; j < ChildList.Count; j++)
                                    {
                                        const int buffer_size = 1024;
                                        StringBuilder buffer = new StringBuilder(buffer_size);

                                        SendMessage(ChildList[j], WM_GETTEXT, buffer_size, buffer);
                                        string Childstr = buffer.ToString();

                                        if (Childstr.Contains("过站成功"))
                                        {
                                            NodeHwnd = ChildList[j];
                                            if (SaveChildstr == Childstr)
                                            {
                                                //MessageBox.Show("不发送指令！");
                                            }
                                            else
                                            {
                                                SuccessNum++;
                                                SuccessOrther();
                                                S_orther_num.Text = SuccessNum.ToString();
                                                //MessageBox.Show("发送成功指令！");
                                                SaveChildstr = Childstr;
                                            }
                                        }

                                        if (Childstr.Contains("过站失败"))
                                        {
                                            NodeHwnd = ChildList[j];
                                            if (SaveChildstr == Childstr)
                                            {
                                                //MessageBox.Show("不发送指令！");
                                            }
                                            else
                                            {
                                                FaildNum++;
                                                FaildOrther();
                                                F_orther_num.Text = FaildNum.ToString();
                                                //MessageBox.Show("发送失败指令！");
                                                SaveChildstr = Childstr;
                                            }
                                        }

                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("没有找到窗口");
                            }
                        }));

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("");
                   
                }
            }

        }
        /// <summary>
        /// 设置按钮
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
                    ini.IniWriteValue("config","success",tb_success.Text);
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
            catch (Exception )
            {

                MessageBox.Show("串口不存在或被占用！");
            }


        }

        /// <summary>
        /// 查找所有的句柄
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static List<IntPtr> FindAllChild(IntPtr parent)
        {
            List<IntPtr> allchild = new List<IntPtr>();
            allchild.Add(parent);   //第一个添加父句柄，最后再删除
            for (int i = 0; i < allchild.Count; i++)
            {
                IntPtr patenttemp = allchild[i];
                IntPtr hwnd = FindWindowEx(patenttemp, IntPtr.Zero, null, null);
                while (hwnd != IntPtr.Zero)
                {
                    allchild.Add(hwnd);
                    hwnd = FindWindowEx(patenttemp, hwnd, null, null);
                }
            }
            allchild.RemoveAt(0);
            return allchild;
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

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Show();
            

        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void GetOtherFromText_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        /// <summary>
        /// 获取句柄
        /// </summary>
        /// <param name="ProcessName"></param>
        /// <returns></returns>

        //public IntPtr GetHandleByProcessName(string ProcessName)
        //{
        //    List<ProcessEntry32> list = new List<ProcessEntry32>();
        //    IntPtr handle = CreateToolhelp32Snapshot(0x2, 0);
        //    IntPtr hh = IntPtr.Zero;
        //    if ((int)handle > 0)
        //    {
        //        ProcessEntry32 pe32 = new ProcessEntry32();
        //        pe32.dwSize = (uint)Marshal.SizeOf(pe32);
        //        int bMore = Process32First(handle, ref pe32);
        //        while (bMore == 1)
        //        {
        //            IntPtr temp = Marshal.AllocHGlobal((int)pe32.dwSize);
        //            Marshal.StructureToPtr(pe32, temp, true);
        //            ProcessEntry32 pe = (ProcessEntry32)Marshal.PtrToStructure(temp, typeof(ProcessEntry32));
        //            Marshal.FreeHGlobal(temp);
        //            list.Add(pe);
        //            if (pe.szExeFile == ProcessName)
        //            {
        //                bMore = 2;
        //                hh = GetCurrentWindowHandle(pe.th32ProcessID);
        //                break;
        //            }
        //            bMore = Process32Next(handle, ref pe32);
        //        }
        //    }
        //    return hh;
        //}


    }
}
