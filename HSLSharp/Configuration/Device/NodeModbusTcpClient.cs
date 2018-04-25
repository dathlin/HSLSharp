using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 常规的Modbus-Tcp的客户端
    /// </summary>
    public class NodeModbusTcpClient : DeviceNode, IXmlConvert
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认参数的对象
        /// </summary>
        public NodeModbusTcpClient()
        {
            CreateTime = DateTime.Now;
            DeviceType = DeviceNode.ModbusTcpClient;

            Name = "ModbusTcp客户端";
            Description = "这是描述";
            IpAddress = "127.0.0.1";
            Port = 502;
            Station = 1;
        }


        #endregion

        #region Public Properties
        
        /// <summary>
        /// 设备的Ip地址
        /// </summary>
        public string IpAddress { get; set; }
        

        /// <summary>
        /// 设备的端口号
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// 客户端的站号
        /// </summary>
        public byte Station { get; set; }


        /// <summary>
        /// 起始地址是否从0开始
        /// </summary>
        public bool IsAddressStartWithZero { get; set; } = true;

        

        #endregion

        #region Xml Interface

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            IpAddress = element.Attribute( "IpAddress" ).Value;
            Port = int.Parse( element.Attribute( "Port" ).Value );
            Station = byte.Parse( element.Attribute( "Station" ).Value );
            IsAddressStartWithZero = bool.Parse( element.Attribute( "IsAddressStartWithZero" ).Value );

        }

        public override XElement ToXmlElement( )
        {
            XElement element = base.ToXmlElement();
            element.SetAttributeValue( "IpAddress", IpAddress );
            element.SetAttributeValue( "Port", Port );
            element.SetAttributeValue( "Station", Station );
            element.SetAttributeValue( "IsAddressStartWithZero", IsAddressStartWithZero );
            return element;
        }

        #endregion

        #region Overide Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateIpAddress( IpAddress ) );
            list.Add( NodeClassRenderItem.CreateIpPort( Port ) );
            list.Add( NodeClassRenderItem.CreateStation( Station ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "是否从0开始", IsAddressStartWithZero.ToString( ) ) );

            return list;
        }


        #endregion

    }
}
