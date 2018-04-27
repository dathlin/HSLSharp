using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    /// <summary>
    /// 空设备，没有连接，不负责数据采集，只负责节点显示
    /// </summary>
    public class NodeEmpty : DeviceNode
    {

        #region Constructor


        public NodeEmpty()
        {
            Name = "空设备";
            Description = "此设备安装在角落，编号0001";
            DeviceType = DeviceNode.DeviceNone;
        }


        #endregion




    }
}
