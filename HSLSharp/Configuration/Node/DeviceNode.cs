using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 设备对象类，指明一个设备的所有信息
    /// </summary>
    public class DeviceNode : NodeClass
    {
        public DeviceNode()
        {
            Requests = new List<DeviceRequest>( );
            NodeType = NodeClassInfo.DeviceNode;
        }

        
        /// <summary>
        /// 设备的类别
        /// </summary>
        public int DeviceType { get; set; }

        /// <summary>
        /// 连接超时的时间，单位毫秒
        /// </summary>
        public int ConnectTimeOut { get; set; }

        /// <summary>
        /// 服务器的创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 设备的所有的数据请求
        /// </summary>
        public List<DeviceRequest> Requests { get; set; }


        #region Override Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateConnectTimeOut( ConnectTimeOut ) );
            list.Add( NodeClassRenderItem.CreateTime( CreateTime ) );
            return list;
        }

        public override XElement ToXmlElement( )
        {
            XElement element = new XElement( "DeviceNode" );
            element.SetAttributeValue( "Name", Name );
            element.SetAttributeValue( "DeviceType", DeviceType );
            element.SetAttributeValue( "ConnectTimeOut", ConnectTimeOut );
            element.SetAttributeValue( "CreateTime", CreateTime.ToString() );
            element.SetAttributeValue( "Description", Description );
            return element;
        }

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            DeviceType = int.Parse( element.Attribute( "DeviceType" ).Value );
            ConnectTimeOut = int.Parse( element.Attribute( "ConnectTimeOut" ).Value );
            CreateTime = DateTime.Parse( element.Attribute( "CreateTime" ).Value );
        }

        #endregion

        #region Const Define

        /// <summary>
        /// 
        /// </summary>
        public const int MelsecMcQna3EBinary = 1;

        public const int ModbusTcpClient = 10;


        #endregion



    }
}
