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

        #region Constructor


        public NodeClass( )
        {
            NodeType = NodeClassInfo.NodeClass;
            NodeHead = "NodeClass";
        }


        #endregion
        
        #region Public Properties
        
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
        public int NodeType { get; protected set; }


        #endregion

        #region Protect Member


        /// <summary>
        /// 节点的描述信息
        /// </summary>
        protected string NodeHead { get; set; }



        #endregion

        #region XmlConvert Support



        /// <summary>
        /// 从XElement元素加载节点信息
        /// </summary>
        /// <param name="element"></param>
        public virtual void LoadByXmlElement( XElement element )
        {
            Name = element.Attribute( "Name" ).Value;
            Description = element.Attribute( "Description" ).Value;
        }


        /// <summary>
        /// 获取节点对象的XElement，方便进行存储
        /// </summary>
        /// <returns></returns>
        public virtual XElement ToXmlElement( )
        {
            XElement element = new XElement( NodeHead );
            element.SetAttributeValue( "Name", Name );
            element.SetAttributeValue( "Description", Description );
            return element;
        }

        #endregion
        
        #region RenderValues


        /// <summary>
        /// 用于在数据表信息中信息的文件信息
        /// </summary>
        /// <returns></returns>
        public virtual List<NodeClassRenderItem> GetNodeClassRenders()
        {
            return new List<NodeClassRenderItem>( )
            {
                NodeClassRenderItem.CreatNodeeName(Name),
                NodeClassRenderItem.CreateNodeDescription(Description),
            };
        }


        #endregion

    }
}
