using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Core;
using System.IO;
using HslCommunication.BasicFramework;
using System.Windows.Forms;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 控制所有的数据解析规则的加载和存储功能
    /// </summary>
    public class RegularManagement
    {
        #region Constructor

        /// <summary>
        /// 默认的无参构造函数
        /// </summary>
        public RegularManagement()
        {
            dic_reagulars = new Dictionary<string, DataParseRegular>( );
            dict_lock = new SimpleHybirdLock( );

            numericalOrder = new SoftNumericalOrder( "R", "", 8, Application.StartupPath + "\\regular_id.txt" );
        }

        #endregion

        #region Private Member


        private SimpleHybirdLock dict_lock = null;
        private string m_PathSave = string.Empty;                               // 文件加载或是存储的路径
        private Dictionary<string, DataParseRegular> dic_reagulars = null;      // 所有规则文件的内存列表
        private SoftNumericalOrder numericalOrder = null;                       // 唯一的暗号生成器


        #endregion
        
        #region Load Configuration

        /// <summary>
        /// 从指定的文件夹加载规则信息
        /// </summary>
        public void LoadBy()
        {
            string[] fileNames = Directory.GetFiles( m_PathSave + "\\Regulars", "R*.regular" );

            dict_lock.Enter( );

            dic_reagulars.Clear( );

            try
            {
                foreach (var item in fileNames)
                {
                    DataParseRegular parseRegular = new DataParseRegular( )
                    {
                        FileSavePath = item
                    };

                    parseRegular.LoadByFile( );
                    dic_reagulars.Add( parseRegular.RegularCode, parseRegular );
                }

                dict_lock.Leave( );
            }
            catch
            {
                dict_lock.Leave( );
                throw;                          // 保证异常的时候，退出锁并且还原异常
            }
        }


        #endregion
        
        #region Add Regular

        public void AddRegular( string regularDescription, List<ByteDataParse> dataParses )
        {
            string name = numericalOrder.GetNumericalOrder( );
            string filePath = m_PathSave + "\\Regulars\\" + name + ".regular";

            DataParseRegular regular = new DataParseRegular( )
            {
                RegularCode = name,
                RegularDescription = regularDescription,
                DataParses = dataParses,
                FileSavePath = filePath,
                ILogNet = Utils.ServerUtils.LogNet,
            };


            dict_lock.Enter( );
            try
            {
                if (dic_reagulars.ContainsKey( name ))
                {
                    dic_reagulars.Remove( name );
                }

                dic_reagulars.Add( name, regular );
                regular.SaveToFile( );

                dict_lock.Leave( );
            }
            catch
            {
                dict_lock.Leave( );
                throw;                          // 保证异常的时候，退出锁并且还原异常
            }
        }


        #endregion

        #region Delete Regular

        /// <summary>
        /// 删除一个字节配置器，如果没有则无效
        /// </summary>
        /// <param name="regularCode">规则代号</param>
        public void DeleteRegular(string regularCode)
        {
            dict_lock.Enter( );
            try
            {
                if (dic_reagulars.ContainsKey( regularCode ))
                {
                    File.Delete( dic_reagulars[regularCode].FileSavePath );
                    dic_reagulars.Remove( regularCode );
                }

                dict_lock.Leave( );
            }
            catch
            {
                dict_lock.Leave( );
                throw;                          // 保证异常的时候，退出锁并且还原异常
            }

        }

        #endregion

        #region Update Regular

        /// <summary>
        /// 更新字节配置器的信息
        /// </summary>
        /// <param name="regularCode">规则代号</param>
        /// <param name="regularName">规则名称</param>
        public void UpdateReagular(string regularCode, string regularDescription )
        {
            dict_lock.Enter( );

            try
            {
                if (dic_reagulars.ContainsKey( regularCode ))
                {
                    dic_reagulars[regularCode].RegularDescription = regularDescription;
                    dic_reagulars[regularCode].SaveToFile( );
                }

                dict_lock.Leave( );
            }
            catch
            {
                dict_lock.Leave( );
                throw;
            }
        }

        /// <summary>
        /// 更新字节配置器的信息
        /// </summary>
        /// <param name="regularCode">规则代号</param>
        /// <param name="dataParses">配置规则</param>
        public void UpdateReagular( string regularCode, List<ByteDataParse> dataParses )
        {
            dict_lock.Enter( );

            if (dataParses == null) dataParses = new List<ByteDataParse>( );

            try
            {
                if (dic_reagulars.ContainsKey( regularCode ))
                {
                    dic_reagulars[regularCode].DataParses = dataParses;
                    dic_reagulars[regularCode].SaveToFile( );
                }

                dict_lock.Leave( );
            }
            catch
            {
                dict_lock.Leave( );
                throw;
            }
        }

        /// <summary>
        /// 更新规则的基础信息，包含了规则名称，规则配置器
        /// </summary>
        /// <param name="regularCode">规则代号</param>
        /// <param name="regularDescription">规则名称</param>
        /// <param name="dataParses">规则解析列表</param>
        public void UpdateReagular( string regularCode, string regularDescription, List<ByteDataParse> dataParses )
        {
            dict_lock.Enter( );

            try
            {
                if (dic_reagulars.ContainsKey( regularCode ))
                {
                    dic_reagulars[regularCode].RegularDescription = regularDescription;
                    if (dataParses == null) dataParses = new List<ByteDataParse>( );
                    dic_reagulars[regularCode].DataParses = dataParses;
                    dic_reagulars[regularCode].SaveToFile( );
                }

                dict_lock.Leave( );
            }
            catch
            {
                dict_lock.Leave( );
                throw;
            }
        }


        #endregion

        #region Get Regulars

        


        #endregion

    }
}
