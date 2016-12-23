using IPlugin;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Update
{
    public partial class FrmCheckUpdate : Form, IForm
    {
        private delegate void ChangeTipText(String text);
        
        private bool connectFlag = false;
        private int count = 1;
        private Boolean isOver;
        private CheckSoft check;

        public FrmCheckUpdate()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void FrmCheckUpdate_Load(object sender, EventArgs e)
        {
            Thread checkThread = new Thread(begin);
            checkThread.Start();

        }

        private void begin()
        {
            this.setLabel("请稍等...");

            this.check = new CheckSoft();
            this.check.Callback = this.updatingCallback;
            this.check.CheckUpdate(1);
        }

        private void updatingCallback(String msg, int status)
        {
            this.setLabel(msg);

            if (status == -1)
            {
                return;
            }

            if (status > 0)
            {
                this.Hide();
                MessageBox.Show("软件已经是最新版本!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (status == 0)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 设置显示状态信息
        /// </summary>
        /// <param name="text">状态信息</param>
        private void setLabel(String text) {
            this.labStatus.Text = text;
            this.labStatus.Left = (this.Width - this.labStatus.Width) / 2;
        }

        public void Start()
        {
            this.Show();
        }

        public void Stop()
        {
            Application.Exit();
        }

        public Boolean IsNext()
        {
            return isOver;
        }

        public String GetProcessText()
        {
            return this.labStatus.Text.Trim();
        }
    }
}
