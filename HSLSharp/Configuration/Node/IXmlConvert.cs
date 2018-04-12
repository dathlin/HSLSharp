using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    interface IXmlConvert
    {

        /// <summary>
        /// 对象解析为Xml元素，方便的存储
        /// </summary>
        /// <returns></returns>
        XElement ToXmlElement( );

        /// <summary>
        /// 对象从xml元素解析，初始化指定的数据
        /// </summary>
        /// <param name="element"></param>
        void LoadByXmlElement( XElement element );


    }
}
