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
    public class DeviceModbusTcp : DeviceCoreBase
    {
        #region Constructor

        /// <summary>
        /// 默认的构造方法
        /// </summary>
        /// <param name="element"></param>
        public DeviceModbusTcp( XElement element )
        {
            NodeModbusTcpClient modbusTcpClient = new NodeModbusTcpClient( );
            modbusTcpClient.LoadByXmlElement( element );

            LoadRequest( element );

            modbusTcp = new ModbusTcpNet( modbusTcpClient.IpAddress, modbusTcpClient.Port, modbusTcpClient.Station );
            modbusTcp.AddressStartWithZero = modbusTcpClient.IsAddressStartWithZero;
            modbusTcp.ConnectTimeOut = modbusTcpClient.ConnectTimeOut;

            ByteTransform = modbusTcp.ByteTransform;
            UniqueId = modbusTcp.ConnectionId;

            TypeName = "Modbus-Tcp设备";
        }


        #endregion


        #region Public Override


        public override OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            return modbusTcp.Read( address, length );
        }

        

        #endregion

        #region Protect Override

        protected override void BeforStart( )
        {
            modbusTcp.ConnectServer( );
        }


        protected override void AfterClose( )
        {
            modbusTcp.ConnectClose( );
        }

        #endregion

        #region Private


        private ModbusTcpNet modbusTcp;               // 核心交互对象



        #endregion
    }
}
