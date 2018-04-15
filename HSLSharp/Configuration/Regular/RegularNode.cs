using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    public class RegularNode : NodeClass
    {
        /// <summary>
        /// 类型的代号，详细参见const数据
        /// </summary>
        public int TypeCode { get; set; }

        /// <summary>
        /// 类型的长度，对于string来说，就是字符串长度，其他的来说，就是数组长度
        /// </summary>
        public int TypeLength { get; set; }

        /// <summary>
        /// 数据位于字节数据的索引，对于bool变量来说，就是按照位的索引
        /// </summary>
        public int Index { get; set; }



        #region Override

        /// <summary>
        /// 从XElement加载数据
        /// </summary>
        /// <param name="element"></param>
        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            TypeCode = int.Parse( element.Attribute( "TypeCode" ).Value );
            TypeLength = int.Parse( element.Attribute( "TypeLength" ).Value );
            Index = int.Parse( element.Attribute( "Index" ).Value );
        }

        /// <summary>
        /// 转化Xml存储文件
        /// </summary>
        /// <returns></returns>
        public override XElement ToXmlElement( )
        {
            XElement element = new XElement( "RegularNode" );
            element.SetAttributeValue( "Name", Name );
            element.SetAttributeValue( "Description", Description );
            element.SetAttributeValue( "Index", Index );
            element.SetAttributeValue( "TypeCode", TypeCode );
            element.SetAttributeValue( "TypeLength", TypeLength );
            return element;
        }

        
        #endregion


    }
}
