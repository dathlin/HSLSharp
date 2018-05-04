using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HslCommunication.LogNet;
using HSLSharp.SettingsSupport;
using HSLSharp.Configuration;
using System.Drawing;

namespace HSLSharp
{
    /// <summary>
    /// 本系统的静态工具对象
    /// </summary>
    public class Util
    {
        /// <summary>
        /// 系统的日志存储
        /// </summary>
        public static ILogNet LogNet { get; set; }

        /// <summary>
        /// 系统的所有的图片资源信息
        /// </summary>
        public static ImageList SharpImageList { get; set; }

        /// <summary>
        /// 系统的所有的配置信息
        /// </summary>
        public static SharpSettings SharpSettings { get; set; }
        
        /// <summary>
        /// 系统的所有的解析规则配置器
        /// </summary>
        public static SharpRegulars SharpRegulars { get; set; }

        /// <summary>
        /// 系统的版本号
        /// </summary>
        public static Version SharpVersion { get; } = new Version( "0.0.2" );

        #region Static Method

        /// <summary>
        /// 子窗口的图标显示信息
        /// </summary>
        /// <returns></returns>
        public static Icon GetWinformICon( )
        {
            return Icon.ExtractAssociatedIcon( Application.ExecutablePath );
        }

        /// <summary>
        /// 日志存储信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogNet?.WriteException( "UnhandledException", ex );
                HslCommunication.BasicFramework.SoftMail.MailSystem163.SendMail( ex );
            }
        }

        #endregion
    }
}
