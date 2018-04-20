using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSLSharp.Configuration
{


    /// <summary>
    /// 异形客户端的侦听服务器，需要指定基础的信息设置
    /// </summary>
    public class AlienNode : NodeClass
    {

        /// <summary>
        /// 密码，6位数，为空的话默认都是0x00
        /// </summary>
        public string Password { get; set; }



        #region Override Method

        public override List<NodeClassRenderItem> GetNodeClassRenders( )
        {
            var list = base.GetNodeClassRenders( );
            list.Add( NodeClassRenderItem.CreateCustomer( "Password", Password ) );
            return list;
        }

        public override XElement ToXmlElement( )
        {
            XElement element = new XElement( "AlienNode" );
            element.SetAttributeValue( "Name", Name );
            element.SetAttributeValue( "Password", Password );;
            element.SetAttributeValue( "Description", Description );
            return element;
        }

        public override void LoadByXmlElement( XElement element )
        {
            base.LoadByXmlElement( element );
            Password =  element.Attribute( "Password" ).Value;
        }

        #endregion


    }

}
