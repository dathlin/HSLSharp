using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;




namespace HSLSharp.OpcUaSupport
{


    /// <summary>
    /// 一个数据中转服务器的实现
    /// </summary>
    public class DataTransferServer : StandardServer
    {
        #region Constructor

        public DataTransferServer()
        {
           // DictionaryIdentity.Add(U, "123456");
        }



        #endregion


        #region Overridden Methods
        /// <summary>
        /// Creates the node managers for the server.
        /// </summary>
        /// <remarks>
        /// This method allows the sub-class create any additional node managers which it uses. The SDK
        /// always creates a CoreNodeManager which handles the built-in nodes defined by the specification.
        /// Any additional NodeManagers are expected to handle application specific nodes.
        /// </remarks>
        protected override MasterNodeManager CreateMasterNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            Utils.Trace("Creating the Node Managers.");

            List<INodeManager> nodeManagers = new List<INodeManager>();
            
            ModTcpNodeManager = new HSharpNodeManager(server, configuration);
            nodeManagers.Add(ModTcpNodeManager);

            // create master node manager.
            return new MasterNodeManager(server, configuration, null, nodeManagers.ToArray());
        }

        /// <summary>
        /// Loads the non-configurable properties for the application.
        /// 加载一些不需要配置的属性
        /// </summary>
        /// <remarks>
        /// These properties are exposed by the server but cannot be changed by administrators.
        /// </remarks>
        protected override ServerProperties LoadServerProperties()
        {
            ServerProperties properties = new ServerProperties();

            properties.ManufacturerName = "Present By Richard.Hu";
            properties.ProductName = "Opc Ua 数据中转服务器";
            properties.ProductUri = "http://www.cnblogs.com/dathlin/";
            properties.SoftwareVersion = "1.0.0";
            properties.BuildNumber = "1";
            properties.BuildDate = new DateTime(2018, 03, 18);

            // TBD - All applications have software certificates that need to added to the properties.

            return properties;
        }



        /// <summary>
        /// 服务器启动之后将会调用的方法
        /// </summary>
        /// <param name="server"></param>
        protected override void OnServerStarted(IServerInternal server)
        {
            base.OnServerStarted(server);

            // request notifications when the user identity is changed. all valid users are accepted by default.
            // 更改用户身份时请求通知。 默认情况下接受所有有效用户
            server.SessionManager.ImpersonateUser += new ImpersonateEventHandler(SessionManager_ImpersonateUser);


        }

        /// <summary>
        /// Creates the resource manager for the server.
        /// </summary>
        protected override ResourceManager CreateResourceManager(IServerInternal server, ApplicationConfiguration configuration)
        {
            ResourceManager resourceManager = new ResourceManager(server, configuration);

            // add some localized strings to the resource manager to demonstrate that localization occurs.
            resourceManager.Add("InvalidPassword", "zh-cn", "密码验证失败，'{0}'.");

            resourceManager.Add("UnexpectedUserTokenError", "zh-cn", "错误的用户令牌。");

            resourceManager.Add("BadUserAccessDenied", "zh-cn", "当前用户名不存在。");

            return resourceManager;
        }

        /// <summary>
        /// Called when a client tries to change its user identity.
        /// </summary>
        private void SessionManager_ImpersonateUser(Session session, ImpersonateEventArgs args)
        {
            // check for a WSS token.
            IssuedIdentityToken wssToken = args.NewIdentity as IssuedIdentityToken;

            if (wssToken != null)
            {
                SecurityToken kerberosToken = ParseAndVerifyKerberosToken(wssToken.DecryptedTokenData);
                args.Identity = new UserIdentity(kerberosToken);
                Utils.Trace("Kerberos Token Accepted: {0}", args.Identity.DisplayName);
                return;
            }

            // check for a user name token.
            UserNameIdentityToken userNameToken = args.NewIdentity as UserNameIdentityToken;

            if (userNameToken != null)
            {
                VerifyPassword(userNameToken.UserName, userNameToken.DecryptedPassword);
                args.Identity = new UserIdentity(userNameToken);
                Utils.Trace("UserName Token Accepted: {0}", args.Identity.DisplayName);
                return;
            }

            // check for x509 user token.
            X509IdentityToken x509Token = args.NewIdentity as X509IdentityToken;

            if (x509Token != null)
            {
                VerifyCertificate(x509Token.Certificate);
                args.Identity = new UserIdentity(x509Token);
                Utils.Trace("X509 Token Accepted: {0}", args.Identity.DisplayName);
                return;
            }
        }

