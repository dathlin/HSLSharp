using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.BasicFramework;

namespace HSLSharp.SettingsSupport
{

    /// <summary>
    /// 系统的配置类信息
    /// </summary>
    public class SharpSettings : HslCommunication.BasicFramework.SoftFileSaveBase
    {


        /// <summary>
        /// 节点配置器的文件默认存储路径
        /// </summary>
        public string NodeSettingsFilePath { get; set; } = "NodesSettings.xml";

        /// <summary>
        /// 规则配置器的文件默认存储路径
        /// </summary>
        public string RegularSettingsFilePath { get; set; } = "RegularSettings.xml";



        #region Opc Ua 相关


        /// <summary>
        /// OpcUa的服务器地址
        /// </summary>
        public string OpcUaStringUrl { get; set; } = "opc.tcp://localhost:34561/DataTransferServer";
        
        /// <summary>
        /// 空的安全代理
        /// </summary>
        public bool SecurityPolicyNone { get; set; } = false;

        /// <summary>
        /// Basic128_sign
        /// </summary>
        public bool SecurityPolicyBasic128_Sign { get; set; } = false;

        public bool SecurityPolicyBasic128_Sign_Encrypt { get; set; } = false;

        public bool SecurityPolicyBasic256_Sign { get; set; } = false;

        public bool SecurityPolicyBasic256_Sign_Encrypt { get; set; } = false;

        public bool SecurityAnonymous { get; set; } = true;

        public bool SecurityAccount { get; set; } = false;

        public string UserName { get; set; } = "admin";

        public string Password { get; set; } = "123456";


        #endregion






        /// <summary>
        /// 从字符串加载数据信息
        /// </summary>
        /// <param name="content"></param>
        public override void LoadByString( string content )
        {
            JObject json = JObject.Parse( content );
            OpcUaStringUrl = SoftBasic.GetValueFromJsonObject( json, nameof( OpcUaStringUrl ), "" );
            SecurityPolicyNone = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityPolicyNone ), false );
            SecurityPolicyBasic128_Sign = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityPolicyBasic128_Sign ), false );
            SecurityPolicyBasic128_Sign_Encrypt = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityPolicyBasic128_Sign_Encrypt ), false );
            SecurityPolicyBasic256_Sign = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityPolicyBasic256_Sign ), false );
            SecurityPolicyBasic256_Sign_Encrypt = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityPolicyBasic256_Sign_Encrypt ), false );
            SecurityAnonymous = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityAnonymous ), true );
            SecurityAccount = SoftBasic.GetValueFromJsonObject( json, nameof( SecurityAccount ), false );
            UserName = SoftBasic.GetValueFromJsonObject( json, nameof( UserName ), "admin" );
            Password = SoftBasic.GetValueFromJsonObject( json, nameof( Password ), "123456" );

        }


        /// <summary>
        /// 格式化成保存的字符串信息
        /// </summary>
        /// <returns></returns>
        public override string ToSaveString()
        {
            JObject json = new JObject
            {
                { nameof( OpcUaStringUrl ), new JValue( OpcUaStringUrl ) },
                { nameof( SecurityPolicyNone ), new JValue(SecurityPolicyNone) },
                { nameof( SecurityPolicyBasic128_Sign ), new JValue(SecurityPolicyBasic128_Sign) },
                { nameof( SecurityPolicyBasic128_Sign_Encrypt ), new JValue(SecurityPolicyBasic128_Sign_Encrypt) },
                { nameof( SecurityPolicyBasic256_Sign ), new JValue(SecurityPolicyBasic256_Sign) },
                { nameof( SecurityPolicyBasic256_Sign_Encrypt ), new JValue(SecurityPolicyBasic256_Sign_Encrypt) },
                { nameof( SecurityAnonymous ), new JValue(SecurityAnonymous) },
                { nameof( SecurityAccount ), new JValue(SecurityAccount) },
                { nameof( UserName ), new JValue(UserName) },
                { nameof( Password ), new JValue(Password) }
            };
            return json.ToString( );
        }


    }
}
