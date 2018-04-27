using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSLSharp.Configuration;

namespace HSLSharp.NodeSettings
{
    public partial class FormSimplifyNet : Form
    {
        public FormSimplifyNet( NodeSimplifyNet nodeSimplifyNet = null )
        {
            InitializeComponent( );
            
            NodeSimplifyNet = nodeSimplifyNet ?? new NodeSimplifyNet( );
        }

        private void FormSimplifyNet_Load( object sender, EventArgs e )
        {
            if(NodeSimplifyNet != null)
            {
                textBox1.Text = NodeSimplifyNet.Name;
                textBox2.Text = NodeSimplifyNet.Description;
                textBox3.Text = NodeSimplifyNet.IpAddress;
                textBox4.Text = NodeSimplifyNet.Port.ToString( );
                textBox5.Text = NodeSimplifyNet.Token.ToString( );
                textBox6.Text = NodeSimplifyNet.ConnectTimeOut.ToString( );
            }


        }



        public NodeSimplifyNet NodeSimplifyNet { get; set; }

        private void userButton1_Click( object sender, EventArgs e )
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show( "名称不能为空" );
                return;
            }
            

            if (!IPAddress.TryParse( textBox3.Text, out IPAddress address ))
            {
                MessageBox.Show( "Ip地址输入失败！" );
                return;
            }

            if (!int.TryParse( textBox4.Text, out int port ))
            {
                MessageBox.Show( "Port端口号输入失败！" );
                return;
            }

            if (!Guid.TryParse( textBox5.Text, out Guid token ))
            {
                MessageBox.Show( "令牌输入失败！" );
                return;
            }

            if (!int.TryParse( textBox6.Text, out int connect ))
            {
                MessageBox.Show( "超时时间输入失败！" );
                return;
            }


            NodeSimplifyNet = new NodeSimplifyNet( )
            {
                Name = textBox1.Text,
                Description = textBox1.Text,
                IpAddress = address.ToString( ),
                Port = port,
                Token = token,
                ConnectTimeOut = connect,
            };

            DialogResult = DialogResult.OK;
        }
    }
}
