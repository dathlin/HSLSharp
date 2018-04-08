using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{

    /// <summary>
    /// 单个的数据配置对象，仅仅包含属性名，方便的实现序列化和反序列化
    /// </summary>
    public class DataSettings
    {
        /// <summary>
        /// 变量的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 变量的类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 变量的地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 变量长度
        /// </summary>
        public ushort Length { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }



        /// <summary>
        /// 获取数据的长度
        /// </summary>
        /// <returns></returns>
        public ushort GetDataLength()
        {
            switch (Type)
            {
                case "int": return 4;
                case "byte": return 1;
                case "short": return 2;
                case "bool": return 1;
                case "ushort": return 2;
                case "float": return 4;
                case "string": return Length;
                case "uint": return 4;
                case "float[]": return Length;
                default: return 1;
            }
        }
    }
}
