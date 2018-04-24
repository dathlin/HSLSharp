using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Core.Net;
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

        /// <summary>
        /// 指示如何写入Opc Ua的节点信息
        /// </summary>
        Action<IDeviceCore, string, byte[], DeviceRequest> WriteDeviceData { get; set; }

        /// <summary>
        /// 设备上次激活的时间节点，用来判断失效状态
        /// </summary>
        DateTime ActiveTime { get; set; }

        /// <summary>
        /// 指示设备是否正常的状态
        /// </summary>
        bool IsError { get; set; }

        /// <summary>
        /// 唯一的识别码，方便异形客户端寻找对应的处理逻辑
        /// </summary>
        string UniqueId { get; set; }

        /// <summary>
        /// 开始读取
        /// </summary>
        void StartRead();

        /// <summary>
        /// 退出系统
        /// </summary>
        void QuitDevice();

        /// <summary>
        /// 当客户端为异形客户端的时候，需要通过这个方法来更新客户端的连接状态
        /// </summary>
        /// <param name="alienSession">异形客户端的会话</param>
        void SetAlineSession( AlienSession alienSession );



        #region Server Paint

        /// <summary>
        /// 绘制呈现的范围
        /// </summary>
        Rectangle PaintRegion { get; set; }

        /// <summary>
        /// 设备的名称
        /// </summary>
        string Name { get; set; }

        #endregion

    }
}
