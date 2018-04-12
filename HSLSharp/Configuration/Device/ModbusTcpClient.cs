using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class ModbusTcpClient : DeviceNode, IXmlConvert
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认参数的对象
        /// </summary>
        public ModbusTcpClient()
        {
            CreateTime = DateTime.Now;
            DeviceType = DeviceNode.ModbusTcpClient;

            Name = "ModbusTcp客户端";
            Description = "这是描述";
            ConnectTimeOut = 1000;
            Port = 502;
            Station = 1;
        }


        #endregion


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
        public int Station { get; set; }


        /// <summary>
        /// 起始地址是否从0开始
        /// </summary>
        public bool IsAddressStartWithZero { get; set; } = true;


        #region Xml Interface
        
        public override void LoadByXmlElement( XElement element )
        {
            throw new NotImplementedException( );
        }

        public override XElement ToXmlElement( )
        {
            XElement element = new XElement( "DeviceNode" );
            element.SetAttributeValue( "DeviceType", DeviceType );
            element.SetAttributeValue( "Name", Name );
            element.SetElementValue( "Description", Description );
            element.SetElementValue( "IpAddress", IpAddress );
            element.SetElementValue( "Port", Port );
            element.SetElementValue( "Station", Station );
            element.SetElementValue( "IsAddressStartWithZero", IsAddressStartWithZero );
            element.SetElementValue( "ConnectTimeOut", ConnectTimeOut );
            element.SetElementValue( "CreateTime", CreateTime );
            return element;
        }

        #endregion

        #region Overide Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( new NodeClassRenderItem( )
            {
                ValueName = "IpAddress",
                Value = IpAddress,
            } );
            list.Add( new NodeClassRenderItem( )
            {
                ValueName = "Port",
                Value = Port.ToString(),
            } );
            list.Add( new NodeClassRenderItem( )
            {
                ValueName = "Station",
                Value = Station.ToString(),
            } );
            list.Add( new NodeClassRenderItem( )
            {
                ValueName = "IsAddressStartWithZero",
                Value = IsAddressStartWithZero.ToString(),
            } );

            return list;
        }


        #endregion

    }
}
