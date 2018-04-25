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
    public partial class FormAbout : Form
    {
        public FormAbout( )
        {
            InitializeComponent( );

            Icon = Util.GetWinformICon( );
        }

        private void FormAbout_Load( object sender, EventArgs e )
        {
            label2.Text = "V " + Util.SharpVersion.ToString( );
        }
    }
}
