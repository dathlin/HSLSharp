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
    }
}
