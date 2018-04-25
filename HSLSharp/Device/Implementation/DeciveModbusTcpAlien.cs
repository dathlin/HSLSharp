using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.ModBus;
using HSLSharp.Configuration;

namespace HSLSharp.Device
{
    /// <summary>
    /// 异形ModbusTcp的客户端
    /// </summary>
    public class DeviceModbusTcpAlien : DeviceCoreBase
    {
        #region Constructor

        /// <summary>
        /// 默认的构造方法
        /// </summary>
        /// <param name="element"></param>
        public DeviceModbusTcpAlien( XElement element)
        {
            NodeModbusTcpAline modbusTcpAline = new NodeModbusTcpAline( );
            modbusTcpAline.LoadByXmlElement( element );

            LoadRequest( element );

            modbusTcp = new ModbusTcpNet( string.Empty, 502, modbusTcpAline.Station );
            modbusTcp.AddressStartWithZero = modbusTcpAline.IsAddressStartWithZero;
            modbusTcp.ConnectionId = modbusTcpAline.DTU;


            ByteTransform = modbusTcp.ByteTransform;
            UniqueId = modbusTcp.ConnectionId;

            TypeName = "Modbus-Tcp异形设备";
        }


        #endregion


        #region Public Override


        public override OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            return modbusTcp.Read( address, length );
        }


        public override void SetAlineSession( AlienSession alienSession )
        {
            modbusTcp.ConnectServer( alienSession );
        }


        #endregion

        #region Protect Override

        protected override void BeforStart()
        {
            modbusTcp.ConnectServer( null );
        }


        protected override void AfterClose()
        {
            modbusTcp.ConnectClose( );
        }

        #endregion

        #region Private


        private ModbusTcpNet modbusTcp;               // 核心交互对象



        #endregion

    }


}
