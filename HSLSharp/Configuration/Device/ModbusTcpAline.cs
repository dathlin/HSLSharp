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
        }


        #endregion
        
        #region Public Properties
        
        /// <summary>
        /// 设备的唯一号码
        /// </summary>
        public string DTU { get; set; }


        #endregion

        #region Override Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateCustomer( "唯一标识", DTU ) );
            return list;
        }

        public override XElement ToXmlElement( )
        {
            XElement element = base.ToXmlElement( );
            element.SetAttributeValue( "DTU", DTU );
            return element;
        }

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            DTU = element.Attribute( "DTU" ).Value;
        }

        #endregion
        


    }
}
