using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Enthernet;
using HslCommunication;
using System.Xml.Linq;
using HSLSharp.Configuration;

namespace HSLSharp.Device
{
    public class DeviceSimplifyNet : DeviceCoreBase
    {

        #region Constructor

        /// <summary>
        /// 默认的构造方法
        /// </summary>
        /// <param name="dtu"></param>
        /// <param name="element"></param>
        public DeviceSimplifyNet( XElement element )
        {
            NodeSimplifyNet nodeSimplify = new NodeSimplifyNet( );
            nodeSimplify.LoadByXmlElement( element );

            LoadRequest( element );

            simplifyClient = new NetSimplifyClient( nodeSimplify.IpAddress, nodeSimplify.Port );
            simplifyClient.Token = nodeSimplify.Token;
            simplifyClient.ConnectTimeOut = nodeSimplify.ConnectTimeOut;

            ByteTransform = simplifyClient.ByteTransform;
            UniqueId = simplifyClient.ConnectionId;

            TypeName = "SimplifyNet设备";
        }


        #endregion


        #region Public Override


        public override OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            NetHandle netHandle;
            if (address.IndexOf( '.' ) >= 0)
            {
                string[] tmp = address.Split( '.' );
                netHandle = new NetHandle( byte.Parse( tmp[0] ), byte.Parse( tmp[1] ), ushort.Parse( tmp[2] ) );
            }
            else
            {
                netHandle = int.Parse( address );
            }
            OperateResult<byte[]> read = simplifyClient.ReadFromServer( netHandle, new byte[0] );
            if(read.Content?.Length != length)
            {
                return new OperateResult<byte[]>( )
                {
                    Message = "Data Length Check Failed. ",
                };
            }
            else
            {
                return read;
            }
        }



        #endregion

        #region Protect Override

        protected override void BeforStart( )
        {
            simplifyClient.ConnectServer( );
        }


        protected override void AfterClose( )
        {
            simplifyClient.ConnectClose( );
        }

        #endregion

        #region Private


        private NetSimplifyClient simplifyClient;               // 核心交互对象


        #endregion

    }
}
