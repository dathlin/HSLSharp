namespace HSLSharp
{
    partial class FormServer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.节点配置器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.解析规则配置器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPCUA配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试客户端ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.软件信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统配置ToolStripMenuItem,
            this.测试客户端ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1039, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统配置ToolStripMenuItem
            // 
            this.系统配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.节点配置器ToolStripMenuItem,
            this.解析规则配置器ToolStripMenuItem,
            this.oPCUA配置ToolStripMenuItem});
            this.系统配置ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Property_501;
            this.系统配置ToolStripMenuItem.Name = "系统配置ToolStripMenuItem";
            this.系统配置ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.系统配置ToolStripMenuItem.Text = "系统配置";
            // 
            // 节点配置器ToolStripMenuItem
            // 
            this.节点配置器ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.ClassIcon;
            this.节点配置器ToolStripMenuItem.Name = "节点配置器ToolStripMenuItem";
            this.节点配置器ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.节点配置器ToolStripMenuItem.Text = "节点配置器";
            this.节点配置器ToolStripMenuItem.Click += new System.EventHandler(this.节点配置器ToolStripMenuItem_Click);
            // 
            // 解析规则配置器ToolStripMenuItem
            // 
            this.解析规则配置器ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.ExtensionManager_vsix;
            this.解析规则配置器ToolStripMenuItem.Name = "解析规则配置器ToolStripMenuItem";
            this.解析规则配置器ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.解析规则配置器ToolStripMenuItem.Text = "解析规则配置器";
            this.解析规则配置器ToolStripMenuItem.Click += new System.EventHandler(this.解析规则配置器ToolStripMenuItem_Click);
            // 
            // oPCUA配置ToolStripMenuItem
            // 
            this.oPCUA配置ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.server_Local_16xLG;
            this.oPCUA配置ToolStripMenuItem.Name = "oPCUA配置ToolStripMenuItem";
            this.oPCUA配置ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.oPCUA配置ToolStripMenuItem.Text = "OPC UA配置";
            this.oPCUA配置ToolStripMenuItem.Click += new System.EventHandler(this.oPCUA配置ToolStripMenuItem_Click);
            // 
            // 测试客户端ToolStripMenuItem
            // 
            this.测试客户端ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Monitor_Screen_16xLG;
            this.测试客户端ToolStripMenuItem.Name = "测试客户端ToolStripMenuItem";
            this.测试客户端ToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.测试客户端ToolStripMenuItem.Text = "测试客户端";
            this.测试客户端ToolStripMenuItem.Click += new System.EventHandler(this.测试客户端ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1039, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.软件信息ToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::HSLSharp.Properties.Resources.WindowsAzure_16xLG_Cyan;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // 软件信息ToolStripMenuItem
            // 
            this.软件信息ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.WindowsAzure_16xLG;
            this.软件信息ToolStripMenuItem.Name = "软件信息ToolStripMenuItem";
            this.软件信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.软件信息ToolStripMenuItem.Text = "软件信息";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(269, 17);
            this.toolStripStatusLabel1.Text = "Copyright By Richard Hu. All Rright Reserved";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 227);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备项监控";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 261);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1029, 394);
            this.panel2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1018, 370);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "运行记录监控：";
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton1.Location = new System.Drawing.Point(403, 2);
            this.userButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(78, 25);
            this.userButton1.TabIndex = 5;
            this.userButton1.UIText = "启动引擎";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1039, 679);
            this.Controls.Add(this.userButton1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSL Sharp Server";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 节点配置器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 解析规则配置器ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private HslCommunication.Controls.UserButton userButton1;
        private System.Windows.Forms.ToolStripMenuItem 测试客户端ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPCUA配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件信息ToolStripMenuItem;
    }
}

