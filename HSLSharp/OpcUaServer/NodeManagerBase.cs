using Opc.Ua;
using Opc.Ua.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HSLSharp.OpcUaSupport
{
    public class NodeManagerBase : CustomNodeManager2
    {

        #region Constructor
        
        public NodeManagerBase(IServerInternal server, ApplicationConfiguration configuration)
            : base(server, configuration, Namespaces.Hsl)
        {
            dict_BaseDataVariableState = new Dictionary<string, BaseDataVariableState>();
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
        /// 更改前触发，可以禁止更改掉，返回 Bad 即可
        /// </summary>
        /// <param name="context"></param>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected ServiceResult OnWriteMyNode(ISystemContext context, NodeState node, ref object value)
        {
            return ServiceResult.Good;
        }

        /// <summary>
        /// 创建一个新的节点，节点名称为字符串
        /// </summary>
        protected FolderState CreateFolder(NodeState parent, string name)
        {
            FolderState folder = new FolderState(parent);

            folder.SymbolicName = name;
            folder.ReferenceTypeId = ReferenceTypes.Organizes;
            folder.TypeDefinitionId = ObjectTypeIds.FolderType;
            if (parent == null)
            {
                folder.NodeId = new NodeId(name, NamespaceIndex);
            }
            else
            {
                folder.NodeId = new NodeId(parent.NodeId.ToString() + "/" + name);
            }
            folder.BrowseName = new QualifiedName(name, NamespaceIndex);
            folder.DisplayName = new LocalizedText(name);
            folder.WriteMask = AttributeWriteMask.None;
            folder.UserWriteMask = AttributeWriteMask.None;
            folder.EventNotifier = EventNotifiers.None;

            if (parent != null)
            {
                parent.AddChild(folder);
            }

            return folder;
        }

        /// <summary>
        /// 创建一个只读的泛型值节点
        /// </summary>
        protected BaseDataVariableState<T> CreateReadonlyVariable<T>(NodeState parent, string name, NodeId dataType, int valueRank, T defaultValue)
        {
            BaseDataVariableState<T> variableState = CreateVariable(parent, name, dataType, valueRank, defaultValue);
            variableState.AccessLevel = AccessLevels.CurrentRead;
            return variableState;
        }


        /// <summary>
        /// 创建一个泛型值节点
        /// </summary>
        protected BaseDataVariableState<T> CreateVariable<T>(NodeState parent, string name, NodeId dataType, int valueRank, T defaultValue)
        {
            BaseDataVariableState<T> variable = new BaseDataVariableState<T>(parent);

            variable.SymbolicName = name;
            variable.ReferenceTypeId = ReferenceTypes.Organizes;
            variable.TypeDefinitionId = VariableTypeIds.BaseDataVariableType;
            if (parent == null)
            {
                variable.NodeId = new NodeId(name, NamespaceIndex);
            }
            else
            {
                variable.NodeId = new NodeId(parent.NodeId.ToString() + "/" + name);
            }
            variable.BrowseName = new QualifiedName(name, NamespaceIndex);
            variable.DisplayName = new LocalizedText(name);
            variable.WriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description;
            variable.UserWriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description;
            variable.DataType = dataType;
            variable.ValueRank = valueRank;
            variable.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Historizing = false;
            variable.Value = defaultValue;
            variable.StatusCode = StatusCodes.Good;
            variable.Timestamp = DateTime.Now;
     

            if (parent != null)
            {
                parent.AddChild(variable);
            }

            return variable;
        }

        /// <summary>
        /// 创建一个值节点，类型需要在创建的时候指定
        /// </summary>
        protected BaseDataVariableState CreateBaseVariable(NodeState parent, string name,string description, NodeId dataType, int valueRank, object defaultValue)
        {
            BaseDataVariableState variable = new BaseDataVariableState(parent);

            variable.SymbolicName = name;
            variable.ReferenceTypeId = ReferenceTypes.Organizes;
            variable.TypeDefinitionId = VariableTypeIds.BaseDataVariableType;
            if (parent == null)
            {
                variable.NodeId = new NodeId(name, NamespaceIndex);
            }
            else
            {
                variable.NodeId = new NodeId(parent.NodeId.ToString() + "/" + name);
            }
            variable.Description = description;
            variable.BrowseName = new QualifiedName(name, NamespaceIndex);
            variable.DisplayName = new LocalizedText(name);
            variable.WriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description;
            variable.UserWriteMask = AttributeWriteMask.DisplayName | AttributeWriteMask.Description;
            variable.DataType = dataType;
            variable.ValueRank = valueRank;
            variable.AccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            variable.Historizing = false;
            variable.Value = defaultValue;
            variable.StatusCode = StatusCodes.Good;
            variable.Timestamp = DateTime.Now;

            if (parent != null)
            {
                parent.AddChild(variable);
            }

            return variable;
        }


        /// <summary>
        /// 创建一个方法
        /// </summary>
        protected MethodState CreateMethod(NodeState parent, string name)
        {
            MethodState method = new MethodState(parent);

            method.SymbolicName = name;
            method.ReferenceTypeId = ReferenceTypeIds.HasComponent;
            if (parent == null)
            {
                method.NodeId = new NodeId(name, NamespaceIndex);
            }
            else
            {
                method.NodeId = new NodeId(parent.NodeId.ToString() + "/" + name);
            }
            method.BrowseName = new QualifiedName(name, NamespaceIndex);
            method.DisplayName = new LocalizedText(name);
            method.WriteMask = AttributeWriteMask.None;
            method.UserWriteMask = AttributeWriteMask.None;
            method.Executable = true;
            method.UserExecutable = true;

            if (parent != null)
            {
                parent.AddChild(method);
            }

            return method;
        }

        


        #endregion

        #region Node Dictionary

        protected Dictionary<string, BaseDataVariableState> dict_BaseDataVariableState;    // 节点管理器

        /// <summary>
        /// 在服务器端直接更改对应数据节点的值，并通知客户端
        /// </summary>
        /// <param name="nodeId">节点的名称</param>
        /// <param name="value">值，需要类型匹配</param>
        public void ChangeNodeData(string nodeId, object value)
        {
            if(dict_BaseDataVariableState.ContainsKey(nodeId))
            {
                lock (Lock)
                {
                    dict_BaseDataVariableState[nodeId].Value = value;
                    dict_BaseDataVariableState[nodeId].ClearChangeMasks(SystemContext, false);
                }
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") + "节点不存在，更新失败！");
            }
        }

        #endregion
    }
}
