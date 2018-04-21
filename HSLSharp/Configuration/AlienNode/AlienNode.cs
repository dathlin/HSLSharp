using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{


    /// <summary>
    /// 异形客户端的侦听服务器，需要指定基础的信息设置
    /// </summary>
    public class AlienNode : NodeClass
    {
        #region Constructor


        /// <summary>
        /// 异形服务器的节点
        /// </summary>
        public AlienNode( )
        {
            NodeType = NodeClassInfo.AlienServer;

            NodeHead = "AlienNode";
            Name = "异形服务器";
            Description = "这是一个异形服务器";
        }


        #endregion

        
        /// <summary>
        /// 服务器的端口号
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// 密码，6位数，为空的话默认都是0x00
        /// </summary>
        public string Password { get; set; }



        #region Override Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateIpPort( Port ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "Password", Password ) );
            return list;
        }

        public override XElement ToXmlElement( )
        {
            XElement element = base.ToXmlElement( );
            element.SetAttributeValue( "Password", Password ); ;
            element.SetAttributeValue( "Port", Port );
            return element;
        }

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            Port = Convert.ToInt32(element.Attribute( "Port" ).Value);
            Password = element.Attribute( "Password" ).Value;
        }

        #endregion


    }

}
