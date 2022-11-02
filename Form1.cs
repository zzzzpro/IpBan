using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinIpBan
{
    public partial class IpBan : Form
    {
        public IpBan()
        {
            InitializeComponent();
            SeedMessage();
        }
        private void SeedMessage()
        {
            Helper.SeedMessage = (i) =>
            {
                this.Invoke(new SeedMessage((message) =>
                {
                    this.textBox1.Text += message + Environment.NewLine;
                    this.textBox1.ScrollToCaret();
                }), i);
            };

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Bind();
            this.dataGridView1.DataSource = new BindingList<Model>(Helper.Models);
          
        }

        private void Bind()
        {
            tbxElapsedSeconds.Text = Helper.config.elapsedSeconds.ToString();
            tbxIntervalSeconds.Text = Helper.config.intervalSeconds.ToString();
            tbxPorts.Text=Helper.config.ports;
            tbxLimit.Text= Helper.config.limit.ToString();
            tbxWirteList.Text=Helper.config.whiteList;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if(!Helper.Models.Any()) return;
            int iScrollIndex = dataGridView1.FirstDisplayedScrollingRowIndex;

            this.dataGridView1.DataSource = new BindingList<Model>(Helper.Models);
            dataGridView1.ClearSelection();
            if (selectIndex < this.dataGridView1.Rows.Count)
            {
               
            }
            else
            {
                selectIndex = 0;
            }
            dataGridView1.Rows[selectIndex].Selected = true;
            if (iScrollIndex >= 0 && iScrollIndex < dataGridView1.RowCount)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = iScrollIndex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(tbxIntervalSeconds.Text) != Helper.config.intervalSeconds|| int.Parse(tbxLimit.Text)!= Helper.config.limit)
            {
                for (int i = 0; i < Helper.Models.Count; i++)
                {
                    Helper.Models[i].Limits = new Limits(int.Parse(tbxLimit.Text), int.Parse(tbxIntervalSeconds.Text));
                }
            }
            Helper.config.intervalSeconds = int.Parse(tbxIntervalSeconds.Text);
            Helper.config.limit = int.Parse(tbxLimit.Text);



            Helper.config.ports = tbxPorts.Text;

            Helper.config.elapsedSeconds = int.Parse(tbxElapsedSeconds.Text);
            if (Helper.config.whiteList != tbxWirteList.Text)
            {
                Helper.config.whiteList = tbxWirteList.Text;
                Helper.WriteWhiteList(Helper.config.whiteList);
            }
            
            //判断白名单
            if (checkBox1.Checked)
            {
                Helper.OpenFw();
            }
            Helper.WriteWhiteList(Helper.config.whiteList);
            Helper.WriteConfig();
            MessageBox.Show("保存成功");
        }

        private void IpBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //保存下信息
            File.WriteAllText("history",JsonConvert.SerializeObject(Helper.Models));
            Environment.Exit(0);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                this.Show();
                this.Activate();
            }
            
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    Helper.OpenPort(int.Parse(textBox2.Text));
        //    var isbool = true;
        //    MessageBox.Show(isbool ? "保存成功" : "保存失败");
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
               var result= MessageBox.Show("请确保必要端口放行,以免造成损失(默认已放行RDP端口),保存后生效", "自动开启防火墙", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
               if (result == DialogResult.OK)
               {

               }
               else
               {
                   this.checkBox1.Checked = false;
               }
            }
        }

        private void 封禁此ipToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var value = dataGridView1.Rows[selectIndex].Cells[0].Value.ToString();
            var model= Helper.Models.FirstOrDefault(n => n.ip == value);
            if (model.state == 1)
            {
                return;
            }
            model.state = 1;
            model.elapsedTime = DateTime.Now.AddSeconds(Helper.config.elapsedSeconds);
            Helper.BanAddress(new List<string>(){ value });
            BindData();
        }

        private void 添加此ip至白名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var value = dataGridView1.Rows[selectIndex].Cells[0].Value.ToString();
            var model = Helper.Models.FirstOrDefault(n => n.ip == value);
            
            
            var addresses = Helper.config.whiteList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (addresses.Contains(value))
            {
                return;
            }
            addresses.Add(value);
            tbxWirteList.Text = string.Join(",", addresses);
            Helper.config.whiteList = tbxWirteList.Text;
            Helper.WriteWhiteList(Helper.config.whiteList);
            if (model.state == 1)
            {
                model.state = 0;
                model.elapsedTime = null;
                BindData();
            }
        }

        private void 移除此ipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var value = dataGridView1.Rows[selectIndex].Cells[0].Value.ToString();
            lock (Helper.Models)
            {
                var model = Helper.Models.FirstOrDefault(n => n.ip == value);
                if(model==null) return;
                Helper.Models.Remove(model);
            }

            BindData();
        }

        private void 复制ipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var value = dataGridView1.Rows[selectIndex].Cells[0].Value.ToString();
            Clipboard.SetText(value);
        }

        private int selectIndex = 0;
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                selectIndex = e.RowIndex;
            }
        }
    }
}
