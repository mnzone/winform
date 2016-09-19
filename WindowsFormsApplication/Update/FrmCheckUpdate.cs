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
using Update.Common;
using Update.Models;

namespace Update
{
    public partial class FrmCheckUpdate : Form, IForm
    {

        public delegate void UpdateCallback();

        private bool connectFlag = false;
        private int count = 1;
        private String text = "CheckUpdate的内容是";
        private Boolean isOver;
        public UpdateCallback LoaderDelegate;

        public FrmCheckUpdate()
        {
            InitializeComponent();
            this.timerUpdate.Enabled = true;
            this.setLabel("正在解压");
            //checkSoft();
        }

        public void Start() {
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
            return text;
        }

        private void FrmCheckUpdate_Load(object sender, EventArgs e)
        {
            
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            count++;
            if(count > 3){
                count = 1;
            }
            String dot = "";
            for (int i = 0; i < count; i ++ ) {
                dot += ".";
            }
            this.setLabel(this.text + dot);
        }

        private void setLabel(String text) {
            this.text = text;
            this.labStatus.Text = text;
            this.labStatus.Left = (this.Width - this.labStatus.Width) / 2;
        }
    }
}
