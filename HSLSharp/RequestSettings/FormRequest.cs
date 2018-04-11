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

namespace HSLSharp.RequestSettings
{
    public partial class FormRequest : Form
    {
        public FormRequest( DeviceRequest deviceRequest = null )
        {
            InitializeComponent( );
            DeviceRequest = deviceRequest;
        }

        private void FormRequest_Load( object sender, EventArgs e )
        {
            if(DeviceRequest == null)
            {
                DeviceRequest = new DeviceRequest( );
            }


            textBox1.Text = DeviceRequest.Name;
            textBox2.Text = DeviceRequest.Description;
            textBox3.Text = DeviceRequest.Address;
            textBox4.Text = DeviceRequest.Length.ToString( );
            textBox6.Text = DeviceRequest.CaptureInterval.ToString( );
            textBox5.Text = DeviceRequest.PraseRegularCode;
        }


        /// <summary>
        /// 单次的设备请求信息
        /// </summary>
        public DeviceRequest DeviceRequest { get; set; }

        private void userButton1_Click( object sender, EventArgs e )
        {
            try
            {
                DeviceRequest = new DeviceRequest( )
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text,
                    Address = textBox3.Text,
                    Length = ushort.Parse( textBox4.Text ),
                    CaptureInterval = int.Parse( textBox6.Text ),
                    PraseRegularCode = textBox5.Text,
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show( "数据填入失败！" + ex.Message );
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
