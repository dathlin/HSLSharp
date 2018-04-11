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
            if(node.Tag is NodeClass nodeClass)
            {
                // 允许添加类别
                using (NodeSettings.FormNodeClass formNode = new NodeSettings.FormNodeClass( ))
                {
                    if(formNode.ShowDialog() == DialogResult.OK)
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
            else if(dataGridView1.RowCount > row)
            {
                int deleteRows = dataGridView1.RowCount - row;
                for (int i = 0; i < deleteRows; i++)
                {
                    dataGridView1.Rows.RemoveAt( dataGridView1.Rows.Count - 1 );
                }
            }
        }

        private void DataGridViewRenderNodeClass(NodeClass nodeClass)
        {
            DataGridSpecifyRowCount( 2 );
            dataGridView1.Rows[0].Cells[0].Value = "节点名称";
            dataGridView1.Rows[0].Cells[1].Value = nodeClass.Name;
            dataGridView1.Rows[1].Cells[0].Value = "描述";
            dataGridView1.Rows[1].Cells[1].Value = nodeClass.Description;
        }

        private void treeView1_MouseDown( object sender, MouseEventArgs e )
        {
            if(e.Button == MouseButtons.Right)
            {
                // 右键了控件
                TreeNode node = treeView1.SelectedNode;
                if (node.Tag is NodeClass nodeClass)
                {
                    // 显示第一个菜单框
                    contextMenuStrip1.Show( treeView1, e.Location );
                }
            }
        }
    }
}
