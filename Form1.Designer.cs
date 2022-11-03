
namespace WinIpBan
{
    partial class IpBan
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IpBan));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remotePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.封禁此ipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加此ip至白名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除此ipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxWirteList = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxElapsedSeconds = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxLimit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxIntervalSeconds = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPorts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxActiveTimeout = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmData.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.cmNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.localPort,
            this.remotePort,
            this.totalCount,
            this.address,
            this.elapsedTime});
            this.dataGridView1.ContextMenuStrip = this.cmData;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(746, 417);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // ip
            // 
            this.ip.DataPropertyName = "ip";
            this.ip.HeaderText = "ip";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Width = 130;
            // 
            // localPort
            // 
            this.localPort.DataPropertyName = "localPort";
            this.localPort.HeaderText = "本地端口";
            this.localPort.Name = "localPort";
            this.localPort.ReadOnly = true;
            this.localPort.Width = 80;
            // 
            // remotePort
            // 
            this.remotePort.DataPropertyName = "remotePort";
            this.remotePort.HeaderText = "远程端口";
            this.remotePort.Name = "remotePort";
            this.remotePort.ReadOnly = true;
            this.remotePort.Width = 80;
            // 
            // totalCount
            // 
            this.totalCount.DataPropertyName = "totalCount";
            this.totalCount.HeaderText = "请求次数";
            this.totalCount.Name = "totalCount";
            this.totalCount.ReadOnly = true;
            this.totalCount.Width = 80;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "地址";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 200;
            // 
            // elapsedTime
            // 
            this.elapsedTime.DataPropertyName = "elapsedTimeStr";
            this.elapsedTime.HeaderText = "封禁过期时间";
            this.elapsedTime.Name = "elapsedTime";
            this.elapsedTime.ReadOnly = true;
            this.elapsedTime.Width = 150;
            // 
            // cmData
            // 
            this.cmData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.封禁此ipToolStripMenuItem,
            this.添加此ip至白名单ToolStripMenuItem,
            this.移除此ipToolStripMenuItem,
            this.复制ipToolStripMenuItem});
            this.cmData.Name = "cmData";
            this.cmData.Size = new System.Drawing.Size(172, 92);
            // 
            // 封禁此ipToolStripMenuItem
            // 
            this.封禁此ipToolStripMenuItem.Name = "封禁此ipToolStripMenuItem";
            this.封禁此ipToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.封禁此ipToolStripMenuItem.Text = "封禁此ip";
            this.封禁此ipToolStripMenuItem.Click += new System.EventHandler(this.封禁此ipToolStripMenuItem_Click);
            // 
            // 添加此ip至白名单ToolStripMenuItem
            // 
            this.添加此ip至白名单ToolStripMenuItem.Name = "添加此ip至白名单ToolStripMenuItem";
            this.添加此ip至白名单ToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.添加此ip至白名单ToolStripMenuItem.Text = "添加此ip至白名单";
            this.添加此ip至白名单ToolStripMenuItem.Click += new System.EventHandler(this.添加此ip至白名单ToolStripMenuItem_Click);
            // 
            // 移除此ipToolStripMenuItem
            // 
            this.移除此ipToolStripMenuItem.Name = "移除此ipToolStripMenuItem";
            this.移除此ipToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.移除此ipToolStripMenuItem.Text = "移除此ip";
            this.移除此ipToolStripMenuItem.Click += new System.EventHandler(this.移除此ipToolStripMenuItem_Click);
            // 
            // 复制ipToolStripMenuItem
            // 
            this.复制ipToolStripMenuItem.Name = "复制ipToolStripMenuItem";
            this.复制ipToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.复制ipToolStripMenuItem.Text = "复制ip";
            this.复制ipToolStripMenuItem.Click += new System.EventHandler(this.复制ipToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 449);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbxActiveTimeout);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbxWirteList);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbxElapsedSeconds);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbxLimit);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbxIntervalSeconds);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tbxPorts);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(77, 191);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "自动开启防火墙";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(650, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(75, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "多个IP请使用英文逗号 , 隔开";
            // 
            // tbxWirteList
            // 
            this.tbxWirteList.Location = new System.Drawing.Point(77, 109);
            this.tbxWirteList.Name = "tbxWirteList";
            this.tbxWirteList.Size = new System.Drawing.Size(648, 21);
            this.tbxWirteList.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "ip白名单";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "秒后解除封禁";
            // 
            // tbxElapsedSeconds
            // 
            this.tbxElapsedSeconds.Location = new System.Drawing.Point(77, 82);
            this.tbxElapsedSeconds.Name = "tbxElapsedSeconds";
            this.tbxElapsedSeconds.Size = new System.Drawing.Size(41, 21);
            this.tbxElapsedSeconds.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "在";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "后封禁";
            // 
            // tbxLimit
            // 
            this.tbxLimit.Location = new System.Drawing.Point(207, 55);
            this.tbxLimit.Name = "tbxLimit";
            this.tbxLimit.Size = new System.Drawing.Size(41, 21);
            this.tbxLimit.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "秒内尝试连接";
            // 
            // tbxIntervalSeconds
            // 
            this.tbxIntervalSeconds.Location = new System.Drawing.Point(77, 55);
            this.tbxIntervalSeconds.Name = "tbxIntervalSeconds";
            this.tbxIntervalSeconds.Size = new System.Drawing.Size(41, 21);
            this.tbxIntervalSeconds.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "在";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(75, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "多个端口请使用英文逗号 , 隔开";
            // 
            // tbxPorts
            // 
            this.tbxPorts.Location = new System.Drawing.Point(77, 6);
            this.tbxPorts.Name = "tbxPorts";
            this.tbxPorts.Size = new System.Drawing.Size(648, 21);
            this.tbxPorts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "受保护端口";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "日志";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(746, 417);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IpBan";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // cmNotify
            // 
            this.cmNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出程序ToolStripMenuItem});
            this.cmNotify.Name = "cmNotify";
            this.cmNotify.Size = new System.Drawing.Size(125, 26);
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "自动移除";
            // 
            // tbxActiveTimeout
            // 
            this.tbxActiveTimeout.Location = new System.Drawing.Point(77, 155);
            this.tbxActiveTimeout.Name = "tbxActiveTimeout";
            this.tbxActiveTimeout.Size = new System.Drawing.Size(41, 21);
            this.tbxActiveTimeout.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "秒内不活动的IP";
            // 
            // IpBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 449);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IpBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IpBan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IpBan_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmData.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.cmNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn remotePort;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn elapsedTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxWirteList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxElapsedSeconds;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxIntervalSeconds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmNotify;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip cmData;
        private System.Windows.Forms.ToolStripMenuItem 封禁此ipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加此ip至白名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除此ipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ipToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxActiveTimeout;
        private System.Windows.Forms.Label label10;
    }
}

