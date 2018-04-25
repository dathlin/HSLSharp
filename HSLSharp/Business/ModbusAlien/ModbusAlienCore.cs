using HslCommunication.Core.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.ModBus;
using System.Xml.Linq;
using HSLSharp.Configuration;
using HslCommunication;
using HSLSharp.Device;

namespace HSLSharp.Business
{
    /// <summary>
    /// 负责经营一个异形服务器和多个异形客户端
    /// </summary>
    public class ModbusAlienCore
    {

        #region Constructor


        public ModbusAlienCore( XElement element )
        {
            if (element.Name != "AlienNode") return;

            // 解析出服务器的属性配置
            AlienNode alienNode = new AlienNode( );
            alienNode.LoadByXmlElement( element );

            // 解析所有的客户端
            List<NodeModbusTcpAline> modbusTcpAlines = new List<NodeModbusTcpAline>( );
            foreach (var item in element.Elements())
            {
                NodeModbusTcpAline tcpAline = new NodeModbusTcpAline( );
                tcpAline.LoadByXmlElement( item );
                modbusTcpAlines.Add( tcpAline );


            }

        }

        #endregion


        #region Exstension


        private void ReadRequest( ModbusTcpNet modbusTcp, List<DeviceRequest> requests )
        {
            for (int i = 0; i < requests.Count; i++)
            {
                OperateResult<byte[]> read = modbusTcp.Read( requests[i].Address, requests[i].Length );
                if(read.IsSuccess)
                {

                }
            }
        }


        #endregion

        #region Private Member
        
        private NetworkAlienClient networkAlienClient;               // 异形客户端的服务器
        private List<IDeviceCore> modbusTcpNets;                    // 当前服务器挂载的所有的客户端


        #endregion

    }
}
