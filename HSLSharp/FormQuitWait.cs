using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HSLSharp
{
    public partial class FormQuitWait : Form
    {
        public FormQuitWait( Action action )
        {
            InitializeComponent( );
            ActionWait = action;
        }

        private void FormQuitWait_Load( object sender, EventArgs e )
        {

        }

        private Action ActionWait { get; set; }

        private void FormQuitWait_Shown( object sender, EventArgs e )
        {
            ThreadPool.QueueUserWorkItem( new WaitCallback( ThreadPoolAction ), null );
        }

        private void ThreadPoolAction(object obj)
        {
            ActionWait?.Invoke( );
            Thread.Sleep( 500 );

            Invoke( new Action( ( ) =>
             {
                 DialogResult = DialogResult.OK;
             } ) );
        }
    }
}
