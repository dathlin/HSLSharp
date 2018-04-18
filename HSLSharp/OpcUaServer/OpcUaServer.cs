using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HSLSharp.OpcUaSupport
{

    /// <summary>
    /// 数据中转服务器的封装类
    /// </summary>
    public class OpcUaServer
    {
        #region Constructor

        /// <summary>
        /// 用过地址实例化一个OPC UA的服务器
        /// </summary>
        /// <param name="url"></param>
        public OpcUaServer(string url)
        {
            m_application = new ApplicationInstance();

            m_application.ApplicationType = ApplicationType.Server;

            // load the application configuration.
            // application.LoadApplicationConfiguration(false);

            m_application.ApplicationConfiguration = GetDefaultConfiguration(url);

            // check the application certificate.
            m_application.CheckApplicationInstanceCertificate(false, 0);

            var server = new DataTransferServer();
            DataTransferServer = server;
            m_server = server;

            // start the server.
            m_application.Start(m_server);

            m_configuration = m_application.ApplicationConfiguration;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// 服务器的示例
        /// </summary>
        public StandardServer StandardServer
        {
            get
            {
                return m_server;
            }
        }

        /// <summary>
        /// 服务器的实际实例
        /// </summary>
        public DataTransferServer DataTransferServer { get; private set; }

        /// <summary>
        /// 应用程序的配置示例
        /// </summary>
        public ApplicationConfiguration AppConfiguration
        {
            get
            {
                return m_configuration;
            }
        }

        #endregion

        #region Get Configuration

        private ApplicationConfiguration GetDefaultConfiguration(string url)
        {
            ApplicationConfiguration config = new ApplicationConfiguration();

            // 签名及加密验证
            ServerSecurityPolicyCollection policies = new ServerSecurityPolicyCollection( );
            if(Util.SharpSettings.SecurityPolicyNone)
            {
                policies.Add( new ServerSecurityPolicy( )
                {
                    SecurityMode = MessageSecurityMode.None,
                    SecurityPolicyUri = SecurityPolicies.None
                } );
            }
            if(Util.SharpSettings.SecurityPolicyBasic128_Sign)
            {
                policies.Add( new ServerSecurityPolicy( )
                {
                    SecurityMode = MessageSecurityMode.Sign,
                    SecurityPolicyUri = SecurityPolicies.Basic128Rsa15
                } );
            }
            if(Util.SharpSettings.SecurityPolicyBasic128_Sign_Encrypt)
            {
                policies.Add( new ServerSecurityPolicy( )
                {
                    SecurityMode = MessageSecurityMode.SignAndEncrypt,
                    SecurityPolicyUri = SecurityPolicies.Basic128Rsa15
                } );
            }
            if(Util.SharpSettings.SecurityPolicyBasic256_Sign)
            {
                policies.Add( new ServerSecurityPolicy( )
                {
                    SecurityMode = MessageSecurityMode.Sign,
                    SecurityPolicyUri = SecurityPolicies.Basic256
                } );
            }
            if(Util.SharpSettings.SecurityPolicyBasic256_Sign_Encrypt)
            {
                policies.Add( new ServerSecurityPolicy( )
                {
                    SecurityMode = MessageSecurityMode.SignAndEncrypt,
                    SecurityPolicyUri = SecurityPolicies.Basic256
                } );
            }

            // 用户名验证
            UserTokenPolicyCollection userTokens = new UserTokenPolicyCollection( );
            if(Util.SharpSettings.SecurityAnonymous)
            {
                userTokens.Add( new UserTokenPolicy( UserTokenType.Anonymous ) );
            }
            if(Util.SharpSettings.SecurityAccount)
            {
                userTokens.Add( new UserTokenPolicy( UserTokenType.UserName ) );
            }


            config.ApplicationName = "OpcUaServer";
            config.ApplicationType = ApplicationType.Server;


            config.SecurityConfiguration = new SecurityConfiguration()
            {
                ApplicationCertificate = new CertificateIdentifier()
                {
                    StoreType = "Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault",
                    SubjectName = config.ApplicationName,
                },

                TrustedPeerCertificates = new CertificateTrustList()
                {
                    StoreType = "Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications",
                },

                TrustedIssuerCertificates = new CertificateTrustList()
                {
                    StoreType = "Directory",
                    StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities",
                },

                RejectedCertificateStore = new CertificateStoreIdentifier()
                {
                    StoreType = "Directory",
                    StorePath = @"% CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates"
                }
            };
            config.TransportConfigurations = new TransportConfigurationCollection();
            config.TransportQuotas = new TransportQuotas();

            config.ServerConfiguration = new ServerConfiguration( )
            {
                // 配置登录的地址
                BaseAddresses = new string[]
                {
                     url
                },

                SecurityPolicies = policies,

                UserTokenPolicies = userTokens,

                DiagnosticsEnabled = false,           // 是否启用诊断
                MaxSessionCount = 1000,               // 最大打开会话数
                MinSessionTimeout = 10000,            // 允许该会话在与客户端断开时（单位毫秒）仍然保持连接的最小时间
                MaxSessionTimeout = 60000,            // 允许该会话在与客户端断开时（单位毫秒）仍然保持连接的最大时间
                MaxBrowseContinuationPoints = 1000,   // 用于Browse / BrowseNext操作的连续点的最大数量。
                MaxQueryContinuationPoints = 1000,    // 用于Query / QueryNext操作的连续点的最大数量
                MaxHistoryContinuationPoints = 500,   // 用于HistoryRead操作的最大连续点数。
                MaxRequestAge = 1000000,              // 传入请求的最大年龄（旧请求被拒绝）。
                MinPublishingInterval = 100,          // 服务器支持的最小发布间隔（以毫秒为单位）
                MaxPublishingInterval = 3600000,      // 服务器支持的最大发布间隔（以毫秒为单位）1小时
                PublishingResolution = 50,            // 支持的发布间隔（以毫秒为单位）的最小差异
                MaxSubscriptionLifetime = 3600000,    // 订阅将在没有客户端发布的情况下保持打开多长时间 1小时
                MaxMessageQueueSize = 100,            // 每个订阅队列中保存的最大消息数
                MaxNotificationQueueSize = 100,       // 为每个被监视项目保存在队列中的最大证书数
                MaxNotificationsPerPublish = 1000,    // 每次发布的最大通知数
                MinMetadataSamplingInterval = 1000,   // 元数据的最小采样间隔
                AvailableSamplingRates = new SamplingRateGroupCollection(new List<SamplingRateGroup>()
                {
                    new SamplingRateGroup(5, 5, 20),
                    new SamplingRateGroup(100, 100, 4),
                    new SamplingRateGroup(500, 250, 2),
                    new SamplingRateGroup(1000, 500, 20),
                }),                                // 可用的采样率
                MaxRegistrationInterval = 30000,   // 两次注册尝试之间的最大时间（以毫秒为单位）
                //NodeManagerSaveFile = string.Empty,// 包含节点的文件的路径由核心节点管理器持久化 ??
                
            };
            

            
            config.CertificateValidator = new CertificateValidator();
            config.CertificateValidator.Update(config);
            config.Extensions = new XmlElementCollection();

            return config;
        }

        #endregion
        
        #region Private Member

        private ApplicationInstance m_application;                // 应用实例
        private StandardServer m_server;                          // 服务器对象
        private ApplicationConfiguration m_configuration;

        #endregion

    }
}
