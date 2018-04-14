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
        }


        #endregion

        #region Image Resource

        /// <summary>
        /// 导入所有的图片资源
        /// </summary>
        private void ImageImport()
        {
            Utils.ServerUtils.SharpImageList = new ImageList( );
            Utils.ServerUtils.SharpImageList.Images.Add( "abstr1", Properties.Resources.abstr1 );
            Utils.ServerUtils.SharpImageList.Images.Add( "action_add_16xLG", Properties.Resources.action_add_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "action_Cancel_16xLG", Properties.Resources.action_Cancel_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "ClassIcon", Properties.Resources.ClassIcon );
            Utils.ServerUtils.SharpImageList.Images.Add( "Class_489", Properties.Resources.Class_489 );
            Utils.ServerUtils.SharpImageList.Images.Add( "Enum_582", Properties.Resources.Enum_582 );
            Utils.ServerUtils.SharpImageList.Images.Add( "Event_594", Properties.Resources.Event_594 );
            Utils.ServerUtils.SharpImageList.Images.Add( "Event_594_exp", Properties.Resources.Event_594_exp );
            Utils.ServerUtils.SharpImageList.Images.Add( "FieldsHeader_12x", Properties.Resources.FieldsHeader_12x );
            Utils.ServerUtils.SharpImageList.Images.Add( "FlagRed_16x", Properties.Resources.FlagRed_16x );
            Utils.ServerUtils.SharpImageList.Images.Add( "FlagSpace_16x", Properties.Resources.FlagSpace_16x );
            Utils.ServerUtils.SharpImageList.Images.Add( "flag_16xLG", Properties.Resources.flag_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "GenericVSEditor_9905", Properties.Resources.GenericVSEditor_9905 );
            Utils.ServerUtils.SharpImageList.Images.Add( "HotSpot_10548", Properties.Resources.HotSpot_10548 );
            Utils.ServerUtils.SharpImageList.Images.Add( "ExtensionManager_vsix", Properties.Resources.ExtensionManager_vsix );
            Utils.ServerUtils.SharpImageList.Images.Add( "HotSpot_10548_color", Properties.Resources.HotSpot_10548_color );
            Utils.ServerUtils.SharpImageList.Images.Add( "library_16xLG", Properties.Resources.library_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "Method_636", Properties.Resources.Method_636 );
            Utils.ServerUtils.SharpImageList.Images.Add( "Module_648", Properties.Resources.Module_648 );
            Utils.ServerUtils.SharpImageList.Images.Add( "Monitor_Screen_16xLG", Properties.Resources.Monitor_Screen_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "Operator_660", Properties.Resources.Operator_660 );
            Utils.ServerUtils.SharpImageList.Images.Add( "PencilAngled_16xLG", Properties.Resources.PencilAngled_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "Property_501", Properties.Resources.Property_501 );
            Utils.ServerUtils.SharpImageList.Images.Add( "server_Local_16xLG", Properties.Resources.server_Local_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "star_16xLG", Properties.Resources.star_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "usbcontroller", Properties.Resources.usbcontroller );
            Utils.ServerUtils.SharpImageList.Images.Add( "VirtualMachine_16xLG", Properties.Resources.VirtualMachine_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "WindowsAzure_16xLG", Properties.Resources.WindowsAzure_16xLG );
            Utils.ServerUtils.SharpImageList.Images.Add( "WindowsAzure_16xLG_Cyan", Properties.Resources.WindowsAzure_16xLG_Cyan );
            Utils.ServerUtils.SharpImageList.Images.Add( "xbox1Color_16x", Properties.Resources.xbox1Color_16x );
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
    }
}
