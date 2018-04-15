using HSLSharp.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSLSharp.RequestSettings;
using System.Xml.Linq;

namespace HSLSharp.NodeSettings
{
    public partial class FormRegularCode : Form
    {
        #region Constructor

        public FormRegularCode()
        {
            InitializeComponent( );

        }

        #endregion

        #region Form Load Close Show


        private void FormRegularCode_Load( object sender, EventArgs e )
        {
            treeView1.ImageList = Utils.ServerUtils.SharpImageList;

            treeView1.Nodes[0].ImageKey = "ExtensionManager_vsix";
            treeView1.Nodes[0].SelectedImageKey = "ExtensionManager_vsix";


        }





        #endregion

        private void treeView1_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt( e.Location );
                // 右键了控件
                TreeNode node = treeView1.SelectedNode;
                if (node == null) return;

                if (node.ImageKey == "ExtensionManager_vsix")
                {
                    // 显示第三个菜单框
                    contextMenuStrip3.Show( treeView1, e.Location );
                }
                else if (node.Tag.GetType( ) == typeof( NodeClass ))
                {
                    // 显示第一个菜单框
                    contextMenuStrip1.Show( treeView1, e.Location );
                }
                else if (node.Tag is RegularNode regularNode)
                {
                    // 显示第二个菜单框
                    contextMenuStrip2.Show( treeView1, e.Location );
                }
            }
        }

        private void 新增RequestToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            // 新增节点
            TreeNode node = treeView1.SelectedNode;
            using (FormNodeClass formNode = new FormNodeClass( ))
            {
                if (formNode.ShowDialog( ) == DialogResult.OK)
                {
                    formNode.SelectedNodeClass.Name = GetUniqueName( node, formNode.SelectedNodeClass.Name );

                    TreeNode nodeNew = new TreeNode( formNode.SelectedNodeClass.Name );
                    nodeNew.ImageKey = "usbcontroller";
                    nodeNew.SelectedImageKey = "usbcontroller";
                    nodeNew.Tag = formNode.SelectedNodeClass;
                    node.Nodes.Add( nodeNew );
                    node.Expand( );
                    isNodeSettingsModify = true;
                }
            }
        }

        private void 编辑RequestToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 编辑节点

            // 节点被选择的时候
            TreeNode node = treeView1.SelectedNode;

            if (node.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    // 编辑了节点
                    using (FormNodeClass formNode = new FormNodeClass( nodeClass ))
                    {
                        if (formNode.ShowDialog( ) == DialogResult.OK)
                        {
                            formNode.SelectedNodeClass.Name = GetUniqueName( node.Parent, formNode.SelectedNodeClass.Name );

                            node.Text = formNode.SelectedNodeClass.Name;
                            node.Tag = formNode.SelectedNodeClass;
                            isNodeSettingsModify = true;
                        }
                    }
                }
                else
                {
                    if (node.Tag is ModbusTcpClient modbusTcpNode)
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
                }
            }
        }

        private void 删除RequestToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 删除节点
            TreeNode node = treeView1.SelectedNode;


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


        private bool IsNodeSameNodeExist( TreeNode node, string name )
        {
            bool result = false;
            foreach (TreeNode item in node.Nodes)
            {
                if(item.Text == name)
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


        #region Private Member

        private bool isNodeSettingsModify = false;            // 指示系统的节点是否已经被编辑过

        #endregion



        private void 新增RequestToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增解析规则
            TreeNode node = treeView1.SelectedNode;
            using (FormRegularNode formNode = new FormRegularNode( ))
            {
                if (formNode.ShowDialog( ) == DialogResult.OK)
                {
                    formNode.RegularNode.Name = GetUniqueName( node, formNode.RegularNode.Name );

                    TreeNode nodeNew = new TreeNode( formNode.RegularNode.Name );
                    nodeNew.ImageKey = "Operator_660";
                    nodeNew.SelectedImageKey = "Operator_660";
                    nodeNew.Tag = formNode.RegularNode;
                    node.Nodes.Add( nodeNew );
                    node.Expand( );
                    isNodeSettingsModify = true;
                }
            }
        }

        private void 编辑解析ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 编辑鞋机
            TreeNode node = treeView1.SelectedNode;
            if(node.Tag is RegularNode regularNode)
            {
                using (FormRegularNode formNode = new FormRegularNode( regularNode ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        formNode.RegularNode.Name = GetUniqueName( node, formNode.RegularNode.Name );

                        node.Text = formNode.RegularNode.Name;
                        node.Tag = formNode.RegularNode;
                        isNodeSettingsModify = true;
                    }
                }
            }
        }




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


        private void SaveNodes( string fileName )
        {
            XElement element = new XElement( "Regulars" );
            foreach (TreeNode item in treeView1.Nodes[0].Nodes)
            {
                element.Add( AddTreeNode( item ) );
            }

            element.Save( fileName );
        }

        private void 保存文件ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            SaveNodes( "123.xml" );
        }
    }
}
