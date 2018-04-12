using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 节点信息，指示一个具体的分类，并且指定了所有节点的基类
    /// </summary>
    public class NodeClass : IXmlConvert
    {
        /// <summary>
        /// 节点的名称，在节点上显示的
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 节点的类型，标记其派生类不同的类型对象
        /// </summary>
        public int NodeType { get; private set; }




        #region XmlConvert Support
        
        public virtual void LoadByXmlElement( XElement element )
        {
            throw new NotImplementedException( );
        }

        public virtual XElement ToXmlElement( )
        {
            XElement element = new XElement( "NodeClass" );
            element.SetAttributeValue( "Name", Name );
            element.SetElementValue( "Description", Description );
            return element;
        }

        #endregion


        #region RenderValues

        public virtual List<NodeClassRenderItem> GetNodeClassRenders()
        {
            return new List<NodeClassRenderItem>( )
            {
                new NodeClassRenderItem()
                {
                    ValueName = "Name",
                    Value = Name,
                },
                new NodeClassRenderItem()
                {
                    ValueName = "Description",
                    Value = Description,
                }
            };
        }


        #endregion

    }
}