        /// <summary>
        /// Validates a Kerberos WSS user token.
        /// </summary>
        private SecurityToken ParseAndVerifyKerberosToken(byte[] tokenData)
        {
            XmlDocument document = new XmlDocument();
            XmlNodeReader reader = null;

            try
            {
                document.InnerXml = new UTF8Encoding().GetString(tokenData).Trim();
                reader = new XmlNodeReader(document.DocumentElement);

                SecurityToken securityToken = new WSSecurityTokenSerializer().ReadToken(reader, null);
                KerberosReceiverSecurityToken receiver = securityToken as KerberosReceiverSecurityToken;

                KerberosSecurityTokenAuthenticator authenticator = new KerberosSecurityTokenAuthenticator();

                if (authenticator.CanValidateToken(receiver))
                {
                    authenticator.ValidateToken(receiver);
                }

                return securityToken;
            }
            catch (Exception e)
            {
                // construct translation object with default text.
                TranslationInfo info = new TranslationInfo(
                    "InvalidKerberosToken",
                    "en-US",
                    "'{0}' is not a valid Kerberos token.",
                    document.DocumentElement.LocalName);

                // create an exception with a vendor defined sub-code.
                throw new ServiceResultException(new ServiceResult(
                    e,
                    StatusCodes.BadIdentityTokenRejected,
                    "InvalidKerberosToken",
                    Namespaces.Hsl,
                    new LocalizedText(info)));
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }




        /// <summary>
        /// Validates the password for a username token.
        /// </summary>
        private void VerifyPassword(string userName, string password)
        {
            if(userName == Util.SharpSettings.UserName && password == Util.SharpSettings.Password)
            {
                
            }
            else
            {
                throw ServiceResultException.Create( StatusCodes.BadUserAccessDenied, "Login failed for user: {0}", userName );
            }
        }

        /// <summary>
        /// Verifies that a certificate user token is trusted.
        /// </summary>
        private void VerifyCertificate(X509Certificate2 certificate)
        {
            try
            {
                m_certificateValidator.Validate(certificate);
            }
            catch (Exception e)
            {
                // construct translation object with default text.
                TranslationInfo info = new TranslationInfo(
                    "InvalidCertificate",
                    "en-US",
                    "'{0}' is not a trusted user certificate.",
                    certificate.Subject);

                // create an exception with a vendor defined sub-code.
                throw new ServiceResultException(new ServiceResult(
                    e,
                    StatusCodes.BadIdentityTokenRejected,
                    "InvalidCertificate",
                    Namespaces.Hsl,
                    new LocalizedText(info)));
            }
        }

        /// <summary>
        /// This method is called at the being of the thread that processes a request.
        /// </summary>
        protected override OperationContext ValidateRequest(RequestHeader requestHeader, RequestType requestType)
        {
            OperationContext context = null;
            try
            {
                context = base.ValidateRequest(requestHeader, requestType);
            }
            catch
            {
                return context;
            }

            if (requestType == RequestType.Write)
            {
                // reject all writes if no user provided.
                if (context.UserIdentity.TokenType == UserTokenType.Anonymous)
                {
                    // construct translation object with default text.
                    TranslationInfo info = new TranslationInfo(
                        "NoWriteAllowed",
                        "en-US",
                        "Must provide a valid windows user before calling write.");

                    // create an exception with a vendor defined sub-code.
                    throw new ServiceResultException(new ServiceResult(
                        StatusCodes.BadUserAccessDenied,
                        "NoWriteAllowed",
                        Namespaces.Hsl,
                        new LocalizedText(info)));
                }
            }

            return context;
        }

        // need to ensure the contexts are undone.
        private Dictionary<uint, ImpersonationContext> m_contexts = new Dictionary<uint, ImpersonationContext>();
        private Dictionary<string, string> DictionaryIdentity = new Dictionary<string, string>();
        private X509CertificateValidator m_certificateValidator;
        private object m_lock = new object();

        #endregion

        #region 两个公开的节点器
        
        /// <summary>
        /// Modbus TCP相关的节点管理器
        /// </summary>
        public HSharpNodeManager ModTcpNodeManager { get; set; }

        #endregion


    }
}
