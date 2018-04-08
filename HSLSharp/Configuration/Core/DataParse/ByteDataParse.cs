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
        public string ValueName { get; set; }

        /// <summary>
        /// 类型的代号，详细参见const数据
        /// </summary>
        public int TypeCode { get; set; }
        
        /// <summary>
        /// 类型的长度，对于string来说，就是字符串长度，其他的来说，就是数组长度
        /// </summary>
        public int TypeLength { get; set; }



        /// <summary>
        /// Bool数据类型
        /// </summary>
        public const int DataParseBool = 1;
        /// <summary>
        /// Byte数据类型
        /// </summary>
        public const int DataParseByte = 2;
        /// <summary>
        /// short数据类型
        /// </summary>
        public const int DataParseInt16 = 3;
        /// <summary>
        /// ushort数据类型
        /// </summary>
        public const int DataParseUInt16 = 4;
        /// <summary>
        /// int数据类型
        /// </summary>
        public const int DataParseInt32 = 5;
        /// <summary>
        /// uint数据类型
        /// </summary>
        public const int DataParseUInt32 = 6;
        /// <summary>
        /// long数据类型
        /// </summary>
        public const int DataParseInt64 = 7;
        /// <summary>
        /// ulong数据类型
        /// </summary>
        public const int DataParseUInt64 = 8;
        /// <summary>
        /// float数据类型
        /// </summary>
        public const int DataParseFloat = 9;
        /// <summary>
        /// double数据类型
        /// </summary>
        public const int DataParseDouble = 10;
        /// <summary>
        /// string数据类型，ASCII编码
        /// </summary>
        public const int DataParseStringASCII = 11;
        /// <summary>
        /// string数据类型，Unicode编码
        /// </summary>
        public const int DataParseStringUnicode = 12;
        /// <summary>
        /// string数据类型，UTF8编码
        /// </summary>
        public const int DataParseStringUTF8 = 13;


    }
}
