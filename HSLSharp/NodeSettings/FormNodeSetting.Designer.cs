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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HslSharpValueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HslSharpValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑类别editClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.类别classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.西门子PlcsiemensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三菱plcmelsecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.欧姆龙plcomronToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modbustcpclientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(20, 35);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(528, 577);
            this.treeView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "系统的树节点信息：（右键进行操作）";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HslSharpValueName,
            this.HslSharpValue});
            this.dataGridView1.Location = new System.Drawing.Point(554, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(454, 576);
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
            this.HslSharpValue.Width = 180;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增类别ToolStripMenuItem,
            this.编辑类别editClassToolStripMenuItem,
            this.删除deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 70);
            // 
            // 新增类别ToolStripMenuItem
            // 
            this.新增类别ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.类别classToolStripMenuItem,
            this.西门子PlcsiemensToolStripMenuItem,
            this.三菱plcmelsecToolStripMenuItem,
            this.欧姆龙plcomronToolStripMenuItem,
            this.modbustcpclientToolStripMenuItem});
            this.新增类别ToolStripMenuItem.Name = "新增类别ToolStripMenuItem";
            this.新增类别ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.新增类别ToolStripMenuItem.Text = "新增(add new)";
            // 
            // 编辑类别editClassToolStripMenuItem
            // 
            this.编辑类别editClassToolStripMenuItem.Name = "编辑类别editClassToolStripMenuItem";
            this.编辑类别editClassToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.编辑类别editClassToolStripMenuItem.Text = "编辑(edit)";
            // 
            // 类别classToolStripMenuItem
            // 
            this.类别classToolStripMenuItem.Name = "类别classToolStripMenuItem";
            this.类别classToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.类别classToolStripMenuItem.Text = "类别(class)";
            // 
            // 西门子PlcsiemensToolStripMenuItem
            // 
            this.西门子PlcsiemensToolStripMenuItem.Name = "西门子PlcsiemensToolStripMenuItem";
            this.西门子PlcsiemensToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.西门子PlcsiemensToolStripMenuItem.Text = "西门子Plc(siemens)";
            // 
            // 三菱plcmelsecToolStripMenuItem
            // 
            this.三菱plcmelsecToolStripMenuItem.Name = "三菱plcmelsecToolStripMenuItem";
            this.三菱plcmelsecToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.三菱plcmelsecToolStripMenuItem.Text = "三菱plc(melsec)";
            // 
            // 欧姆龙plcomronToolStripMenuItem
            // 
            this.欧姆龙plcomronToolStripMenuItem.Name = "欧姆龙plcomronToolStripMenuItem";
            this.欧姆龙plcomronToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.欧姆龙plcomronToolStripMenuItem.Text = "欧姆龙plc(omron)";
            // 
            // modbustcpclientToolStripMenuItem
            // 
            this.modbustcpclientToolStripMenuItem.Name = "modbustcpclientToolStripMenuItem";
            this.modbustcpclientToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.modbustcpclientToolStripMenuItem.Text = "Modbus-tcp-client";
            // 
            // 删除deleteToolStripMenuItem
            // 
            this.删除deleteToolStripMenuItem.Name = "删除deleteToolStripMenuItem";
            this.删除deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.删除deleteToolStripMenuItem.Text = "删除(delete)";
            // 
            // FormNodeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 635);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormNodeSetting";
            this.Text = "FormNodeSetting";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HslSharpValueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HslSharpValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 类别classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 西门子PlcsiemensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三菱plcmelsecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 欧姆龙plcomronToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modbustcpclientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑类别editClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除deleteToolStripMenuItem;
    }
}