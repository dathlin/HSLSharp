using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.SettingsSupport
{

    /// <summary>
    /// 系统的配置类信息
    /// </summary>
    public class SharpSettings : HslCommunication.BasicFramework.SoftFileSaveBase
    {


        /// <summary>
        /// 节点配置器的文件默认存储路径
        /// </summary>
        public string NodeSettingsFilePath { get; set; } = "NodesSettings.xml";

        /// <summary>
        /// 规则配置器的文件默认存储路径
        /// </summary>
        public string RegularSettingsFilePath { get; set; } = "RegularSettings.xml";


        /// <summary>
        /// 从字符串加载数据信息
        /// </summary>
        /// <param name="content"></param>
        public override void LoadByString( string content )
        {
            base.LoadByString( content );
        }


        /// <summary>
        /// 格式化成保存的字符串信息
        /// </summary>
        /// <returns></returns>
        public override string ToSaveString()
        {
            return base.ToSaveString( );
        }


    }
}
