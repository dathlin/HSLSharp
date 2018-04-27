using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Siemens;
using HSLSharp.Configuration;
using HslCommunication;
using System.Xml.Linq;

namespace HSLSharp.Device
{
    public class DeviceSiemens : DeviceCoreBase
    {

        #region Constructor

        /// <summary>
        /// 默认的构造方法
        /// </summary>
        /// <param name="element"></param>
        public DeviceSiemens( XElement element )
        {
            NodeSiemens nodeSiemens = new NodeSiemens( );
            nodeSiemens.LoadByXmlElement( element );

            LoadRequest( element );

            if(nodeSiemens.PlcType == NodeSiemens.PLCFW)
            {
                isS7Net = false;
                siemensFetchWrite = new SiemensFetchWriteNet( nodeSiemens.IpAddress, nodeSiemens.Port );
                siemensFetchWrite.ConnectTimeOut = nodeSiemens.ConnectTimeOut;

                ByteTransform = siemensFetchWrite.ByteTransform;
                UniqueId = siemensFetchWrite.ConnectionId;
            }
            else
            {
                if(nodeSiemens.PlcType == NodeSiemens.PLC300)
                {
                    siemensS7Net = new SiemensS7Net( SiemensPLCS.S300 );
                }
                else if(nodeSiemens.PlcType == NodeSiemens.PLC1200)
                {
                    siemensS7Net = new SiemensS7Net( SiemensPLCS.S1200 );
                }
                else if(nodeSiemens.PlcType == NodeSiemens.PLC1500)
                {
                    siemensS7Net = new SiemensS7Net( SiemensPLCS.S1500 );
                }
                else if(nodeSiemens.PlcType == NodeSiemens.PLC200Smart)
                {
                    siemensS7Net = new SiemensS7Net( SiemensPLCS.S200Smart );
                }
                else
                {
                    siemensS7Net = new SiemensS7Net( SiemensPLCS.S1200 );
                }

                siemensS7Net.IpAddress = nodeSiemens.IpAddress;
                siemensS7Net.ConnectTimeOut = nodeSiemens.ConnectTimeOut;
                ByteTransform = siemensS7Net.ByteTransform;
                UniqueId = siemensS7Net.ConnectionId;
            }


            TypeName = "西门子设备";
        }


        #endregion


        #region Public Override


        public override OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            if(isS7Net)
            {
                return siemensS7Net.Read( address, length );
            }
            else
            {
                return siemensFetchWrite.Read( address, length );
            }
        }



        #endregion

        #region Protect Override

        protected override void BeforStart( )
        {
            if (isS7Net)
            {
                siemensS7Net.ConnectServer( );
            }
            else
            {
                siemensFetchWrite.ConnectServer( );
            }
        }


        protected override void AfterClose( )
        {
            if (isS7Net)
            {
                siemensS7Net.ConnectClose( );
            }
            else
            {
                siemensFetchWrite.ConnectClose( );
            }
        }

        #endregion

        #region Private


        private SiemensS7Net siemensS7Net;               // 核心交互对象
        private SiemensFetchWriteNet siemensFetchWrite;  // 核心交互对象
        private bool isS7Net = true;                     // 是否是S7协议

        #endregion


    }
}
