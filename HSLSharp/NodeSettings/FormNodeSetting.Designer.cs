

namespace HSLSharp
{
    partial class FormNodeSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Devices");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("ModbusServer");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("ModbusAlien");
            this.cMS_Device = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.类别classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.西门子PlcsiemensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三菱plcmelsecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.欧姆龙plcomronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modbustcpclientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑类别editClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HslSharpValueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HslSharpValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMS_Request = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增RequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑RequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除RequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMs_EditRequest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_ModbusServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增ModbusTcpServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_AlienNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_AlienClient = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.异形ModbusTcpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑节点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除节点ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new HSLSharp.Controls.TreeViewEx();
            this.空设备toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplifyNetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMS_Device.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cMS_Request.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cMs_EditRequest.SuspendLayout();
            this.cMS_ModbusServer.SuspendLayout();
            this.cMS_AlienNode.SuspendLayout();
            this.cMS_AlienClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // cMS_Device
            // 
            this.cMS_Device.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增类别ToolStripMenuItem,
            this.编辑类别editClassToolStripMenuItem,
            this.删除deleteToolStripMenuItem});
            this.cMS_Device.Name = "contextMenuStrip1";
            this.cMS_Device.Size = new System.Drawing.Size(181, 92);
            // 
            // 新增类别ToolStripMenuItem
            // 
            this.新增类别ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.类别classToolStripMenuItem,
            this.空设备toolStripMenuItem,
            this.西门子PlcsiemensToolStripMenuItem,
            this.三菱plcmelsecToolStripMenuItem,
            this.欧姆龙plcomronToolStripMenuItem,
            this.modbustcpclientToolStripMenuItem,
            this.simplifyNetToolStripMenuItem});
            this.新增类别ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.新增类别ToolStripMenuItem.Name = "新增类别ToolStripMenuItem";
            this.新增类别ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.新增类别ToolStripMenuItem.Text = "新增类别";
            // 
            // 类别classToolStripMenuItem
            // 
            this.类别classToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Class_489;
            this.类别classToolStripMenuItem.Name = "类别classToolStripMenuItem";
            this.类别classToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.类别classToolStripMenuItem.Text = "类别(class)";
            this.类别classToolStripMenuItem.Click += new System.EventHandler(this.类别classToolStripMenuItem_Click);
            // 
            // 西门子PlcsiemensToolStripMenuItem
            // 
            this.西门子PlcsiemensToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Event_594;
            this.西门子PlcsiemensToolStripMenuItem.Name = "西门子PlcsiemensToolStripMenuItem";
            this.西门子PlcsiemensToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.西门子PlcsiemensToolStripMenuItem.Text = "西门子Plc(siemens)";
            this.西门子PlcsiemensToolStripMenuItem.Click += new System.EventHandler(this.西门子PlcsiemensToolStripMenuItem_Click);
            // 
            // 三菱plcmelsecToolStripMenuItem
            // 
            this.三菱plcmelsecToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Enum_582;
            this.三菱plcmelsecToolStripMenuItem.Name = "三菱plcmelsecToolStripMenuItem";
            this.三菱plcmelsecToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.三菱plcmelsecToolStripMenuItem.Text = "三菱plc(melsec)";
            this.三菱plcmelsecToolStripMenuItem.Click += new System.EventHandler(this.三菱plcmelsecToolStripMenuItem_Click);
            // 
            // 欧姆龙plcomronToolStripMenuItem
            // 
            this.欧姆龙plcomronToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.HotSpot_10548_color;
            this.欧姆龙plcomronToolStripMenuItem.Name = "欧姆龙plcomronToolStripMenuItem";
            this.欧姆龙plcomronToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.欧姆龙plcomronToolStripMenuItem.Text = "欧姆龙plc(omron)";
            this.欧姆龙plcomronToolStripMenuItem.Click += new System.EventHandler(this.欧姆龙plcomronToolStripMenuItem_Click);
            // 
            // modbustcpclientToolStripMenuItem
            // 
            this.modbustcpclientToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Module_648;
            this.modbustcpclientToolStripMenuItem.Name = "modbustcpclientToolStripMenuItem";
            this.modbustcpclientToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.modbustcpclientToolStripMenuItem.Text = "Modbus-tcp-client";
            this.modbustcpclientToolStripMenuItem.Click += new System.EventHandler(this.modbustcpclientToolStripMenuItem_Click);
            // 
            // 编辑类别editClassToolStripMenuItem
            // 
            this.编辑类别editClassToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.PencilAngled_16xLG_color;
            this.编辑类别editClassToolStripMenuItem.Name = "编辑类别editClassToolStripMenuItem";
            this.编辑类别editClassToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑类别editClassToolStripMenuItem.Text = "编辑节点";
            this.编辑类别editClassToolStripMenuItem.Click += new System.EventHandler(this.编辑类别editClassToolStripMenuItem_Click);
            // 
            // 删除deleteToolStripMenuItem
            // 
            this.删除deleteToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_Cancel_16xLG;
            this.删除deleteToolStripMenuItem.Name = "删除deleteToolStripMenuItem";
            this.删除deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除deleteToolStripMenuItem.Text = "删除节点";
            this.删除deleteToolStripMenuItem.Click += new System.EventHandler(this.删除deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "系统的树节点信息：（右键进行操作）";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HslSharpValueName,
            this.HslSharpValue});
            this.dataGridView1.Location = new System.Drawing.Point(454, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(554, 564);
            this.dataGridView1.TabIndex = 3;
            // 
            // HslSharpValueName
            // 
            this.HslSharpValueName.HeaderText = "数据名称(Value Name)";
            this.HslSharpValueName.Name = "HslSharpValueName";
            this.HslSharpValueName.ReadOnly = true;
            this.HslSharpValueName.Width = 200;
            // 
            // HslSharpValue
            // 
            this.HslSharpValue.HeaderText = "数据值(Value)";
            this.HslSharpValue.Name = "HslSharpValue";
            this.HslSharpValue.ReadOnly = true;
            this.HslSharpValue.Width = 280;
            // 
            // cMS_Request
            // 
            this.cMS_Request.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增RequestToolStripMenuItem,
            this.编辑RequestToolStripMenuItem,
            this.删除RequestToolStripMenuItem});
            this.cMS_Request.Name = "contextMenuStrip2";
            this.cMS_Request.Size = new System.Drawing.Size(148, 70);
            // 
            // 新增RequestToolStripMenuItem
            // 
            this.新增RequestToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.新增RequestToolStripMenuItem.Name = "新增RequestToolStripMenuItem";
            this.新增RequestToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.新增RequestToolStripMenuItem.Text = "新增Request";
            this.新增RequestToolStripMenuItem.Click += new System.EventHandler(this.新增RequestToolStripMenuItem_Click);
            // 
            // 编辑RequestToolStripMenuItem
            // 
            this.编辑RequestToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.PencilAngled_16xLG_color;
            this.编辑RequestToolStripMenuItem.Name = "编辑RequestToolStripMenuItem";
            this.编辑RequestToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.编辑RequestToolStripMenuItem.Text = "编辑节点";
            this.编辑RequestToolStripMenuItem.Click += new System.EventHandler(this.编辑类别editClassToolStripMenuItem_Click);
            // 
            // 删除RequestToolStripMenuItem
            // 
            this.删除RequestToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_Cancel_16xLG;
            this.删除RequestToolStripMenuItem.Name = "删除RequestToolStripMenuItem";
            this.删除RequestToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.删除RequestToolStripMenuItem.Text = "删除节点";
            this.删除RequestToolStripMenuItem.Click += new System.EventHandler(this.删除deleteToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.保存文件ToolStripMenuItem,
            this.另存为ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.arrow_open_16xLG;
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 保存文件ToolStripMenuItem
            // 
            this.保存文件ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.save_16xLG;
            this.保存文件ToolStripMenuItem.Name = "保存文件ToolStripMenuItem";
            this.保存文件ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.保存文件ToolStripMenuItem.Text = "保存文件";
            this.保存文件ToolStripMenuItem.Click += new System.EventHandler(this.保存文件ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.save_16xLG;
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.另存为ToolStripMenuItem.Text = "另存为";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.另存为ToolStripMenuItem_Click);
            // 
            // cMs_EditRequest
            // 
            this.cMs_EditRequest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑节点ToolStripMenuItem,
            this.删除节点ToolStripMenuItem});
            this.cMs_EditRequest.Name = "contextMenuStrip3";
            this.cMs_EditRequest.Size = new System.Drawing.Size(125, 48);
            // 
            // 编辑节点ToolStripMenuItem
            // 
            this.编辑节点ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.PencilAngled_16xLG_color;
            this.编辑节点ToolStripMenuItem.Name = "编辑节点ToolStripMenuItem";
            this.编辑节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑节点ToolStripMenuItem.Text = "编辑节点";
            this.编辑节点ToolStripMenuItem.Click += new System.EventHandler(this.编辑类别editClassToolStripMenuItem_Click);
            // 
            // 删除节点ToolStripMenuItem
            // 
            this.删除节点ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_Cancel_16xLG;
            this.删除节点ToolStripMenuItem.Name = "删除节点ToolStripMenuItem";
            this.删除节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除节点ToolStripMenuItem.Text = "删除节点";
            this.删除节点ToolStripMenuItem.Click += new System.EventHandler(this.删除deleteToolStripMenuItem_Click);
            // 
            // cMS_ModbusServer
            // 
            this.cMS_ModbusServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ModbusTcpServerToolStripMenuItem});
            this.cMS_ModbusServer.Name = "cMS_ModbusServer";
            this.cMS_ModbusServer.Size = new System.Drawing.Size(208, 26);
            // 
            // 新增ModbusTcpServerToolStripMenuItem
            // 
            this.新增ModbusTcpServerToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.新增ModbusTcpServerToolStripMenuItem.Name = "新增ModbusTcpServerToolStripMenuItem";
            this.新增ModbusTcpServerToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.新增ModbusTcpServerToolStripMenuItem.Text = "新增ModbusTcpServer";
            // 
            // cMS_AlienNode
            // 
            this.cMS_AlienNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增服务器ToolStripMenuItem});
            this.cMS_AlienNode.Name = "cMS_AlienClient";
            this.cMS_AlienNode.Size = new System.Drawing.Size(137, 26);
            // 
            // 新增服务器ToolStripMenuItem
            // 
            this.新增服务器ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.新增服务器ToolStripMenuItem.Name = "新增服务器ToolStripMenuItem";
            this.新增服务器ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.新增服务器ToolStripMenuItem.Text = "新增服务器";
            this.新增服务器ToolStripMenuItem.Click += new System.EventHandler(this.新增服务器ToolStripMenuItem_Click);
            // 
            // cMS_AlienClient
            // 
            this.cMS_AlienClient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.编辑节点ToolStripMenuItem1,
            this.删除节点ToolStripMenuItem1});
            this.cMS_AlienClient.Name = "cMS_AlienClient";
            this.cMS_AlienClient.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.异形ModbusTcpToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "新增设备";
            // 
            // 异形ModbusTcpToolStripMenuItem
            // 
            this.异形ModbusTcpToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Module_648;
            this.异形ModbusTcpToolStripMenuItem.Name = "异形ModbusTcpToolStripMenuItem";
            this.异形ModbusTcpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.异形ModbusTcpToolStripMenuItem.Text = "异形Modbus-Tcp";
            this.异形ModbusTcpToolStripMenuItem.Click += new System.EventHandler(this.异形ModbusTcpToolStripMenuItem_Click);
            // 
            // 编辑节点ToolStripMenuItem1
            // 
            this.编辑节点ToolStripMenuItem1.Image = global::HSLSharp.Properties.Resources.PencilAngled_16xLG_color;
            this.编辑节点ToolStripMenuItem1.Name = "编辑节点ToolStripMenuItem1";
            this.编辑节点ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.编辑节点ToolStripMenuItem1.Text = "编辑节点";
            this.编辑节点ToolStripMenuItem1.Click += new System.EventHandler(this.编辑类别editClassToolStripMenuItem_Click);
            // 
            // 删除节点ToolStripMenuItem1
            // 
            this.删除节点ToolStripMenuItem1.Image = global::HSLSharp.Properties.Resources.action_Cancel_16xLG;
            this.删除节点ToolStripMenuItem1.Name = "删除节点ToolStripMenuItem1";
            this.删除节点ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.删除节点ToolStripMenuItem1.Text = "删除节点";
            this.删除节点ToolStripMenuItem1.Click += new System.EventHandler(this.删除deleteToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(20, 47);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "node_devices";
            treeNode7.Text = "Devices";
            treeNode8.Name = "node_modbusServer";
            treeNode8.Text = "ModbusServer";
            treeNode9.Name = "node_modbusAlien";
            treeNode9.Text = "ModbusAlien";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(428, 565);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // 空设备toolStripMenuItem
            // 
            this.空设备toolStripMenuItem.Image = global::HSLSharp.Properties.Resources.Method_636;
            this.空设备toolStripMenuItem.Name = "空设备toolStripMenuItem";
            this.空设备toolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.空设备toolStripMenuItem.Text = "空设备(empty)";
            this.空设备toolStripMenuItem.Click += new System.EventHandler(this.空设备toolStripMenuItem_Click);
            // 
            // simplifyNetToolStripMenuItem
            // 
            this.simplifyNetToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.FlagRed_16x;
            this.simplifyNetToolStripMenuItem.Name = "simplifyNetToolStripMenuItem";
            this.simplifyNetToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.simplifyNetToolStripMenuItem.Text = "SimplifyNet";
            this.simplifyNetToolStripMenuItem.Click += new System.EventHandler(this.simplifyNetToolStripMenuItem_Click);
            // 
            // FormNodeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1020, 635);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormNodeSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "节点配置器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNodeSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormNodeSetting_Load);
            this.cMS_Device.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cMS_Request.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cMs_EditRequest.ResumeLayout(false);
            this.cMS_ModbusServer.ResumeLayout(false);
            this.cMS_AlienNode.ResumeLayout(false);
            this.cMS_AlienClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TreeViewEx treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip cMS_Device;
        private System.Windows.Forms.ToolStripMenuItem 新增类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 类别classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 西门子PlcsiemensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三菱plcmelsecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 欧姆龙plcomronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modbustcpclientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑类别editClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMS_Request;
        private System.Windows.Forms.ToolStripMenuItem 新增RequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑RequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除RequestToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMs_EditRequest;
        private System.Windows.Forms.ToolStripMenuItem 编辑节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMS_ModbusServer;
        private System.Windows.Forms.ToolStripMenuItem 新增ModbusTcpServerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMS_AlienNode;
        private System.Windows.Forms.ToolStripMenuItem 新增服务器ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn HslSharpValueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HslSharpValue;
        private System.Windows.Forms.ContextMenuStrip cMS_AlienClient;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 编辑节点ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除节点ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 异形ModbusTcpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空设备toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplifyNetToolStripMenuItem;
    }
}