using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HslCommunication;
using HslCommunication.Profinet.Omron;
using HSLSharp.Configuration;

namespace HSLSharp.Device
{
    public class DeviceOmron : DeviceCoreBase
    {

        #region Constructor

        /// <summary>
        /// 默认的构造方法
        /// </summary>
        /// <param name="dtu"></param>
        /// <param name="element"></param>
        public DeviceOmron( XElement element )
        {
            NodeOmron nodeOmron = new NodeOmron( );
            nodeOmron.LoadByXmlElement( element );

            LoadRequest( element );

            omronFinsNet = new OmronFinsNet( nodeOmron.IpAddress, nodeOmron.Port );
            omronFinsNet.DA1 = nodeOmron.DA1;
            omronFinsNet.DA2 = nodeOmron.DA2;
            omronFinsNet.SA1 = nodeOmron.SA1;
            omronFinsNet.ConnectTimeOut = nodeOmron.ConnectTimeOut;

            ByteTransform = omronFinsNet.ByteTransform;
            UniqueId = omronFinsNet.ConnectionId;

            TypeName = "欧姆龙设备";
        }


        #endregion


        #region Public Override


        public override OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            return omronFinsNet.Read( address, length );
        }



        #endregion

        #region Protect Override

        protected override void BeforStart( )
        {
            omronFinsNet.ConnectServer( );
        }


        protected override void AfterClose( )
        {
            omronFinsNet.ConnectClose( );
        }

        #endregion

        #region Private


        private OmronFinsNet omronFinsNet;               // 核心交互对象
        

        #endregion
    }
}
