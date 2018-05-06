using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Core.Net;
using HslCommunication.LogNet;
using HSLSharp.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Device
{
    /// <summary>
    /// 系统维护运行的所有的客户端的基类，提供了一些共同的基础逻辑实现
    /// </summary>
    public abstract class DeviceCoreBase : IDeviceCore
    {

        #region Constructor

        /// <summary>
        /// 使用默认的无参构造方法
        /// </summary>
        public DeviceCoreBase()
        {
            ActiveTime = DateTime.Now.AddDays( -1 );
            autoResetQuit = new AutoResetEvent( false );
            logNet = Util.LogNet;
        }

        #endregion

        #region IDeviceCore
        

        /// <summary>
        /// OpcUa对应的节点信息
        /// </summary>
        public string OpcUaNode { get; set; }

        /// <summary>
        /// 读取数据的核心方法，需要在继承类里面进行重新实现
        /// </summary>
        /// <param name="address">其实地址</param>
        /// <param name="length">读取的数据长度</param>
        /// <returns>字节数据</returns>
        public virtual OperateResult<byte[]> ReadBytes( string address, ushort length )
        {
            return new OperateResult<byte[]>( );
        }


        /// <summary>
        /// 处理数据的核心方法，基于被动读取的设备的机制
        /// </summary>
        /// <param name="data">直接数据</param>
        public virtual void AnalysisBytes( byte[] data )
        {
            ActiveTime = DateTime.Now;
        }


        /// <summary>
        /// 所有的请求列表
        /// </summary>
        public List<DeviceRequest> Requests { get; set; }

        /// <summary>
        /// 数据转换规则
        /// </summary>
        public IByteTransform ByteTransform { get; set; }

        /// <summary>
        /// 指示如何写入Opc Ua的节点信息
        /// </summary>
        public Action<IDeviceCore, string, byte[], DeviceRequest> WriteDeviceData { get; set; }

        /// <summary>
        /// 设备上次激活的时间节点，用来判断失效状态
        /// </summary>
        public DateTime ActiveTime { get; set; }

        /// <summary>
        /// 唯一的识别码，方便异形客户端寻找对应的处理逻辑
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// 设备的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 请求成功的次数统计
        /// </summary>
        public long RequestSuccessCount { get; set; }

        /// <summary>
        /// 请求失败的次数统计
        /// </summary>
        public long RequestFailedCount { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 启动读取数据
        /// </summary>
        public void StartRead()
        {
            if (Interlocked.CompareExchange( ref isStarted, 1, 0 ) == 0)
            {
                thread = new Thread( new ThreadStart( ThreadReadBackground ) );
                thread.IsBackground = true;
                thread.Start( );
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        public void QuitDevice()
        {
            if (isStarted == 1)
            {
                isQuit = 1;
                autoResetQuit.WaitOne( );
            }
        }

        /// <summary>
        /// 设置为异形客户端对象
        /// </summary>
        /// <param name="alienSession"></param>
        public virtual void SetAlineSession( AlienSession alienSession )
        {

        }

        /// <summary>
        /// 指示设备是否正常的状态
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// 绘制呈现的范围
        /// </summary>
        public Rectangle PaintRegion { get; set; }


        #endregion

        #region Protect Method

        /// <summary>
        /// 使用固定的节点加载数据信息
        /// </summary>
        /// <param name="element"></param>
        protected void LoadRequest( XElement element )
        {
            Requests = new List<DeviceRequest>( );
            foreach (var item in element.Elements( "DeviceRequest" ))
            {
                DeviceRequest request = new DeviceRequest( );
                request.LoadByXmlElement( item );
                Requests.Add( request );
            }
        }

        #endregion

        #region Virtual Method

        /// <summary>
        /// 在启动之前进行的操作信息
        /// </summary>
        protected virtual void BeforStart()
        {

        }

        /// <summary>
        /// 在关闭的时候需要进行的操作
        /// </summary>
        protected virtual void AfterClose()
        {

        }

        #endregion

        #region Thread Read


        private void ThreadReadBackground( )
        {
            Thread.Sleep( 1000 );           // 默认休息一下下

            BeforStart( );
            while (isQuit == 0)
            {
                Thread.Sleep( 100 );


                foreach (var Request in Requests)
                {
                    if ((DateTime.Now - Request.LastActiveTime).TotalMilliseconds > Request.CaptureInterval)
                    {
                        Request.LastActiveTime = DateTime.Now;

                        OperateResult<byte[]> read = ReadBytes( Request.Address, Request.Length );
                        if (read.IsSuccess)
                        {
                            IsError = false;
                            WriteDeviceData?.Invoke( this, OpcUaNode, read.Content, Request );
                            ActiveTime = DateTime.Now;
                            RequestSuccessCount++;
                        }
                        else
                        {
                            IsError = true;
                            RequestFailedCount++;
                        }
                    }
                }
            }

            AfterClose( );

            // 通知关闭的线程继续
            autoResetQuit.Set( );

        }

        #endregion

        #region Private Member

        private Thread thread;                   // 后台读取的线程
        private int isStarted = 0;               // 是否启动了后台数据读取
        private AutoResetEvent autoResetQuit;    // 退出系统的时候的同步锁
        private int isQuit = 0;                  // 是否准备从系统进行退出
        private ILogNet logNet;                  // 系统的日志

        #endregion
    }
}
