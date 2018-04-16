using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    public class RegularNode : NodeClass,IComparable<RegularNode>
    {
        public RegularNode( )
        {
            NodeType = NodeClassInfo.RegularNode;
        }


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


        #region IComparable Interface
        
        /// <summary>
        /// 实现了比较的接口，可以用来方便的排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo( RegularNode other )
        {
            return this.GetStartedByteIndex( ).CompareTo( other.GetStartedByteIndex( ) );
        }


        #endregion

        #region Public Method

        public int GetStartedByteIndex()
        {
            if(TypeCode == RegularModeTypeItem.Bool.Code)
            {
                return Index / 8;
            }
            else
            {
                return Index;
            }
        }


        public int GetLengthByte( )
        {
            if (TypeCode == RegularModeTypeItem.Bool.Code)
            {
                if ((Index + TypeLength) % 8 == 0)
                {
                    return (TypeLength) / 8 + Index;
                }
                else
                {
                    return (TypeLength) / 8 + 1 + Index;
                }
            }
            else if (TypeCode == RegularModeTypeItem.StringAscii.Code ||
                TypeCode == RegularModeTypeItem.StringUnicode.Code ||
                TypeCode == RegularModeTypeItem.StringUtf8.Code)
            {
                return TypeLength + Index;
            }
            else if (TypeCode == RegularModeTypeItem.UInt16.Code ||
                TypeCode == RegularModeTypeItem.Int16.Code)
            {
                return TypeLength * 2 + Index;
            }
            else if (TypeCode == RegularModeTypeItem.Int32.Code ||
                TypeCode == RegularModeTypeItem.UInt32.Code ||
                TypeCode == RegularModeTypeItem.Float.Code)
            {
                return TypeLength * 4 + Index;
            }
            else if (TypeCode == RegularModeTypeItem.Int64.Code ||
                TypeCode == RegularModeTypeItem.UInt64.Code ||
                TypeCode == RegularModeTypeItem.Double.Code)
            {
                return TypeLength * 8 + Index;
            }
            else
            {
                return TypeLength + Index;
            }
        }

        #endregion
        
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
