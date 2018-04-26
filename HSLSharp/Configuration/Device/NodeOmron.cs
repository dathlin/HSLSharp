using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    public class NodeOmron : DeviceNode, IXmlConvert
    {

        #region Constructor

        /// <summary>
        /// 使用默认的参数实例化一个设备信息
        /// </summary>
        public NodeOmron( )
        {
            Name = "欧姆龙设备";
            Description = "此设备安装在角落，编号0001";
            DeviceType = DeviceNode.Omron;

            IpAddress = "192.168.0.3";
            Port = 9600;
            
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
        /// PLC单元号
        /// </summary>
        public byte DA2 { get; set; } = 0x00;

        /// <summary>
        /// PLC的节点地址
        /// </summary>
        public byte DA1 { get; set; } = 0x0B;

        /// <summary>
        /// 上位机的节点地址
        /// </summary>
        public byte SA1 { get; set; } = 0x0C;
        


        #endregion


        #region Xml Interface

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            IpAddress = element.Attribute( "IpAddress" ).Value;
            Port = int.Parse( element.Attribute( "Port" ).Value );
            SA1 = byte.Parse( element.Attribute( "SA1" ).Value );
            DA1 = byte.Parse( element.Attribute( "DA1" ).Value );
            DA2 = byte.Parse( element.Attribute( "DA2" ).Value );
        }

        public override XElement ToXmlElement( )
        {
            XElement element = base.ToXmlElement( );
            element.SetAttributeValue( "IpAddress", IpAddress );
            element.SetAttributeValue( "Port", Port.ToString( ) );
            element.SetAttributeValue( "SA1", SA1.ToString( ) );
            element.SetAttributeValue( "DA1", DA1.ToString( ) );
            element.SetAttributeValue( "DA2", DA2.ToString() );
            return element;
        }

        #endregion

        #region Overide Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateIpAddress( IpAddress ) );
            list.Add( NodeClassRenderItem.CreateIpPort( Port ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "上位机节点号", SA1.ToString( ) ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "PLC节点号", DA1.ToString( ) ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "PLC单元号", DA2.ToString( ) ) );

            return list;
        }

        #endregion



    }
}
