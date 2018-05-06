using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// Modbus服务器的数据信息，也就是说本系统支持多个服务器搭建
    /// </summary>
    public class NodeModbusServer : NodeClass
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认的对象
        /// </summary>
        public NodeModbusServer()
        {
            Port = 502;
            CreateTime = DateTime.Now;
            NodeType = NodeClassInfo.ModbusServer;
            NodeHead = "ModbusServer";
            Name = "Modbus服务器";
            Description = "这是一个Modbus服务器";
        }

        #endregion

        /// <summary>
        /// 当前主站的端口号信息
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 服务器的创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }



        #region Override Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateIpPort( Port ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "CreateTime", CreateTime.ToString() ) );
            return list;
        }

        public override XElement ToXmlElement( )
        {
            XElement element = base.ToXmlElement( );
            element.SetAttributeValue( "CreateTime", CreateTime.ToString() ); ;
            element.SetAttributeValue( "Port", Port );
            return element;
        }

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            Port = Convert.ToInt32( element.Attribute( "Port" ).Value );
            CreateTime = DateTime.Parse( element.Attribute( "CreateTime" ).Value );
        }

        #endregion

    }
}
