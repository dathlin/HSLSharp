using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 节点类相关的常用资源
    /// </summary>
    public class NodeClassInfo
    {

        /// <summary>
        /// 系统的根节点信息
        /// </summary>
        public const int NodeRoot = 0;

        /// <summary>
        /// 普通的分类节点
        /// </summary>
        public const int NodeClass = 1;

        /// <summary>
        /// 设备节点信息
        /// </summary>
        public const int DeviceNode = 2;

        /// <summary>
        /// Modbus Server的节点
        /// </summary>
        public const int ModbusServer = 3;

        /// <summary>
        /// 解析规则的节点
        /// </summary>
        public const int RegularNode = 4;

        /// <summary>
        /// 设备的请求信息
        /// </summary>
        public const int DeviceRequest = 100;


        /// <summary>
        /// Modbus服务器的
        /// </summary>
        public const int ModbusRequest = 101;



    }
}
