using HSLSharp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Core;
using System.IO;
using System.Xml.Linq;

namespace HSLSharp.SettingsSupport
{
    /// <summary>
    /// 系统的所有的解析规则的存储器，复杂实现加载，解析配置规则
    /// </summary>
    public class SharpRegulars
    {
        #region Constructor

        /// <summary>
        /// 实例化一个默认的构造方法
        /// </summary>
        public SharpRegulars()
        {
            sharpRegulars = new Dictionary<string, List<RegularNode>>( );
            dictLock = new SimpleHybirdLock( );
        }

        #endregion


        #region Public Method

        /// <summary>
        /// 从系统的xml文件中加载规则信息
        /// </summary>
        public void LoadRegulars()
        {
            if (File.Exists( filePath ))
            {
                XElement xElement = XElement.Load( filePath );
                if (xElement.Name == "Regulars")
                {
                    dictLock.Enter( );
                    sharpRegulars.Clear( );

                    foreach (var item in xElement.Elements( "NodeClass" ))
                    {
                        string name = item.Attribute( "Name" ).Value;
                        List<RegularNode> regulars = new List<RegularNode>( );

                        foreach (var node in item.Elements( "RegularNode" ))
                        {
                            RegularNode tmp = new RegularNode( );
                            tmp.LoadByXmlElement( node );
                            regulars.Add( tmp );
                        }



                        if (!sharpRegulars.ContainsKey( name ))
                        {
                            sharpRegulars.Add( name, regulars );
                        }
                    }


                    dictLock.Leave( );
                }
            }
        }

        /// <summary>
        /// 获取所有的规则数组，方便进行配置数据信息
        /// </summary>
        /// <returns></returns>
        public string[] GetRegularsArray()
        {
            string[] buffer = null;

            dictLock.Enter( );

            List<string> result = new List<string>( );
            foreach (var item in sharpRegulars)
            {
                result.Add( item.Key );
            }

            buffer = result.ToArray( );

            dictLock.Leave( );

            return buffer;
        }

        /// <summary>
        /// 获取指定关键字的所有的规则信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<RegularNode> GetRegularNodes( string key )
        {
            List<RegularNode> nodes = null;

            dictLock.Enter( );

            if (sharpRegulars.ContainsKey( key ))
            {
                nodes = sharpRegulars[key];
            }

            dictLock.Leave( );

            return nodes;
        }


        #endregion

        #region Public Properties

        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        

        #endregion
        
        #region Private Member

        private Dictionary<string, List<RegularNode>> sharpRegulars;          // 所有解析规则的缓存
        private SimpleHybirdLock dictLock;                                    // 词典的锁
        private string filePath = string.Empty;                               // 配置文件的存储路径

        #endregion

    }
}
