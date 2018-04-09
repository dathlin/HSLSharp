using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    public class ModbusRequest
    {

        /// <summary>
        /// 本次请求的名称，方便在节点中显示的
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 客户端的站号
        /// </summary>
        public int Station { get; set; }

        /// <summary>
        /// 写入数据的地址，如果为负数，则忽略
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// 读取的数据长度
        /// </summary>
        public ushort Length { get; set; }

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
