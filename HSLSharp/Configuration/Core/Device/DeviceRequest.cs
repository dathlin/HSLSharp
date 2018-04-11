using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{

    /// <summary>
    /// 通用的客户端模型，指示了一般的客户端模式下的，一次数据请求，一个客户端可以进行多次的数据请求
    /// </summary>
    public class DeviceRequest
    {
        /// <summary>
        /// 本次请求的名称，方便在节点中显示的
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 变量的地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 读取的数据长度
        /// </summary>
        public ushort Length { get; set; }

        /// <summary>
        /// 本次请求的时间间隔，单位为毫秒
        /// </summary>
        public int CaptureInterval { get; set; }

        /// <summary>
        /// 本次请求解析字节数据的规则
        /// </summary>
        public string PraseRegularCode { get; set; }
        
        /// <summary>
        /// 本次请求的描述
        /// </summary>
        public string Description { get; set; }

        
    }
}
