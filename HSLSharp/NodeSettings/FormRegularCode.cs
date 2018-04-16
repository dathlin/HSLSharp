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

        public FormRegularCode( )
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

            LoadByFile( Utils.ServerUtils.SharpSettings.RegularSettingsFilePath );
        }

        private void FormRegularCode_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (isNodeSettingsModify)
            {
                if (MessageBox.Show( "当前的配置信息已经修改过，但还未保存，是否需要保存？", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
                {
                    SaveNodes( Utils.ServerUtils.SharpSettings.RegularSettingsFilePath );
                }
            }
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


        #region Add NodeClass 


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

        #endregion

        #region Edit NodeClass

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

        #endregion

        #region Delete NodeClass Common


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


        #endregion

        #region NodeClass Rename

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

        #region Private Member

        private bool isNodeSettingsModify = false;            // 指示系统的节点是否已经被编辑过

        #endregion

        #region Add RegularNode

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


        #endregion

        #region Edit Regular


        private void 编辑解析ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 编辑鞋机
            TreeNode node = treeView1.SelectedNode;
            if (node.Tag is RegularNode regularNode)
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

        #endregion

        #region Save File



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
            try
            {
                XElement element = new XElement( "Regulars" );
                foreach (TreeNode item in treeView1.Nodes[0].Nodes)
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
            SaveNodes( Utils.ServerUtils.SharpSettings.RegularSettingsFilePath );
            isNodeSettingsModify = false;
        }

        private void 另存为ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // 另存为
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
                    node.ImageKey = "usbcontroller";
                    node.SelectedImageKey = "usbcontroller";

                    NodeClass nodeClass = new NodeClass( );
                    nodeClass.LoadByXmlElement( item );
                    node.Tag = nodeClass;
                    treeNode.Nodes.Add( node );

                    TreeNodeRender( node, item );
                }
                else if (item.Name == "RegularNode")
                {
                    TreeNode node = new TreeNode( item.Attribute( "Name" ).Value );
                    node.ImageKey = "Operator_660";
                    node.SelectedImageKey = "Operator_660";


                    RegularNode regularNode = new RegularNode( );
                    regularNode.LoadByXmlElement( item );
                    node.Tag = regularNode;
                    treeNode.Nodes.Add( node );
                }
            }
        }

        private void LoadByFile( string fileName )
        {
            if (!System.IO.File.Exists( fileName )) return;
            try
            {
                treeView1.Nodes[0].Nodes.Clear( );

                XElement element = XElement.Load( fileName );
                if (element.Name != "Regulars") return;

                TreeNodeRender( treeView1.Nodes[0], element );

                treeView1.ExpandAll( );
            }
            catch (Exception ex)
            {
                MessageBox.Show( "加载文件失败，请确认是否系统生成的标准文件！原因：" + ex.Message );
            }
        }


        private void 打开文件ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog( ))
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

        #region Render Bitmap

        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if(e.Node.Tag is NodeClass nodeClass)
            {
                if(nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    List<RegularNode> regularNodes = new List<RegularNode>( );
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        if(item.Tag is RegularNode regular)
                        {
                            regularNodes.Add( regular );
                        }
                    }

                    pictureBox1.Image?.Dispose( );
                    pictureBox1.Image = GetRenderInfo( regularNodes );
                }
            }
        }

        private int GetNumberByUplimit( int value, int count )
        {
            if (value == 0) return 1;
            if(value % count == 0)
            {
                return value / count;
            }
            else
            {
                return value / count + 1;
            }
        }

        private Bitmap GetRenderInfo( List<RegularNode> regulars )
        {
            regulars.Sort( );
            int max_byte = regulars.Max( m => m.GetLengthByte( ) );
            int every_line_count = (pictureBox1.Width - 90) / 20;
            int line_count = GetNumberByUplimit( max_byte, every_line_count );


            Bitmap bitmap = new Bitmap( panel1.Width - 19, line_count * 50 + 5 );
            Graphics g = Graphics.FromImage( bitmap );
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            StringFormat stringFormat = new StringFormat( );
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            Font font_9 = new Font( "宋体", 7f );


            g.Clear( Color.AliceBlue );


            int paint_x = 85;
            int paint_y = 2;
            int count = 0;
            g.DrawLine( Pens.Gray, paint_x - 5, 0, paint_x - 5, bitmap.Height );

            for (int i = 0; i < line_count; i++)
            {
                g.DrawString( $"[{count.ToString( "D3" )} - {(count + Math.Min( max_byte - count, every_line_count  - 1)).ToString( "D3" )}]", Font, Brushes.DimGray, new Point( 2, paint_y + 16 ) );

                for (int j = 0; j < every_line_count; j++)
                {
                    Rectangle rec = new Rectangle( paint_x + j * 20, paint_y + 17, 16, 16 );
                    g.DrawRectangle( Pens.Gray, rec );
                    g.DrawString( count.ToString( ), font_9, Brushes.Black, rec, stringFormat );
                    count++;

                    if (count >= max_byte)
                        break;
                }

                paint_y += 50;
            }

            paint_y = 2;

            for (int i = 0; i < regulars.Count; i++)
            {
                int start = regulars[i].GetStartedByteIndex( );
                int length = regulars[i].GetLengthByte( ) - regulars[i].Index;

                int rowStart = GetNumberByUplimit( start, every_line_count );
                int rowEnd = GetNumberByUplimit( start + length, every_line_count );

                if(rowEnd == rowStart)
                {
                    // 同行的情况
                    Point first = new Point( paint_x + start % every_line_count * 20 + 8, paint_y + 17 + start / every_line_count * 50 + 20 );
                    Point second = new Point( paint_x + (start + length - 1) % every_line_count * 20 + 8, paint_y + 17 + (start + length - 1) / every_line_count * 50 + 20 );
                    g.DrawLine( Pens.DimGray, first, new Point( first.X, first.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, second, new Point( second.X, second.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, first, second );

                    Rectangle rectangle = new Rectangle( first.X - 20, first.Y, second.X - first.X + 40, 20 );
                    g.DrawString( regulars[i].Name, Font, Brushes.Blue, rectangle, stringFormat ); 
                }
                else
                {
                    Point first = new Point( paint_x + start % every_line_count * 20 + 8, paint_y + 17 + start / every_line_count * 50 + 20 );
                    Point first_2 = new Point( paint_x + every_line_count * 20, paint_y + 17 + start / every_line_count * 50 + 20 );
                    g.DrawLine( Pens.DimGray, first, new Point( first.X, first.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, first, first_2 );

                    Point second = new Point( paint_x + (start + length - 1) % every_line_count * 20 + 8, paint_y + 17 + (start + length - 1) / every_line_count * 50 + 20 );
                    Point second_2 = new Point( paint_x, paint_y + 17 + (start + length - 1) / every_line_count * 50 + 20 );
                    g.DrawLine( Pens.DimGray, second, new Point( second.X, second.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, second_2, second );

                    if((first_2.X-first.X)>= (second.X - second_2.X))
                    {
                        g.DrawString( regulars[i].Name, Font, Brushes.Blue, first );
                    }
                    else
                    {
                        g.DrawString( regulars[i].Name, Font, Brushes.Blue, second_2 );
                    }
                }


                for (int j = 0; j < length; j++)
                {
                    int paint_x_tmp = paint_x + (start + j) % every_line_count * 20;
                    int paint_y_tmp = paint_y + 17 + (start + j) / every_line_count * 50;

                    Rectangle rec = new Rectangle( paint_x_tmp, paint_y_tmp, 16, 16 );
                    g.FillRectangle( RegularModeTypeItem.GetDataPraseItemByCode( regulars[i].TypeCode ).BackColor, rec );
                    g.DrawRectangle( Pens.DimGray, rec );
                    g.DrawString( (regulars[i].Index + j).ToString(), font_9, Brushes.Black, rec, stringFormat );
                }
            }


            //for (int i = 0; i < regulars.Count; i++)
            //{
            //    int start = regulars[i].GetStartedByteIndex( );
            //    int end = regulars[i].GetLengthByte( ) + start;

            //    g.DrawLine( Pens.Gray, 80, 0, 80, bitmap.Height );
            //    g.DrawString( $"[{start.ToString("D3")} - {(end - 1).ToString("D3")}]", Font, Brushes.DimGray, new Point( 2, paint_y +1) );

            //    for (int j = 0; j < (end - start); j++)
            //    {
            //        Rectangle rec = new Rectangle( 85 + j * 20, paint_y + 2, 16, 16 );
            //        g.FillRectangle( RegularModeTypeItem.GetDataPraseItemByCode( regulars[i].TypeCode ).BackColor, rec );
            //        g.DrawRectangle( Pens.DimGray, rec );
            //    }


            //    g.DrawLine( Pens.LimeGreen, 90 + 20 * max_byte, paint_y, 90 + 20 * max_byte, paint_y + 20 );
            //    g.DrawString( regulars[i].Name, Font, Brushes.Blue, new Point( 95 + 20 * max_byte, paint_y +1 ) );


            //    paint_y += 20;
            //}




            stringFormat.Dispose( );
            font_9.Dispose( );
            return bitmap;
        }



        #endregion

 
    }
}
