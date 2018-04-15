using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 服务器定义的支持的数据类型处理类，bool,byte,short,ushort,int,uint,long,ulong,float,double,string，以及数组的长度
    /// </summary>
    public class ByteDataParse
    {
        /// <summary>
        /// 数据位于字节数据的索引，对于bool变量来说，就是按照位的索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 数据值的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型的代号，详细参见const数据
        /// </summary>
        public int TypeCode { get; set; }
        
        /// <summary>
        /// 类型的长度，对于string来说，就是字符串长度，其他的来说，就是数组长度
        /// </summary>
        public int TypeLength { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        


    }
}
