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
    public class DeciveModbusTcpAlien : DeviceCoreBase
    {
        #region Constructor


        public DeciveModbusTcpAlien(string dtu, XElement element)
        {
            ModbusTcpAline modbusTcpAline = new ModbusTcpAline( );
            modbusTcpAline.LoadByXmlElement( element );

            LoadRequest( element );

            modbusTcp = new ModbusTcpNet( string.Empty, 502, modbusTcpAline.Station );
            modbusTcp.AddressStartWithZero = modbusTcpAline.IsAddressStartWithZero;
            modbusTcp.ConnectionId = modbusTcpAline.DTU;
            modbusTcp.LogNet = LogNet;


            ByteTransform = modbusTcp.ByteTransform;
            UniqueId = modbusTcp.ConnectionId;
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
