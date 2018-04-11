using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 设备对象类，指明一个设备的所有信息
    /// </summary>
    public class DeviceNode
    {
        public DeviceNode()
        {
            Requests = new List<DeviceRequest>( );
        }


        /// <summary>
        /// 设备的名字，节点显示就显示这个信息
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 设备的类别
        /// </summary>
        public int DeviceType { get; set; }

        /// <summary>
        /// 连接超时的时间，单位毫秒
        /// </summary>
        public int ConnectTimeOut { get; set; }

        /// <summary>
        /// 设备的文本描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 服务器的创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 设备的所有的数据请求
        /// </summary>
        public List<DeviceRequest> Requests { get; set; }
        
        


        #region Const Define

        /// <summary>
        /// 
        /// </summary>
        public const int MelsecMcQna3EBinary = 1;

        public const int ModbusTcpClient = 10;


        #endregion



    }
}
