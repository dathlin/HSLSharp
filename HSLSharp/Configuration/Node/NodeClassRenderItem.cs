using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HSLSharp.Configuration
{
    /// <summary>
    /// 单个节点的单个数据对象
    /// </summary>
    public class NodeClassRenderItem
    {
        /// <summary>
        /// 数据名称
        /// </summary>
        public string ValueName { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public string Value { get; set; }


        #region Override 

        /// <summary>
        /// 返回表示当前对象的字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString( )
        {
            return $"Name:[{ValueName}] Value:[{Value}]";
        }

        #endregion


        #region Static Resource

        public static NodeClassRenderItem CreatNodeeName(string value)
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "节点名称",
                Value = value,
            };
        }

        public static NodeClassRenderItem CreateNodeDescription(string description )
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "节点描述",
                Value = description,
            };
        }

        public static NodeClassRenderItem CreateIpAddress( string ip )
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "Ip地址",
                Value = ip,
            };
        }

        public static NodeClassRenderItem CreateIpPort( int port )
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "以太网端口号",
                Value = port.ToString(),
            };
        }


        public static NodeClassRenderItem CreateConnectTimeOut(int timeout)
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "连接超时",
                Value = timeout.ToString( ),
            };
        }


        public static NodeClassRenderItem CreateTime(DateTime time)
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "创建时间",
                Value = time.ToString( ),
            };
        }

        public static NodeClassRenderItem CreateStation( int station )
        {
            return new NodeClassRenderItem( )
            {
                ValueName = "设备站号",
                Value = station.ToString( ),
            };
        }

        public static NodeClassRenderItem CreateCustomer( string valueName,string value )
        {
            return new NodeClassRenderItem( )
            {
                ValueName = valueName,
                Value = value,
            };
        }

        #endregion
    }
}
