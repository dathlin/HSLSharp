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
        public FormNodeSetting( )
        {
            InitializeComponent( );
        }

        private void FormNodeSetting_Load( object sender, EventArgs e )
        {
            treeView1.ImageList = Utils.ServerUtils.SharpImageList;

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
                Description = "所有的设备的集合对象"
            };
        }



        private void 类别classToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了类别
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                // 允许添加类别
                using (NodeSettings.FormNodeClass formNode = new NodeSettings.FormNodeClass( ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        TreeNode nodeNew = new TreeNode( formNode.SelectedNodeClass.Name );
                        nodeNew.ImageKey = "Class_489";
                        nodeNew.SelectedImageKey = "Class_489";
                        nodeNew.Tag = formNode.SelectedNodeClass;
                        node.Nodes.Add( nodeNew );
                        node.Expand( );
                    }
                }
            }
        }


        private void modbustcpclientToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了Modbus-Tcp客户端
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is NodeClass nodeClass)
            {
                // 允许添加设备
                using (NodeSettings.FormModbusTcp formNode = new NodeSettings.FormModbusTcp( new ModbusTcpClient( ) ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        TreeNode nodeNew = new TreeNode( formNode.ModbusTcpNode.Name );
                        nodeNew.ImageKey = "Module_648";
                        nodeNew.SelectedImageKey = "Module_648";
                        nodeNew.Tag = formNode.ModbusTcpNode;
                        node.Nodes.Add( nodeNew );
                        node.Expand( );
                    }
                }
            }
        }

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
                // 编辑了节点
                using (NodeSettings.FormNodeClass formNode = new NodeSettings.FormNodeClass( nodeClass ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        node.Text = formNode.SelectedNodeClass.Name;
                        node.Tag = formNode.SelectedNodeClass;
                    }
                }
            }
            else if (node.Tag is ModbusTcpClient modbusTcpNode)
            {
                // 编辑了Modbus-tcp节点
                using (NodeSettings.FormModbusTcp formNode = new NodeSettings.FormModbusTcp( modbusTcpNode ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        node.Text = formNode.ModbusTcpNode.Name;
                        node.Tag = formNode.ModbusTcpNode;
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
                    }
                }
            }
        }

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

        


        private void treeView1_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                // 右键了控件
                TreeNode node = treeView1.SelectedNode;
                if (node.Tag.GetType() == typeof(NodeClass))
                {
                    // 显示第一个菜单框
                    contextMenuStrip1.Show( treeView1, e.Location );
                }
                else if (node.Tag.GetType( ) == typeof( DeviceNode ))
                {
                    // 显示第二个菜单框
                    contextMenuStrip2.Show( treeView1, e.Location );
                }
                else if (node.Tag.GetType( ) == typeof( DeviceRequest ))
                {
                    // 显示第三个菜单框
                    contextMenuStrip3.Show( treeView1, e.Location );
                }
            }
        }

        private void 删除deleteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 删除节点信息
            TreeNode node = treeView1.SelectedNode;
            if (node.ImageKey == "VirtualMachine_16xLG")
            {
                MessageBox.Show( "无法删除系统节点！" );
                return;
            }

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

        private void 新增RequestToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 新增了Modbus-Tcp客户端
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is DeviceNode deviceNode)
            {
                // 允许添加设备
                using (RequestSettings.FormRequest formNode = new RequestSettings.FormRequest( ))
                {
                    if (formNode.ShowDialog( ) == DialogResult.OK)
                    {
                        TreeNode nodeNew = new TreeNode( formNode.DeviceRequest.Name );
                        nodeNew.ImageKey = "usbcontroller";
                        nodeNew.SelectedImageKey = "usbcontroller";
                        nodeNew.Tag = formNode.DeviceRequest;
                        node.Nodes.Add( nodeNew );
                        node.Expand( );
                    }
                }
            }
        }



        private void 保存文件ToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }



        private XElement AddTreeNode( TreeNode node )
        {
            if(node.Tag.GetType() == typeof(NodeClass))
            {
                NodeClass nodeClass = (NodeClass)node.Tag;
                XElement element = nodeClass.ToXmlElement( );
                foreach (TreeNode item in node.Nodes)
                {
                    element.Add( AddTreeNode( item ) );
                }
                return element;
            }
            else
            {
                return null;
            }
        }


        private void SaveNodes(string fileName)
        {

        }

    }
}
