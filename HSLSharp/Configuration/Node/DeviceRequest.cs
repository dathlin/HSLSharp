using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{

    /// <summary>
    /// 通用的客户端模型，指示了一般的客户端模式下的，一次数据请求，一个客户端可以进行多次的数据请求
    /// </summary>
    public class DeviceRequest : NodeClass, IXmlConvert
    {

        /// <summary>
        /// 实例化一个对象
        /// </summary>
        public DeviceRequest()
        {
            Name = "数据请求";
            Description = "一次完整的数据请求";
            Address = "123";
            Length = 10;
            CaptureInterval = 1000;
            PraseRegularCode = "ABCDEFG";
            NodeType = NodeClassInfo.DeviceRequest;
        }
        

        /// <summary>
        /// 变量的地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 读取的数据长度
        /// </summary>
        public ushort Length { get; set; }

        /// <summary>
        /// 本次请求的时间间隔，单位为毫秒
        /// </summary>
        public int CaptureInterval { get; set; }

        /// <summary>
        /// 本次请求解析字节数据的规则
        /// </summary>
        public string PraseRegularCode { get; set; }
        


        #region Xml Support


        public override void LoadByXmlElement( XElement element )
        {
            throw new NotImplementedException( );
        }

        public override XElement ToXmlElement( )
        {
            XElement element = new XElement( "DeviceRequest" );
            element.SetAttributeValue( "Name", Name );
            element.SetAttributeValue( "Description", Description );
            element.SetAttributeValue( "Address", Address );
            element.SetAttributeValue( "Length", Length );
            element.SetAttributeValue( "CaptureInterval", CaptureInterval );
            element.SetAttributeValue( "PraseRegularCode", PraseRegularCode );
            return element;
        }


        #endregion


        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var result = base.GetNodeClassRenders( );
            result.Add( new NodeClassRenderItem( )
            {
                ValueName = "地址",
                Value = Address,
            } );
            result.Add( new NodeClassRenderItem( )
            {
                ValueName = "读取长度",
                Value = Length.ToString(),
            } );
            result.Add( new NodeClassRenderItem( )
            {
                ValueName = "读取间隔",
                Value = CaptureInterval.ToString(),
            } );
            result.Add( new NodeClassRenderItem( )
            {
                ValueName = "解析代号",
                Value = Address,
            } );

            return result;
        }
    }
}
