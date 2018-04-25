using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.Profinet.Melsec;
using HSLSharp.Configuration;

namespace HSLSharp.Device
{
    public class DeviceMelsecAscii : DeviceCoreBase
    {

        #region Constructor

        /// <summary>
        /// 默认的构造方法
        /// </summary>
        /// <param name="dtu"></param>
        /// <param name="element"></param>
        public DeviceMelsecAscii( XElement element )
        {
            NodeMelsecMc nodeMelsecMc = new NodeMelsecMc( );
            nodeMelsecMc.LoadByXmlElement( element );

            LoadRequest( element );

            melsecMcNet = new MelsecMcAsciiNet( nodeMelsecMc.IpAddress, nodeMelsecMc.Port );
            melsecMcNet.NetworkNumber = nodeMelsecMc.NetworkNumber;
            melsecMcNet.NetworkStationNumber = nodeMelsecMc.NetworkStationNumber;
            melsecMcNet.ConnectTimeOut = nodeMelsecMc.ConnectTimeOut;

            ByteTransform = melsecMcNet.ByteTransform;
            UniqueId = melsecMcNet.ConnectionId;

            TypeName = "三菱PLC设备";
        }


        #endregion


        #region Public Override


        public override OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            return melsecMcNet.Read( address, length );
        }



        #endregion

        #region Protect Override

        protected override void BeforStart( )
        {
            melsecMcNet.ConnectServer( );
        }


        protected override void AfterClose( )
        {
            melsecMcNet.ConnectClose( );
        }

        #endregion

        #region Private


        private MelsecMcAsciiNet melsecMcNet;               // 核心交互对象



        #endregion


    }
}
