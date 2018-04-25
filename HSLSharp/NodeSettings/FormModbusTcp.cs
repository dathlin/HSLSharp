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
            Icon = Util.GetWinformICon( );
        }

        public FormModbusTcp( NodeModbusTcpClient modbusTcpNode)
        {
            InitializeComponent( );
            ModbusTcpNode = modbusTcpNode;
            Icon = Util.GetWinformICon( );
        }

        private void FormModbusTcp_Load( object sender, EventArgs e )
        {
            if (ModbusTcpNode != null)
            {
                textBox1.Text = ModbusTcpNode.Name;
                textBox2.Text = ModbusTcpNode.Description;
                textBox3.Text = ModbusTcpNode.IpAddress;
                textBox4.Text = ModbusTcpNode.Port.ToString( );
                textBox5.Text = ModbusTcpNode.Station.ToString( );
                checkBox1.Checked = !ModbusTcpNode.IsAddressStartWithZero;
                textBox6.Text = ModbusTcpNode.ConnectTimeOut.ToString( );
            }
        }

        private void userButton1_Click( object sender, EventArgs e )
        {
            if (string.IsNullOrEmpty( textBox1.Text ))
            {
                MessageBox.Show( "节点名称不能为空" );
                return;
            }
            try
            {
                ModbusTcpNode = new NodeModbusTcpClient( )
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text,
                    IpAddress = textBox3.Text,
                    Port = int.Parse( textBox4.Text ),
                    Station = byte.Parse( textBox5.Text ),
                    IsAddressStartWithZero = !checkBox1.Checked,
                    ConnectTimeOut = int.Parse( textBox6.Text ),
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show( "数据填入异常：" + ex.Message );
                return;
            }
            DialogResult = DialogResult.OK;
        }





        public NodeModbusTcpClient ModbusTcpNode { get; set; }


    }
}
