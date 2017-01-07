using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Tools;
using System.Configuration;
using System.Data.SQLite;

namespace DataSynchronization
{
    public partial class FrmMain : Form
    {
        private bool syn = false;
        private String masterConnString = null;

        private int seconds = 0;
        private bool autoRun = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.UpdateConfig("AutoRun", this.ckbSynStatus.Checked.ToString());
            this.UpdateConfig("Seconds", this.numSeconds.Value.ToString());
            this.UpdateConfig("server", this.txtServer.Text.Trim());
            this.UpdateConfig("db_username", this.txtUserName.Text.Trim());
            this.UpdateConfig("db_password", this.txtPassword.Text.Trim());
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.Visible = true;
                this.Hide();
                this.Visible = false;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.notifyIcon.Icon = new Icon(@"F:\vs\WindowsFormsApplication\WindowsFormsApplication\Loader\Assets\Icon\success.ico");
            masterConnString = ConfigurationManager.ConnectionStrings["SQLiteMasterConnString"].ConnectionString;

            Config cfg = GetConfig("AutoRun");
            this.autoRun = Convert.ToBoolean(cfg == null ? "false" : cfg.Value);
            this.ckbSynStatus.Checked = this.autoRun;
            cfg = GetConfig("Seconds");
            this.seconds = Convert.ToInt32(cfg == null ? "10" : cfg.Value);
            this.numSeconds.Value = this.seconds;
            cfg = GetConfig("server");
            this.txtServer.Text = cfg.Value;
            cfg = GetConfig("db_username");
            this.txtUserName.Text = cfg.Value;
            cfg = GetConfig("db_password");
            this.txtPassword.Text = cfg.Value;

            if (this.autoRun)
            {
                this.tsmiStartOrStop.Text = "停止数据同步";
                this.timerSynCheck.Interval = seconds * 1000;
                this.timerSynCheck.Start();
            }
            else
            {
                this.tsmiStartOrStop.Text = "启动数据同步";
            }

            this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    this.menuContext.Show();
                    break;
                case MouseButtons.Left:
                    this.tsmiConfigEdit_Click(this.tsmiConfigEdit, null);
                    break;
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiConfigEdit_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void tsmiStartOrStop_Click(object sender, EventArgs e)
        {
            
            if (this.tsmiStartOrStop.Text.Trim() == "启动数据同步")
            {
                this.timerSynCheck.Interval = seconds * 1000;
                this.timerSynCheck.Start();
            }
            else
            {
                this.timerSynCheck.Stop();
            }

            this.tsmiStartOrStop.Text = this.tsmiStartOrStop.Text.Trim() == "启动数据同步" ? "停止数据同步" : "启动数据同步";
        }

        private void timerSynCheck_Tick(object sender, EventArgs e)
        {
            //开始执行同步操作
            if (syn)
            {
                return;
            }

            syn = true;
            synToServer();
            //向本地同步
            synToClient();
            syn = false;
        }

        private void synToServer()
        {
            //向服务器同步
            List<SynModel> items = this.getUploadCommands("SELECT * FROM queues");
            if (items == null)
            {
                return;
            }

            foreach (SynModel model in items)
            {
                int row = Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                    model.Command);
                if (row > 0)
                {
                    SQLiteHelper.ExecuteNonQuery(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text,
                    String.Format("DELETE FROM queues WHERE id = {0}", model.Id));
                    refresh();
                }
            }
        }

        private void synToClient()
        {
            List<SynModel> items = this.getDownloadCommands("SELECT * FROM queues");
            if (items == null)
            {
                return;
            }

            foreach (SynModel model in items)
            {
                int row = SQLiteHelper.ExecuteNonQuery(masterConnString, CommandType.Text,
                    model.Command);
                Console.WriteLine(String.Format("本地执行：{0}；结果为：{1}", model.Command, row));
                if (row > 0)
                {
                    Console.WriteLine("MySQL执行：" + String.Format("DELETE FROM queues WHERE id = {0}", model.Id));
                    Tools.MySqlHelper.ExecuteNonQuery(Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                    String.Format("DELETE FROM queues WHERE id = {0}", model.Id));
                    refresh();
                }
            }
        }

        private void refresh()
        {
            this.notifyIcon.Icon = new Icon(@"F:\vs\WindowsFormsApplication\WindowsFormsApplication\Loader\Assets\Icon\upload.ico");
            Thread.Sleep(500);
            this.notifyIcon.Icon = new Icon(@"F:\vs\WindowsFormsApplication\WindowsFormsApplication\Loader\Assets\Icon\download.ico");
            Thread.Sleep(500);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }

            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon.Visible = false;
        }

        public List<SynModel> getUploadCommands(String sql)
        {
            List<SynModel> list = null;
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (rdr.Read())
                {
                    if (list == null)
                    {
                        list = new List<SynModel>();
                    }
                    SynModel item = new SynModel();
                    item.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                    item.Command = rdr["command"] == DBNull.Value ? "" : rdr["command"].ToString();
                    list.Add(item);
                }
            }

            return list;
        }

        public List<SynModel> getDownloadCommands(String sql)
        {
            List<SynModel> items = new List<SynModel>();
            using (
                MySqlDataReader rdr = Tools.MySqlHelper.ExecuteReader(
                    Tools.MySqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                while (rdr.Read())
                {
                    if (items == null)
                    {
                        items = new List<SynModel>();
                    }
                    SynModel item = new SynModel();
                    item.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                    item.Command = rdr["command"] == DBNull.Value ? "" : rdr["command"].ToString();
                    items.Add(item);
                }
            }
            return items;
        }

        private Config GetConfig(String key)
        {
            Config config = null;
            String sql = String.Format("SELECT * FROM configs WHERE keyword = '{0}'", key);
            using (
                SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(
                    SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql))
            {
                if (rdr.Read())
                {
                    config = new Config();
                    config.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"]);
                    config.Key = rdr["keyword"] == DBNull.Value ? "" : rdr["keyword"].ToString();
                    config.Value = rdr["value"] == DBNull.Value ? "" : rdr["value"].ToString();
                }
            }
            return config;
        }

        private bool UpdateConfig(String key, String value)
        {
            String sql = String.Format("UPDATE configs SET value = '{0}' WHERE keyword = '{1}'",  value, key);
            int row = SQLiteHelper.ExecuteNonQuery(SQLiteHelper.ConnectionStringLocalTransaction, CommandType.Text, sql);
            return row > 0;
        }

    }

    internal class Config
    {
        private int id;
        private String key;
        private String value;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
