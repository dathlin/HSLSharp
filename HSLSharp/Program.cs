using HSLSharp.SettingsSupport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSLSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 日志实例化
            Util.LogNet = new HslCommunication.LogNet.LogNetDateTime( Application.StartupPath + "\\Logs",HslCommunication.LogNet.GenerateMode.ByEveryDay );

            Process process = Process.GetCurrentProcess( );
            // 遍历应用程序的同名进程组
            foreach (Process p in Process.GetProcessesByName( process.ProcessName ))
            {
                // 不是同一进程则关闭刚刚创建的进程
                if (p.Id != process.Id)
                {
                    // 此处显示原先的窗口需要一定的时间，不然无法显示
                    ShowWindowAsync( p.MainWindowHandle, 9 );
                    SetForegroundWindow( p.MainWindowHandle );
                    System.Threading.Thread.Sleep( 10 );
                    Application.Exit( ); // 关闭当前的应用程序
                    return;
                }
            }
            // 设置应用程序的线程池数量，防止服务器端卡死状态，根据内存及CPU进行更改
            System.Threading.ThreadPool.SetMaxThreads( 1000, 256 );

            // 加载系统基础的配置信息
            Util.SharpSettings = new SharpSettings( );
            Util.SharpSettings.FileSavePath = "Settings.txt";
            Util.SharpSettings.LoadByFile( );

            // 加载系统的规则配置器
            Util.SharpRegulars = new SharpRegulars( );
            Util.SharpRegulars.FilePath = "RegularSettings.xml";
            Util.SharpRegulars.LoadRegulars( );

            HslCommunication.BasicFramework.SoftMail.MailSystem163.MailSendAddress = "hsl200909@163.com";
            AppDomain.CurrentDomain.UnhandledException += Util.CurrentDomain_UnhandledException;

            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new FormServer( ) );
        }

        

        [DllImport( "User32.dll" )]
        private static extern bool ShowWindowAsync( IntPtr hWnd, int cmdShow );

        [DllImport( "User32.dll" )]
        private static extern bool SetForegroundWindow( IntPtr hWnd );
    }
}
