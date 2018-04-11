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

namespace HSLSharp.NodeSettings
{
    public partial class FormModbusTcp : Form
    {
        public FormModbusTcp( )
        {
            InitializeComponent( );
        }

        private void FormModbusTcp_Load( object sender, EventArgs e )
        {

        }

        private void userButton1_Click( object sender, EventArgs e )
        {
            if (string.IsNullOrEmpty( textBox1.Text ))
            {
                MessageBox.Show( "节点名称不能为空" );
                return;
            }

            ModbusTcpNode = new ModbusTcpClient( )
            {
                Name = textBox1.Text,
                Description = textBox2.Text,
                IpAddress = textBox3.Text,
                Port = int.Parse(textBox4.Text),
                Station = byte.Parse(textBox5.Text),
                IsAddressStartWithZero = !checkBox1.Checked,
                ConnectTimeOut = int.Parse(textBox6.Text),
            };
            DialogResult = DialogResult.OK;
        }





        public ModbusTcpClient ModbusTcpNode { get; set; }


    }
}
