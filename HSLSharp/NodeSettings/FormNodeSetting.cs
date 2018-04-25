using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSLSharp.Configuration;
using System.Xml.Linq;


/**********************************************************************************************
 * 
 *    说明：本界面最主要的功能是如果去解析xml文件，以及根据树节点的信息生成xml文件
 * 
 *    备注：树节点包含2个初始化的节点信息
 * 
 ***********************************************************************************************/



namespace HSLSharp
{
    public partial class FormNodeSetting : Form
    {
        #region Constructor


        public FormNodeSetting()
        {
            InitializeComponent( );
            Icon = Util.GetWinformICon( );
        }

        #endregion

        #region Form Load Show Close
        
        private void FormNodeSetting_Load( object sender, EventArgs e )
        {
            treeView1.ImageList = Util.SharpImageList;

            treeView1.Nodes[0].ImageKey = "VirtualMachine_16xLG";
            treeView1.Nodes[0].SelectedImageKey = "VirtualMachine_16xLG";
            treeView1.Nodes[0].Tag = new NodeClass( )
            {
                Name = "Devices",
                Description = "所有的设备的集合对象"
            };
            treeView1.Nodes[1].ImageKey = "VirtualMachine_16xLG";
            treeView1.Nodes[1].SelectedImageKey = "VirtualMachine_16xLG";
            treeView1.Nodes[1].Tag = new NodeClass( )
            {
                Name = "ModbusServer",
                Description = "所有的Modbus服务器的集合对象"
            };


            treeView1.Nodes[2].ImageKey = "VirtualMachine_16xLG";
            treeView1.Nodes[2].SelectedImageKey = "VirtualMachine_16xLG";
            treeView1.Nodes[2].Tag = new NodeClass( )
            {
                Name = "ModbusAlien",
                Description = "所有的异形ModbusTcp客户端的集合对象"
            };



            LoadByFile( Util.SharpSettings.NodeSettingsFilePath );
        }


