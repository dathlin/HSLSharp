using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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





    }
}
