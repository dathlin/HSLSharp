using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 异形ModbusTcp的客户端节点，只能挂在Alien节点下，下面只能挂载异形modbus客户端
    /// </summary>
    public class ModbusTcpAline : DeviceNode
    {
        #region Constructor

        public ModbusTcpAline()
        {
            DTU = "12345678901";
            DeviceType = DeviceNode.ModbusTcpAlien;

            Name = "异形设备";
            Description = "这是一个异形设备";
            Station = 0x01;

        }


        #endregion
        
        #region Public Properties
        
        /// <summary>
        /// 设备的唯一号码
        /// </summary>
        public string DTU { get; set; }

        /// <summary>
        /// 设备的站号
        /// </summary>
        public byte Station { get; set; }


        /// <summary>
        /// 起始地址是否从0开始
        /// </summary>
        public bool IsAddressStartWithZero { get; set; } = true;

        #endregion

        #region Override Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateCustomer( "唯一标识", DTU ) );
            list.Add( NodeClassRenderItem.CreateStation( Station ) );
            list.Add( NodeClassRenderItem.CreateCustomer( "是否从0开始", IsAddressStartWithZero.ToString( ) ) );
            return list;
        }

        public override XElement ToXmlElement( )
        {
            XElement element = base.ToXmlElement( );
            element.SetAttributeValue( "DTU", DTU );
            element.SetAttributeValue( "Station", Station );
            element.SetAttributeValue( "IsAddressStartWithZero", IsAddressStartWithZero );
            return element;
        }

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            DTU = element.Attribute( "DTU" ).Value;
            Station = byte.Parse( element.Attribute( "Station" ).Value );
            IsAddressStartWithZero = bool.Parse( element.Attribute( "IsAddressStartWithZero" ).Value );
        }

        #endregion
        


    }
}
