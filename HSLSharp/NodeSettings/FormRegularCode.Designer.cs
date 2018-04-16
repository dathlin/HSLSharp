namespace HSLSharp.NodeSettings
{
    partial class FormRegularCode
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Regulars");
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增RequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑RequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除RequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑解析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除解析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增RequestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new HSLSharp.Controls.TreeViewEx();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "系统的配置信息：（右键进行操作）";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(645, 562);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增RequestToolStripMenuItem,
            this.编辑RequestToolStripMenuItem,
            this.删除RequestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 70);
            // 
            // 新增RequestToolStripMenuItem
            // 
            this.新增RequestToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.新增RequestToolStripMenuItem.Name = "新增RequestToolStripMenuItem";
            this.新增RequestToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.新增RequestToolStripMenuItem.Text = "新增解析";
            this.新增RequestToolStripMenuItem.Click += new System.EventHandler(this.新增RequestToolStripMenuItem_Click);
            // 
            // 编辑RequestToolStripMenuItem
            // 
            this.编辑RequestToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.PencilAngled_16xLG_color;
            this.编辑RequestToolStripMenuItem.Name = "编辑RequestToolStripMenuItem";
            this.编辑RequestToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.编辑RequestToolStripMenuItem.Text = "编辑Request";
            this.编辑RequestToolStripMenuItem.Click += new System.EventHandler(this.编辑RequestToolStripMenuItem_Click);
            // 
            // 删除RequestToolStripMenuItem
            // 
            this.删除RequestToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_Cancel_16xLG;
            this.删除RequestToolStripMenuItem.Name = "删除RequestToolStripMenuItem";
            this.删除RequestToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.删除RequestToolStripMenuItem.Text = "删除Request";
            this.删除RequestToolStripMenuItem.Click += new System.EventHandler(this.删除RequestToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑解析ToolStripMenuItem,
            this.删除解析ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 48);
            // 
            // 编辑解析ToolStripMenuItem
            // 
            this.编辑解析ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.PencilAngled_16xLG_color;
            this.编辑解析ToolStripMenuItem.Name = "编辑解析ToolStripMenuItem";
            this.编辑解析ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑解析ToolStripMenuItem.Text = "编辑解析";
            this.编辑解析ToolStripMenuItem.Click += new System.EventHandler(this.编辑解析ToolStripMenuItem_Click);
            // 
            // 删除解析ToolStripMenuItem
            // 
            this.删除解析ToolStripMenuItem.Image = global::HSLSharp.Properties.Resources.action_Cancel_16xLG;
            this.删除解析ToolStripMenuItem.Name = "删除解析ToolStripMenuItem";
            this.删除解析ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除解析ToolStripMenuItem.Text = "删除解析";
            this.删除解析ToolStripMenuItem.Click += new System.EventHandler(this.删除RequestToolStripMenuItem_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增RequestToolStripMenuItem1});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(148, 26);
            // 
            // 新增RequestToolStripMenuItem1
            // 
            this.新增RequestToolStripMenuItem1.Image = global::HSLSharp.Properties.Resources.action_add_16xLG;
            this.新增RequestToolStripMenuItem1.Name = "新增RequestToolStripMenuItem1";
            this.新增RequestToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.新增RequestToolStripMenuItem1.Text = "新增Request";
            this.新增RequestToolStripMenuItem1.Click += new System.EventHandler(this.新增RequestToolStripMenuItem1_Click);
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
            this.menuStrip1.TabIndex = 8;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(343, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 566);
            this.panel1.TabIndex = 9;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(15, 57);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "node_regulars";
            treeNode1.Text = "Regulars";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(322, 566);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // FormRegularCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1020, 635);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormRegularCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "解析规则器配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRegularCode_FormClosing);
            this.Load += new System.EventHandler(this.FormRegularCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.TreeViewEx treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增RequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑RequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除RequestToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 编辑解析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除解析ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 新增RequestToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}