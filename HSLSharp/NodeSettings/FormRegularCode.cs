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
            Icon = Util.GetWinformICon( );
        }

        #endregion

        #region Private Member

        private bool isShowText = true;


        #endregion

        #region Form Load Close Show


        private void FormRegularCode_Load( object sender, EventArgs e )
        {
            treeView1.ImageList = Util.SharpImageList;

            treeView1.Nodes[0].ImageKey = "ExtensionManager_vsix";
            treeView1.Nodes[0].SelectedImageKey = "ExtensionManager_vsix";

            LoadByFile( Util.SharpSettings.RegularSettingsFilePath );

            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

            panel1.SizeChanged += Panel1_SizeChanged;
        }

        private void Panel1_SizeChanged( object sender, EventArgs e )
        {
            UpdateTreeData( );
        }

        private void CheckBox1_CheckedChanged( object sender, EventArgs e )
        {
            //刷新显示
            isShowText = checkBox1.Checked;
            UpdateTreeData( );
        }

        private void FormRegularCode_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (isNodeSettingsModify)
            {
                if (MessageBox.Show( "当前的配置信息已经修改过，但还未保存，是否需要保存？", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
                {
                    SaveNodes( Util.SharpSettings.RegularSettingsFilePath );
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
                UpdateTreeData( );
            }
            else
            {
                if (MessageBox.Show( "还有子节点数据存在，是否真的删除节点及子节点信息？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.Yes)
                {
                    node.Parent.Nodes.Remove( node );
                    UpdateTreeData( );
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
                    UpdateTreeData( );
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
                        UpdateTreeData( );
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
            SaveNodes( Util.SharpSettings.RegularSettingsFilePath );
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

        private TreeNode treeNodeSelected = null;

        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if (e.Node.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    treeNodeSelected = e.Node;
                    UpdateTreeData( );
                }
            }
        }

        public void UpdateTreeData( )
        {
            if (treeNodeSelected == null) return;

            if (treeNodeSelected.Tag is NodeClass nodeClass)
            {
                if (nodeClass.NodeType == NodeClassInfo.NodeClass)
                {
                    if (panel1.Width < 10) return;

                    List<RegularNode> regularNodes = new List<RegularNode>( );
                    foreach (TreeNode item in treeNodeSelected.Nodes)
                    {
                        if (item.Tag is RegularNode regular)
                        {
                            regularNodes.Add( regular );
                        }
                    }

                    pictureBox1.Image?.Dispose( );
                    pictureBox1.Image = GetRenderInfo( regularNodes, string.Empty );
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

        private Point CalculatePointWithByteIndex( int paint_x, int paint_y, int every_line_count, int index )
        {
            return new Point( paint_x + index % every_line_count * 20 + 8, paint_y + 17 + index / every_line_count * 50 + 8 );
        }

        private void PaintLineAuxiliary( Graphics g, int paint_x, int paint_y, int every_line_count, int index, int byteLength, bool isDowm, string info, Font font, StringFormat stringFormat, RegularNode regularNode )
        {
            Point point1 = CalculatePointWithByteIndex( paint_x, paint_y, every_line_count, index );
            Point point2 = CalculatePointWithByteIndex( paint_x, paint_y, every_line_count, index + byteLength - 1 );
            if (point1.Y == point2.Y)
            {
                // 同一行的情况
                if (isDowm)
                {
                    point1.Offset( 0, 12 );
                    point2.Offset( 0, 12 );

                    g.DrawLine( Pens.DimGray, point1, new Point( point1.X, point1.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, point2, new Point( point2.X, point2.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, point1, point2 );

                    Rectangle rectangle = new Rectangle( point1.X - 40, point1.Y, point2.X - point1.X + 80, 20 );
                    if (regularNode.TypeLength == 1)
                    {
                        g.DrawString( info, Font, Brushes.Blue, rectangle, stringFormat );
                    }
                    else
                    {
                        g.DrawString( info + "*" + regularNode.TypeLength, Font, Brushes.Blue, rectangle, stringFormat );
                    }
                }
                else
                {
                    point1.Offset( 0, -11 );
                    point2.Offset( 0, -11 );

                    g.DrawLine( Pens.Chocolate, point1, new Point( point1.X, point1.Y + 3 ) );
                    g.DrawLine( Pens.Chocolate, point2, new Point( point2.X, point2.Y + 3 ) );
                    g.DrawLine( Pens.Chocolate, point1, point2 );

                    Rectangle rectangle = new Rectangle( point1.X - 40, point1.Y - 14, point2.X - point1.X + 80, 15 );
                    if (isShowText) g.DrawString( info, font, Brushes.Green, rectangle, stringFormat );
                }
            }
            else
            {
                if (isDowm)
                {
                    // 跨行的情况
                    point1.Offset( 0, 12 );
                    point2.Offset( 0, 12 );

                    Point point1_1 = CalculatePointWithByteIndex( paint_x, paint_y, every_line_count, every_line_count - 1 );
                    point1_1.Y = point1.Y;
                    point1_1.X += 10;
                    g.DrawLine( Pens.DimGray, point1, new Point( point1.X, point1.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, point1, point1_1 );


                    Point point2_2 = CalculatePointWithByteIndex( paint_x, paint_y, every_line_count, 0 );
                    point2_2.Y = point2.Y;
                    point2_2.X -= 10;
                    g.DrawLine( Pens.DimGray, point2, new Point( point2.X, point2.Y - 3 ) );
                    g.DrawLine( Pens.DimGray, point2, point2_2 );

                    if ((point1_1.X - point1.X) > (point2.X - point2_2.X))
                    {
                        Rectangle rectangle = new Rectangle( point1.X - 40, point1.Y, point1_1.X - point1.X + 80, 20 );
                        if (regularNode.TypeLength == 1)
                        {
                            g.DrawString( info, Font, Brushes.Blue, rectangle, stringFormat );
                        }
                        else
                        {
                            g.DrawString( info + "*" + regularNode.TypeLength, Font, Brushes.Blue, rectangle, stringFormat );
                        }
                    }
                    else
                    {
                        Rectangle rectangle = new Rectangle( point2_2.X - 40, point2.Y, point2.X - point2_2.X + 80, 20 );
                        if (regularNode.TypeLength == 1)
                        {
                            g.DrawString( info, Font, Brushes.Blue, rectangle, stringFormat );
                        }
                        else
                        {
                            g.DrawString( info + "*" + regularNode.TypeLength, Font, Brushes.Blue, rectangle, stringFormat );
                        }
                    }
                }
                else
                {
                    point1.Offset( 0, -11 );
                    point2.Offset( 0, -11 );


                    Point point1_1 = CalculatePointWithByteIndex( paint_x, paint_y, every_line_count, every_line_count - 1 );
                    point1_1.Y = point1.Y;
                    point1_1.X += 10;
                    g.DrawLine( Pens.Chocolate, point1, new Point( point1.X, point1.Y + 3 ) );
                    g.DrawLine( Pens.Chocolate, point1, point1_1 );

                    Point point2_2 = CalculatePointWithByteIndex( paint_x, paint_y, every_line_count, 0 );
                    point2_2.Y = point2.Y;
                    point2_2.X -= 10;
                    g.DrawLine( Pens.Chocolate, point2, new Point( point2.X, point2.Y + 3 ) );
                    g.DrawLine( Pens.Chocolate, point2, point2_2 );
                    

                    if ((point1_1.X - point1.X) > (point2.X - point2_2.X))
                    {
                        Rectangle rectangle = new Rectangle( point1.X - 40, point1.Y - 14, point1_1.X - point1.X + 80, 15 );
                        if (isShowText) g.DrawString( info, Font, Brushes.Green, rectangle, stringFormat );
                    }
                    else
                    {
                        Rectangle rectangle = new Rectangle( point2_2.X - 40, point2.Y - 14, point2.X - point2_2.X + 80, 15 );
                        if (isShowText) g.DrawString( info, Font, Brushes.Green, rectangle, stringFormat );
                    }

                }
            }
        }

        private readonly int EveryByteWidth = 16;

        private Bitmap GetRenderInfo( List<RegularNode> regulars, string selectedRegular )
        {
            regulars.Sort( );
            int max_byte = regulars.Count == 0 ? 0 : regulars.Max( m => m.GetLengthByte( ) );
            int every_byte_occupy = EveryByteWidth + 4;
            int every_line_count = (panel1.Width - 19 - 90) / every_byte_occupy;
            int line_count = GetNumberByUplimit( max_byte, every_line_count );


            Bitmap bitmap = new Bitmap( panel1.Width - 19, line_count * 50 + 5 );
            if (max_byte == 0) return bitmap;
            Graphics g = Graphics.FromImage( bitmap );
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            StringFormat stringFormat = new StringFormat( );
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            Font font_7 = new Font( "宋体", 7f );

            g.Clear( Color.AliceBlue );


            int paint_x = 85;
            int paint_y = 2;
            int count = 0;
            g.DrawLine( Pens.Gray, paint_x - 5, 0, paint_x - 5, bitmap.Height );

            for (int i = 0; i < line_count; i++)
            {
                g.DrawString( $"[{count.ToString( "D3" )} - {(count + Math.Min( max_byte - count - 1, every_line_count - 1 )).ToString( "D3" )}]", Font, Brushes.DimGray, new Point( 2, paint_y + EveryByteWidth ) );

                for (int j = 0; j < every_line_count; j++)
                {
                    Rectangle rec = new Rectangle( paint_x + j * (EveryByteWidth + 4), paint_y + 17, EveryByteWidth, EveryByteWidth );
                    g.DrawRectangle( Pens.Gray, rec );
                    g.DrawString( count.ToString( ), font_7, Brushes.Black, new Rectangle( paint_x + j * every_byte_occupy - every_byte_occupy, paint_y + 17, 56, EveryByteWidth ), stringFormat );
                    count++;

                    if (count >= max_byte)
                        break;
                }

                paint_y += 50;
            }

            paint_y = 2;

            for (int i = 0; i < regulars.Count; i++)
            {
                RegularNodeTypeItem regularNodeTypeItem = RegularNodeTypeItem.GetDataPraseItemByCode( regulars[i].TypeCode );

                int start = regulars[i].GetStartedByteIndex( );
                int length = regulars[i].GetLengthByte( ) - regulars[i].GetStartedByteIndex( );

                int rowStart = GetNumberByUplimit( start, every_line_count );
                int rowEnd = GetNumberByUplimit( start + length, every_line_count );


                // 同行的情况
                PaintLineAuxiliary( g, paint_x, paint_y, every_line_count, start, length, true, regulars[i].Name, Font, stringFormat , regulars[i] );

                // 绘制上面的数据
                if (regularNodeTypeItem.Length != 0)
                {
                    int tmp = start;
                    for (int j = 0; j < length / regularNodeTypeItem.Length; j++)
                    {
                        PaintLineAuxiliary( g, paint_x, paint_y, every_line_count, tmp, regularNodeTypeItem.Length, false, regularNodeTypeItem.Text, Font, stringFormat , regulars[i] );
                        tmp += regularNodeTypeItem.Length;
                    }
                }
                else
                {
                    PaintLineAuxiliary( g, paint_x, paint_y, every_line_count, start, length, false, regularNodeTypeItem.Text, Font, stringFormat , regulars[i] );
                }


                for (int j = 0; j < length; j++)
                {
                    int paint_x_tmp = paint_x + (start + j) % every_line_count * every_byte_occupy;
                    int paint_y_tmp = paint_y + 17 + (start + j) / every_line_count * 50;

                    Rectangle rec = new Rectangle( paint_x_tmp, paint_y_tmp, 16, 16 );
                    g.FillRectangle( regularNodeTypeItem.BackColor, rec );
                    g.DrawRectangle( Pens.DimGray, rec );
                    g.DrawString( (regulars[i].GetStartedByteIndex( ) + j).ToString( ), font_7, Brushes.Black, new Rectangle( paint_x_tmp - 20, paint_y_tmp, 56, 16 ), stringFormat );
                }
            }



            stringFormat.Dispose( );
            font_7.Dispose( );
            return bitmap;
        }



        #endregion

 
    }
}
