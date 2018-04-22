using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Core;
using HSLSharp.Configuration;

namespace HSLSharp.Device
{
    /// <summary>
    /// 设备的接口信息，指示了采集数据的方法，关联的请求列表，OpcUa节点，转换规则
    /// </summary>
    public interface IDeviceCore
    {

        /// <summary>
        /// OpcUa对应的节点信息
        /// </summary>
        string OpcUaNode { get; set; }

        /// <summary>
        /// 读取数据的核心方法
        /// </summary>
        /// <param name="address">其实地址</param>
        /// <param name="length">读取的数据长度</param>
        /// <returns>字节数据</returns>
        OperateResult<byte[]> ReadBytes( string address, ushort length );


        /// <summary>
        /// 所有的请求列表
        /// </summary>
        List<DeviceRequest> Requests { get; set; }

        /// <summary>
        /// 数据转换规则
        /// </summary>
        IByteTransform ByteTransform { get; set; }


        
    }
}
