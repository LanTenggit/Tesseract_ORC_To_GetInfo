using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesGraphicprocessing
{
    public partial class ReaSonEXENameFindHandle : Form
    {
        public ReaSonEXENameFindHandle()
        {
            InitializeComponent();
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct ProcessEntry32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;


            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }


        [DllImport("KERNEL32.DLL ")]
        public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);
        [DllImport("KERNEL32.DLL ")]
        public static extern int CloseHandle(IntPtr handle);
        [DllImport("KERNEL32.DLL ")]
        public static extern int Process32First(IntPtr handle, ref ProcessEntry32 pe);
        [DllImport("KERNEL32.DLL ")]
        public static extern int Process32Next(IntPtr handle, ref ProcessEntry32 pe);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, string lParam);





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
        //public static IntPtr GetCurrentWindowHandle(uint proid)
        //{
        //    IntPtr ptrWnd = IntPtr.Zero;
        //    uint uiPid = proid;
        //    //object objWnd = processWnd[uiPid];
        //    //if (objWnd != null)
        //    //{
        //    //    ptrWnd = (IntPtr)objWnd;
        //    //    if (ptrWnd != IntPtr.Zero && IsWindow(ptrWnd))  // 从缓存中获取句柄
        //    //    {
        //    //        return ptrWnd;
        //    //    }
        //    //    else
        //    //    {
        //    //        ptrWnd = IntPtr.Zero;
        //    //    }
        //    }
        //    //bool bResult = EnumWindows(new WNDENUMPROC(EnumWindowsProc), uiPid);
        //    //// 枚举窗口返回 false 并且没有错误号时表明获取成功
        //    //if (!bResult && Marshal.GetLastWin32Error() == 0)
        //    //{
        //    //    objWnd = processWnd[uiPid];
        //    //    if (objWnd != null)
        //    //    {
        //    //        ptrWnd = (IntPtr)objWnd;
        //    //    }
        //    //}
        //    return ptrWnd;
        //}


        //private static bool EnumWindowsProc(IntPtr hwnd, uint lParam)
        //{
        //    uint uiPid = 0;
        //    if (GetParent(hwnd) == IntPtr.Zero)
        //    {
        //        GetWindowThreadProcessId(hwnd, ref uiPid);
        //        if (uiPid == lParam)    // 找到进程对应的主窗口句柄
        //        {
        //            processWnd.Add(uiPid, hwnd);   // 把句柄缓存起来
        //            SetLastError(0);    // 设置无错误
        //            return false;   // 返回 false 以终止枚举窗口
        //        }
        //    }
        //    return true;
        //}



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string appName = textBox1.Text;
                Process[] process = Process.GetProcesses();
                for (int i = 0; i < process.Count(); i++)
                {
                    if (process[i].ProcessName.Contains(appName))
                    {
                        process[i].Kill();
                        process[i].WaitForExit(1000);
                        if (!process[i].HasExited)
                        {
                            process[i].Kill();
                        }
                    }
                }
                MessageBox.Show(String.Format("外部程序 {0} 已经退出！", appName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

         
        }
        private void ReaSonEXENameFindHandle_Load(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();
            for (int i = 0; i < process.Count(); i++)
            {
                tb_ProcessList.Text += process[i].ProcessName + "\r\n";
            }

            //IntPtr hh = Process.GetProcessesByName("note")[0].MainWindowHandle;
            //if (hh != IntPtr.Zero)
            //{
            //    SendMessage((int)hh, 0x000C, 0, "A");  //打开记事本，发送字母A
            //}
        }

    }
}
