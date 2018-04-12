using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HSLSharp.Configuration
{


    /// <summary>
    /// 数据缓存解析的规则集合，主要是对一串byte[]数组进行数据分析，可以存储为指定名称的规则
    /// </summary>
    public class DataParseRegular : HslCommunication.BasicFramework.SoftFileSaveBase
    {
        #region Constructor

        /// <summary>
        /// 实例化一个对象
        /// </summary>
        public DataParseRegular( )
        {
            DataParses = new List<ByteDataParse>( );
        }


        #endregion
        
        /// <summary>
        /// 规则的解释性备注
        /// </summary>
        public string RegularDescription { get; set; }
        

        /// <summary>
        /// 唯一的规则ID，系统默认生成
        /// </summary>
        public string RegularCode { get; set; }


        /// <summary>
        /// 所有的数据解析规则
        /// </summary>
        public List<ByteDataParse> DataParses { get; set; }
        

        #region SoftFileSaveBase Override

        /// <summary>
        /// 从字符串加载对象的信息
        /// </summary>
        /// <param name="content"></param>
        public override void LoadByString( string content )
        {
            JObject json = JObject.Parse( content );
            RegularDescription = HslCommunication.BasicFramework.SoftBasic.GetValueFromJsonObject( json, nameof( RegularDescription ), RegularDescription );
            RegularCode = HslCommunication.BasicFramework.SoftBasic.GetValueFromJsonObject( json, nameof( RegularCode ), RegularCode );
            DataParses = JArray.Parse( HslCommunication.BasicFramework.SoftBasic.GetValueFromJsonObject( json, nameof( DataParses ), "[]" ) ).ToObject<List<ByteDataParse>>( );
        }


        /// <summary>
        /// 存储为字符串资源
        /// </summary>
        /// <returns></returns>
        public override string ToSaveString( )
        {
            JObject json = new JObject( );
            json.Add( nameof( RegularDescription ), new JValue( RegularDescription ) );
            json.Add( nameof( RegularCode ), new JValue( RegularCode ) );
            json.Add( nameof( DataParses ), new JValue( JArray.FromObject( DataParses ).ToString( ) ) );
            return json.ToString( );
        }

        #endregion

    }
}
