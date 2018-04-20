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
    public partial class FormOpcSettings : Form
    {
        public FormOpcSettings( )
        {
            InitializeComponent( );

            Icon = Util.GetWinformICon( );
        }

        private void FormOpcSettings_Load( object sender, EventArgs e )
        {
            checkBox3.Text = @"Basic128Rsa15 - Sign & Encrypt";
            checkBox5.Text = @"Basic256 - Sign & Encrypt";
        }

        private void FormOpcSettings_Shown( object sender, EventArgs e )
        {
            checkBox1.Checked = Util.SharpSettings.SecurityPolicyNone;
            checkBox2.Checked = Util.SharpSettings.SecurityPolicyBasic128_Sign;
            checkBox3.Checked = Util.SharpSettings.SecurityPolicyBasic128_Sign_Encrypt;
            checkBox4.Checked = Util.SharpSettings.SecurityPolicyBasic256_Sign;
            checkBox5.Checked = Util.SharpSettings.SecurityPolicyBasic256_Sign_Encrypt;

            checkBox6.Checked = Util.SharpSettings.SecurityAnonymous;
            checkBox7.Checked = Util.SharpSettings.SecurityAccount;

            textBox1.Text = Util.SharpSettings.UserName;
            textBox2.Text = Util.SharpSettings.Password;
            textBox3.Text = Util.SharpSettings.OpcUaStringUrl;


        }

        private void userButton1_Click( object sender, EventArgs e )
        {
            // 保存配置
            if(checkBox7.Checked)
            {
                if(string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show( "用户名不能为空！" );
                    return;
                }

                if(string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show( "密码不能为空" );
                    return;
                }
            }
            
            if(string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show( "Opc ua的地址不能为空" );
            }

            Util.SharpSettings.OpcUaStringUrl = textBox3.Text;
            Util.SharpSettings.SecurityPolicyNone = checkBox1.Checked;
            Util.SharpSettings.SecurityPolicyBasic128_Sign = checkBox2.Checked;
            Util.SharpSettings.SecurityPolicyBasic128_Sign_Encrypt = checkBox3.Checked;
            Util.SharpSettings.SecurityPolicyBasic256_Sign = checkBox4.Checked;
            Util.SharpSettings.SecurityPolicyBasic256_Sign_Encrypt = checkBox5.Checked;

            Util.SharpSettings.SecurityAnonymous = checkBox6.Checked;
            Util.SharpSettings.SecurityAccount = checkBox7.Checked;

            Util.SharpSettings.UserName = textBox1.Text;
            Util.SharpSettings.Password = textBox2.Text;

            Util.SharpSettings.SaveToFile( );

            MessageBox.Show( "保存成功，重启生效。" );
        }
    }
}
