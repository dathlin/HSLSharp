using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HSLSharp.OpcUaSupport
{
    /// <summary>
    /// Node manager 
    /// </summary>
    public class HSharpNodeManager : NodeManagerBase
    {

        #region Constructor
        
        public HSharpNodeManager(IServerInternal server, ApplicationConfiguration configuration)
            : base(server, configuration)
        {

        }
        
        #endregion
        
        #region IDisposable Members

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region INodeIdFactory Members

        /// <summary>
        /// Creates the NodeId for the specified node.
        /// </summary>
        public override NodeId New(ISystemContext context, NodeState node)
        {
            return node.NodeId;
        }

        #endregion
        
        #region INodeManager Members
        
        /// <summary>
        /// 在地址空间有用之前进行一些初始化的操作
        /// </summary>
        /// <remarks>
        /// The externalReferences is an out parameter that allows the node manager to link to nodes
        /// in other node managers. For example, the 'Objects' node is managed by the CoreNodeManager and
        /// should have a reference to the root folder node(s) exposed by this node manager.  
        /// </remarks>
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                LoadPredefinedNodes(SystemContext, externalReferences);

                IList<IReference> references = null;
                if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references))
                {
                    externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                }



                // 从Xml文件进行加载数据


                
                // 构建数据
                FolderState rootMy = CreateFolder(null,  "Modbus");
                rootMy.AddReference(ReferenceTypes.Organizes, true, ObjectIds.ObjectsFolder);
                references.Add(new NodeStateReference(ReferenceTypes.Organizes, false, rootMy.NodeId));
                rootMy.EventNotifier = EventNotifiers.SubscribeToEvents;
                AddRootNotifier(rootMy);
                

                

                //foreach (var node in Util.NodeSettings.Nodes)
                //{
                    //var dataVariableState = CreateBaseVariable( rootMy, node.NodeName, node.NodeDescription, DataTypeIds.Byte, ValueRanks.OneDimension, new Byte[node.DataLength] );

                    //dict_BaseDataVariableState.Add( dataVariableState.NodeId.ToString( ), dataVariableState );
                //}
                AddPredefinedNode(SystemContext, rootMy);
            }
        }



        #endregion


        #region Dictionary Resources

        


        #endregion



        public void DealWithContent(byte[] data)
        {

        }
        
    }
}
