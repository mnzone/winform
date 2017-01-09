using IBLL;
using IPlugin;
using MemberCard.Common;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Tools;

namespace MemberCard
{
    public partial class FrmInit : Form, IForm
    {
        private Boolean isSyn = false;
        private ISaleLogBLL bll = null;

        public FrmInit()
        {
            InitializeComponent();
        }

        public string GetProcessText()
        {
            return "";
        }

        public bool IsNext()
        {
            return false;
        }

        public void Start()
        {
            this.Show();
        }

        public void Stop()
        {
            Application.Exit();
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            synData();
        }

        private void synData()
        {

            if (isSyn)
            {
                return;
            }

            isSyn = true;

            if (bll == null)
            {
                bll = BLLLoader.GetSaleLogBll();
            }

            IniFile ini = new IniFile(Application.StartupPath + "/" + "syn.ini");
            String last_id = ini.IniReadValue("data", "LastID");
            int lastId = String.IsNullOrEmpty(last_id) ? 0 : Convert.ToInt32(last_id);

            //生成文件名
            DateTime now = DateTime.Now;
            String fileName = String.Format("{0}/runtime/logs/{1}/{2}/{3}.log", Application.StartupPath, now.Year, now.Month, now.Day);

            //获取数据
            List<SaleLog> logs = bll.GetSaleLogsByLastId(lastId);

            FileTools.Writer(fileName, String.Format("[{0}]本次共加载数据 {1} 条", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), logs.Count));
            for (int i = 0; i < logs.Count; i++)
            {
                
                switch (logs[i].GoodsId)
                {
                    case 0:
                        logs[i].GoodsId = 24;
                        break;
                    case -1:
                        logs[i].GoodsId = 18;
                        break;
                    case -2:
                        logs[i].GoodsId = 19;
                        break;
                    case -3:
                        switch (Convert.ToInt32(logs[i].Remark))
                        {
                            case 6:
                                logs[i].GoodsId = 21;
                                break;
                            case 7:
                                logs[i].GoodsId = 22;
                                break;
                            case 8:
                                logs[i].GoodsId = 23;
                                break;
                        }

                        break;
                }
            }

            if (logs.Count < 1)
            {
                return;
            }

            //添加至Mysql
            String result = "失败";
            if (bll.AddLog(logs))
            {
                ini.IniWriteValue("data", "LastID", logs[logs.Count - 1].Id.ToString());
                result = "成功";
            }
            //FileTools.Writer(fileName, String.Format("[{0}]同步ID为 {1} 的数据结果为：{2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), log.Id, result));
            isSyn = false;
        }

        private void timerSyn_Tick(object sender, EventArgs e)
        {
            synData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInit_Load(object sender, EventArgs e)
        {

        }

        private void InsertNewRow(String cardNo, int categoryId, long created_at)
        {
            String sql = "INSERT INTO members_cards(card_no, category_id, created_at) VALUES";
            sql += String.Format("('{0}', {1}, {2})", cardNo, categoryId, created_at);
        }

        private void loadOldRow()
        {
            String sql = "SELECT no, category_id, created_at FROM members";
        }
    }
}
