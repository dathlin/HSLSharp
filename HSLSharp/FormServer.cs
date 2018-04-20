using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSLSharp
{
    public partial class FormServer : Form
    {

        #region Constuctor


        public FormServer()
        {
            ImageImport( );
            InitializeComponent( );

            Icon = Util.GetWinformICon( );
        }


        #endregion

        #region Image Resource

        /// <summary>
        /// 导入所有的图片资源
        /// </summary>
        private void ImageImport()
        {
            Util.SharpImageList = new ImageList( );
            Util.SharpImageList.Images.Add( "abstr1", Properties.Resources.abstr1 );
            Util.SharpImageList.Images.Add( "action_add_16xLG", Properties.Resources.action_add_16xLG );
            Util.SharpImageList.Images.Add( "action_Cancel_16xLG", Properties.Resources.action_Cancel_16xLG );
            Util.SharpImageList.Images.Add( "ClassIcon", Properties.Resources.ClassIcon );
            Util.SharpImageList.Images.Add( "Class_489", Properties.Resources.Class_489 );
            Util.SharpImageList.Images.Add( "Enum_582", Properties.Resources.Enum_582 );
            Util.SharpImageList.Images.Add( "Event_594", Properties.Resources.Event_594 );
            Util.SharpImageList.Images.Add( "Event_594_exp", Properties.Resources.Event_594_exp );
            Util.SharpImageList.Images.Add( "FieldsHeader_12x", Properties.Resources.FieldsHeader_12x );
            Util.SharpImageList.Images.Add( "FlagRed_16x", Properties.Resources.FlagRed_16x );
            Util.SharpImageList.Images.Add( "FlagSpace_16x", Properties.Resources.FlagSpace_16x );
            Util.SharpImageList.Images.Add( "flag_16xLG", Properties.Resources.flag_16xLG );
            Util.SharpImageList.Images.Add( "GenericVSEditor_9905", Properties.Resources.GenericVSEditor_9905 );
            Util.SharpImageList.Images.Add( "HotSpot_10548", Properties.Resources.HotSpot_10548 );
            Util.SharpImageList.Images.Add( "ExtensionManager_vsix", Properties.Resources.ExtensionManager_vsix );
            Util.SharpImageList.Images.Add( "HotSpot_10548_color", Properties.Resources.HotSpot_10548_color );
            Util.SharpImageList.Images.Add( "library_16xLG", Properties.Resources.library_16xLG );
            Util.SharpImageList.Images.Add( "Method_636", Properties.Resources.Method_636 );
            Util.SharpImageList.Images.Add( "Module_648", Properties.Resources.Module_648 );
            Util.SharpImageList.Images.Add( "Monitor_Screen_16xLG", Properties.Resources.Monitor_Screen_16xLG );
            Util.SharpImageList.Images.Add( "Operator_660", Properties.Resources.Operator_660 );
            Util.SharpImageList.Images.Add( "PencilAngled_16xLG", Properties.Resources.PencilAngled_16xLG );
            Util.SharpImageList.Images.Add( "Property_501", Properties.Resources.Property_501 );
            Util.SharpImageList.Images.Add( "server_Local_16xLG", Properties.Resources.server_Local_16xLG );
            Util.SharpImageList.Images.Add( "star_16xLG", Properties.Resources.star_16xLG );
            Util.SharpImageList.Images.Add( "usbcontroller", Properties.Resources.usbcontroller );
            Util.SharpImageList.Images.Add( "VirtualMachine_16xLG", Properties.Resources.VirtualMachine_16xLG );
            Util.SharpImageList.Images.Add( "WindowsAzure_16xLG", Properties.Resources.WindowsAzure_16xLG );
            Util.SharpImageList.Images.Add( "WindowsAzure_16xLG_Cyan", Properties.Resources.WindowsAzure_16xLG_Cyan );
            Util.SharpImageList.Images.Add( "xbox1Color_16x", Properties.Resources.xbox1Color_16x );
        }


        #endregion


        private void button1_Click( object sender, EventArgs e )
        {

        }



        private void 节点配置器ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (FormNodeSetting form = new FormNodeSetting( ))
            {
                form.ShowDialog( );
            }
        }

        private void 解析规则配置器ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (NodeSettings.FormRegularCode form = new NodeSettings.FormRegularCode( ))
            {
                form.ShowDialog( );
            }
        }

        private void 测试客户端ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if(System.IO.File.Exists("OpcUaTest.exe"))
            {
                System.Diagnostics.Process.Start( "OpcUaTest.exe" );
            }
            else
            {
                MessageBox.Show( "文件不存在！" );
            }
        }

        private void oPCUA配置ToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using (FormOpcSettings form = new FormOpcSettings( ))
            {
                form.ShowDialog( );
            }
        }
    }
}
