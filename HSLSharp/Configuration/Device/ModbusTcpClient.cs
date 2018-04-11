using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    public class ModbusTcpClient : DeviceNode
    {
        #region Constructor

        public ModbusTcpClient()
        {
            CreateTime = DateTime.Now;
            DeviceType = DeviceNode.ModbusTcpClient;
        }


        #endregion


        /// <summary>
        /// 设备的Ip地址
        /// </summary>
        public string IpAddress { get; set; }
        

        /// <summary>
        /// 设备的端口号
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// 客户端的站号
        /// </summary>
        public int Station { get; set; }


        /// <summary>
        /// 起始地址是否从0开始
        /// </summary>
        public bool IsAddressStartWithZero { get; set; } = true;


    }
}
