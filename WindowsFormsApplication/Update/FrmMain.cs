using IPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace Update
{
    public partial class FrmMain : Form, IForm
    {
        private Boolean isOver = false;
        private String text = "";

        public FrmMain()
        {
            InitializeComponent();
        }

        public void Start()
        {
            this.Show();
        }

        public void Stop()
        {
            Application.Exit();
        }

        public Boolean IsNext() {
            return isOver;
        }

        public String GetProcessText() {
            return text;
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.txtPath.Text.Trim())){
                MessageBox.Show("请选择需要压缩的文件路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String[] directories = this.txtPath.Text.Trim().Split('\\');
            String password = String.IsNullOrEmpty(this.txtPwd.Text.Trim()) ? Str.rand(10) : this.txtPwd.Text.Trim();
            String fileName = String.IsNullOrEmpty(directories[directories.Length - 1]) ? directories[directories.Length - 2] : directories[directories.Length - 1];
            this.txtPwd.Text = password;
            ZipHelper.ZipDirectory(this.txtPath.Text.Trim(), this.txtTarget.Text.Trim() + fileName + ".zip", password);
        }
    }
}