        private void FormNodeSetting_FormClosing( object sender, FormClosingEventArgs e )
        {
            if(isNodeSettingsModify)
            {
                if(MessageBox.Show("当前的配置信息已经修改过，但还未保存，是否需要保存？","保存确认",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    SaveNodes( Util.SharpSettings.NodeSettingsFilePath );
                }
            }
        }

        #endregion

        #region ClassNode Add


        private void 类别classToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了类别
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    // 允许添加类别
                    using (NodeSettings.FormNodeClass formNode = new NodeSettings.FormNodeClass( ))
                    {
                        if (formNode.ShowDialog( ) == DialogResult.OK)
                        {
                            formNode.SelectedNodeClass.Name = GetUniqueName( node, formNode.SelectedNodeClass.Name );

                            TreeNode nodeNew = new TreeNode( formNode.SelectedNodeClass.Name );
                            nodeNew.ImageKey = "Class_489";
                            nodeNew.SelectedImageKey = "Class_489";
                            nodeNew.Tag = formNode.SelectedNodeClass;
                            node.Nodes.Add( nodeNew );
                            node.Expand( );
                            isNodeSettingsModify = true;
                        }
                    }
                }
            }
        }

        #endregion
        
        #region Modbus-Tcp Node Add
        
        private void modbustcpclientToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了Modbus-Tcp客户端
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    // 允许添加设备
                    using (NodeSettings.FormModbusTcp formNode = new NodeSettings.FormModbusTcp( new NodeModbusTcpClient( ) ))
                    {
                        if (formNode.ShowDialog( ) == DialogResult.OK)
                        {
                            formNode.ModbusTcpNode.Name = GetUniqueName( node, formNode.ModbusTcpNode.Name );

                            TreeNode nodeNew = new TreeNode( formNode.ModbusTcpNode.Name );
                            nodeNew.ImageKey = "Module_648";
                            nodeNew.SelectedImageKey = "Module_648";
                            nodeNew.Tag = formNode.ModbusTcpNode;
                            node.Nodes.Add( nodeNew );
                            node.Expand( );
                            isNodeSettingsModify = true;
                        }
                    }
                }
            }
        }

        #endregion
        
        #region DeviceRequestNode Add


        private void 新增RequestToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了Modbus-Tcp客户端
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is DeviceNode deviceNode)
            {
                // 允许添加设备
                using (RequestSettings.FormRequest formNode = new RequestSettings.FormRequest( new DeviceRequest( ) ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        formNode.DeviceRequest.Name = GetUniqueName( node, formNode.DeviceRequest.Name );

                        TreeNode nodeNew = new TreeNode( formNode.DeviceRequest.Name );
                        nodeNew.ImageKey = "usbcontroller";
                        nodeNew.SelectedImageKey = "usbcontroller";
                        nodeNew.Tag = formNode.DeviceRequest;
                        node.Nodes.Add( nodeNew );
                        node.Expand( );
                        isNodeSettingsModify = true;
                    }
                }
            }
        }

        #endregion

        #region Node Edit


        private void 编辑类别editClassToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 节点被选择的时候
            TreeNode node = treeView1.SelectedNode;
            if (node.ImageKey == "VirtualMachine_16xLG")
            {
                MessageBox.Show( "无法编辑系统节点！" );
                return;
            }

            if (node.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    // 编辑了节点
                    using (NodeSettings.FormNodeClass formNode = new NodeSettings.FormNodeClass( nodeClass ))
                    {
                        if (formNode.ShowDialog( ) == DialogResult.OK)
                        {
                            node.Text = formNode.SelectedNodeClass.Name;
                            node.Tag = formNode.SelectedNodeClass;
                            isNodeSettingsModify = true;
                        }
                    }
                }
                else if (nodeClass.NodeType == NodeClassInfo.AlienServer)
                {
                    if (node.Tag is AlienNode alienNode)
                    {
                        // 编辑了异形服务器节点信息
                        using (NodeSettings.FormAlienNode formNode = new NodeSettings.FormAlienNode( alienNode ))
                        {
                            if (formNode.ShowDialog( ) == DialogResult.OK)
                            {
                                node.Text = formNode.AlienNode.Name;
                                node.Tag = formNode.AlienNode;
                                isNodeSettingsModify = true;
                            }
                        }
                    }
                }
                else
                {
                    if (node.Tag is NodeModbusTcpClient modbusTcpNode)
                    {
                        // 编辑了Modbus-tcp节点
                        using (NodeSettings.FormModbusTcp formNode = new NodeSettings.FormModbusTcp( modbusTcpNode ))
                        {
                            if (formNode.ShowDialog( ) == DialogResult.OK)
                            {
                                node.Text = formNode.ModbusTcpNode.Name;
                                node.Tag = formNode.ModbusTcpNode;
                                isNodeSettingsModify = true;
                            }
                        }
                    }
                    else if(node.Tag is NodeModbusTcpAline modbusTcpAline)
                    {
                        // 编辑了Modbus-aline节点
                        using (NodeSettings.FormModbusTcpAlien formNode = new NodeSettings.FormModbusTcpAlien( modbusTcpAline ))
                        {
                            if (formNode.ShowDialog( ) == DialogResult.OK)
                            {
                                node.Text = formNode.ModbusTcpAline.Name;
                                node.Tag = formNode.ModbusTcpAline;
                                isNodeSettingsModify = true;
                            }
                        }
                    }
                    else if (node.Tag is DeviceRequest deviceRequest)
                    {
                        // 编辑了Request节点
                        using (RequestSettings.FormRequest formRequest = new RequestSettings.FormRequest( deviceRequest ))
                        {
                            if (formRequest.ShowDialog( ) == DialogResult.OK)
                            {
                                node.Text = formRequest.DeviceRequest.Name;
                                node.Tag = formRequest.DeviceRequest;
                                isNodeSettingsModify = true;
                            }
                        }
                    }
                    else if(node.Tag is NodeMelsecMc nodeMelsecMc)
                    {
                        // 编辑了三菱的节点数据
                        using (NodeSettings.FormMelsec3E formNode = new NodeSettings.FormMelsec3E( nodeMelsecMc ))
                        {
                            if (formNode.ShowDialog( ) == DialogResult.OK)
                            {
                                node.Text = formNode.MelsecMc.Name;
                                node.Tag = formNode.MelsecMc;
                                isNodeSettingsModify = true;
                            }
                        }
                    }
                }
            }
        }


        #endregion

        #region Node Render


        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            // 节点被选择的时候
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                // 显示选择的节点信息
                DataGridViewRenderNodeClass( nodeClass );
            }
        }


        


        private void DataGridSpecifyRowCount( int row )
        {
            if (dataGridView1.RowCount < row)
            {
                // 扩充
                dataGridView1.Rows.Add( row - dataGridView1.RowCount );
            }
            else if (dataGridView1.RowCount > row)
            {
                int deleteRows = dataGridView1.RowCount - row;
                for (int i = 0; i < deleteRows; i++)
                {
                    dataGridView1.Rows.RemoveAt( dataGridView1.Rows.Count - 1 );
                }
            }
            if (row > 0)
            {
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
        }

        private void DataGridViewRenderNodeClass( NodeClass nodeClass )
        {
            var renders = nodeClass.GetNodeClassRenders( );
            DataGridSpecifyRowCount( renders.Count );
            for (int i = 0; i < renders.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = renders[i].ValueName;
                dataGridView1.Rows[i].Cells[1].Value = renders[i].Value;
            }
        }


        #endregion

        #region ContextMenu Show

        private void treeView1_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt( e.Location );
                // 右键了控件
                TreeNode node = treeView1.SelectedNode;
                if (node == null) return;

                if (node.Text == "ModbusAlien" && node.ImageKey == "VirtualMachine_16xLG")
                {
                    cMS_AlienNode.Show( treeView1, e.Location );
                    return;
                }


                if (node.Text == "ModbusServer" && node.ImageKey == "VirtualMachine_16xLG")
                {
                    cMS_ModbusServer.Show( treeView1, e.Location );
                    return;
                }




                if (node.Tag.GetType( ) == typeof( NodeClass ))
                {
                    // 显示第一个菜单框
                    cMS_Device.Show( treeView1, e.Location );
                }
                else if(node.Tag.GetType( ) == typeof( AlienNode ))
                {
                    // 显示新增异形客户端
                    cMS_AlienClient.Show( treeView1, e.Location );
                }
                else if (node.Tag is DeviceNode)
                {
                    // 显示第二个菜单框
                    cMS_Request.Show( treeView1, e.Location );
                }
                else if (node.Tag is DeviceRequest)
                {
                    // 显示第三个菜单框
                    cMs_EditRequest.Show( treeView1, e.Location );
                }
                else if (node.Tag is AlienNode)
                {

                }
            }
        }

        #endregion

        #region Node Delete
        
        private void 删除deleteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 删除节点信息
            TreeNode node = treeView1.SelectedNode;
            if (node.ImageKey == "VirtualMachine_16xLG")
            {
                MessageBox.Show( "无法删除系统节点！" );
                return;
            }



            isNodeSettingsModify = true;
            if (node.Nodes.Count == 0)
            {
                node.Parent.Nodes.Remove( node );
            }
            else
            {
                if (MessageBox.Show( "还有子节点数据存在，是否真的删除节点及子节点信息？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
                {
                    node.Parent.Nodes.Remove( node );
                }
            }
        }


        #endregion

        #region Node Save

        private XElement AddTreeNode( TreeNode node )
        {
            if (node.Tag is NodeClass nodeClass)
            {
                XElement element = nodeClass.ToXmlElement( );
                foreach (TreeNode item in node.Nodes)
                {
                    element.Add( AddTreeNode( item ) );
                }
                return element;
            }

            return null;
        }


        private void SaveNodes(string fileName)
        {
            try
            {
                XElement element = new XElement( "Settings" );
                foreach (TreeNode item in treeView1.Nodes)
                {
                    element.Add( AddTreeNode( item ) );
                }

                element.Save( fileName );

                MessageBox.Show( "保存成功！" );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "保存失败！原因：" + ex.Message );
            }
        }


        private void 保存文件ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            SaveNodes( Util.SharpSettings.NodeSettingsFilePath );
            isNodeSettingsModify = false;
        }

        private void 另存为ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (SaveFileDialog dialog = new SaveFileDialog( ))
            {
                dialog.Filter = "xml文件|*.xml";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog( ) == DialogResult.OK)
                {
                    SaveNodes( dialog.FileName );
                    isNodeSettingsModify = false;
                }
            }
        }

        #endregion

        #region Node Load


        private void TreeNodeRender( TreeNode treeNode, XElement element )
        {
            foreach (XElement item in element.Elements( ))
            {
                if (item.Name == "NodeClass")
                {
                    TreeNode node = new TreeNode( item.Attribute( "Name" ).Value );
                    node.ImageKey = "Class_489";
                    node.SelectedImageKey = "Class_489";

                    NodeClass nodeClass = new NodeClass( );
                    nodeClass.LoadByXmlElement( item );
                    node.Tag = nodeClass;
                    treeNode.Nodes.Add( node );

                    TreeNodeRender( node, item );
                }
                else if (item.Name == "DeviceNode")
                {
                    int type = int.Parse( item.Attribute( "DeviceType" ).Value );

                    TreeNode deviceNode = new TreeNode( item.Attribute( "Name" ).Value );
                    if (type == DeviceNode.ModbusTcpClient)
                    {
                        deviceNode.ImageKey = "Module_648";
                        deviceNode.SelectedImageKey = "Module_648";

                        NodeModbusTcpClient modbusNode = new NodeModbusTcpClient( );
                        modbusNode.LoadByXmlElement( item );
                        deviceNode.Tag = modbusNode;
                        
                    }
                    else if (type == DeviceNode.ModbusTcpAlien)
                    {
                        deviceNode.ImageKey = "Module_648";
                        deviceNode.SelectedImageKey = "Module_648";

                        NodeModbusTcpAline modbusAlien = new NodeModbusTcpAline( );
                        modbusAlien.LoadByXmlElement( item );
                        deviceNode.Tag = modbusAlien;

                    }


                    treeNode.Nodes.Add( deviceNode );
                    foreach (XElement request in item.Elements( "DeviceRequest" ))
                    {
                        TreeNode nodeRequest = new TreeNode( request.Attribute( "Name" ).Value );
                        nodeRequest.ImageKey = "usbcontroller";
                        nodeRequest.SelectedImageKey = "usbcontroller";

                        DeviceRequest deviceRequest = new DeviceRequest( );
                        deviceRequest.LoadByXmlElement( request );
                        nodeRequest.Tag = deviceRequest;
                        deviceNode.Nodes.Add( nodeRequest );
                    }

                }
                else if (item.Name == "AlienNode")
                {
                    TreeNode node = new TreeNode( item.Attribute( "Name" ).Value );
                    node.ImageKey = "server_Local_16xLG";
                    node.SelectedImageKey = "server_Local_16xLG";

                    AlienNode nodeClass = new AlienNode( );
                    nodeClass.LoadByXmlElement( item );
                    node.Tag = nodeClass;
                    treeNode.Nodes.Add( node );

                    TreeNodeRender( node, item );
                }
            }
        }

        private void LoadByFile(string fileName)
        {
            if (!System.IO.File.Exists( fileName )) return;
            try
            {
                treeView1.Nodes[0].Nodes.Clear( );
                treeView1.Nodes[1].Nodes.Clear( );

                XElement element = XElement.Load( fileName );
                if (element.Name != "Settings") return;
                // 提取Devices节点数据
                TreeNodeRender( treeView1.Nodes[0], element.Elements( ).ToArray( )[0] );

                TreeNodeRender( treeView1.Nodes[1], element.Elements( ).ToArray( )[1] );

                TreeNodeRender( treeView1.Nodes[2], element.Elements( ).ToArray( )[2] );

                treeView1.ExpandAll( );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "加载文件失败，请确认是否系统生成的标准文件！原因：" + ex.Message );
            }
        }


        private void 打开文件ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using(OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Xml File|*.xml";
                fileDialog.Multiselect = false;
                if (fileDialog.ShowDialog( ) == DialogResult.OK)
                {
                    LoadByFile( fileDialog.FileName );
                    isNodeSettingsModify = true;
                }
            }

        }


        #endregion

        #region NodeName Update

        private bool IsNodeSameNodeExist( TreeNode node, string name )
        {
            bool result = false;
            foreach (TreeNode item in node.Nodes)
            {
                if (item.Text == name)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private string GetUniqueName( TreeNode node, string name )
        {
            if (!IsNodeSameNodeExist( node, name )) return name;

            int index = 1;
            while (IsNodeSameNodeExist( node, name + index ))
            {
                index++;
            }
            return name + index;
        }

        #endregion

        private void 新增服务器ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                // 允许添加异形服务器
                using (NodeSettings.FormAlienNode formNode = new NodeSettings.FormAlienNode( new AlienNode( ) ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        formNode.AlienNode.Name = GetUniqueName( node, formNode.AlienNode.Name );

                        TreeNode nodeNew = new TreeNode( formNode.AlienNode.Name );
                        nodeNew.ImageKey = "server_Local_16xLG";
                        nodeNew.SelectedImageKey = "server_Local_16xLG";
                        nodeNew.Tag = formNode.AlienNode;
                        node.Nodes.Add( nodeNew );
                        node.Expand( );
                        isNodeSettingsModify = true;
                    }
                }
            }
        }

        private void 异形ModbusTcpToolStripMenuItem_Click( object sender, EventArgs e )
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                // 允许添加类别
                using (NodeSettings.FormModbusTcpAlien formNode = new NodeSettings.FormModbusTcpAlien( new NodeModbusTcpAline( ) ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        // 需要先进行判断DTU是否冲突
                        if (IsDTUExistModbusAlien( formNode.ModbusTcpAline.DTU, node ))
                        {
                            MessageBox.Show( "设备添加失败，DTU码重复！" );
                            return;
                        }


                        formNode.ModbusTcpAline.Name = GetUniqueName( node, formNode.ModbusTcpAline.Name );

                        TreeNode nodeNew = new TreeNode( formNode.ModbusTcpAline.Name );
                        nodeNew.ImageKey = "Module_648";
                        nodeNew.SelectedImageKey = "Module_648";
                        nodeNew.Tag = formNode.ModbusTcpAline;
                        node.Nodes.Add( nodeNew );
                        node.Expand( );
                        isNodeSettingsModify = true;
                    }
                }
            }
        }

        private bool IsDTUExistModbusAlien( string dtu, TreeNode treeNode )
        {
            List<string> dtus = new List<string>( );
            foreach (TreeNode item in treeNode.Nodes)
            {
                if(item.Tag is NodeModbusTcpAline modbusTcp)
                {
                    dtus.Add( modbusTcp.DTU );
                }
            }

            return dtus.Contains( dtu );
        }


        private void 三菱plcmelsecToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了Modbus-Tcp客户端
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    // 允许添加设备
                    using (NodeSettings.FormMelsec3E formNode = new NodeSettings.FormMelsec3E( null ))
                    {
                        if (formNode.ShowDialog( ) == DialogResult.OK)
                        {
                            formNode.MelsecMc.Name = GetUniqueName( node, formNode.MelsecMc.Name );

                            TreeNode nodeNew = new TreeNode( formNode.MelsecMc.Name );
                            nodeNew.ImageKey = "Enum_582";
                            nodeNew.SelectedImageKey = "Enum_582";
                            nodeNew.Tag = formNode.MelsecMc;
                            node.Nodes.Add( nodeNew );
                            node.Expand( );
                            isNodeSettingsModify = true;
                        }
                    }
                }
            }
        }

        #region Private Member

        private bool isNodeSettingsModify = false;            // 指示系统的节点是否已经被编辑过

        #endregion





    }
}
