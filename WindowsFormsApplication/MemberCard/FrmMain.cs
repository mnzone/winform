using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using IBLL;
using IPlugin;
using MemberCard.Card;
using MemberCard.Common;
using MemberCard.Trade;
using Models;
using Tools;
using GoodsManager.Trade;

namespace MemberCard
{
    public partial class FrmMain : Form, IForm
    {
        private SoundPlayer player = null;
        private String cardNo = null;
        private Models.MemberCard card = null;
        private ISaleLogBLL logBll = null;
        private IMemberCardBLL cardBll = null;
        private IMemberCardRecordBLL recordBll = null;
        private IMemberCardCategoryBLL catBll = null;

        private int pageSize = 10;
        private int pageIndex = 0;
        private List<Goods> goodses = null;

        public FrmMain()
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

        private void tsBtnMemberCard_Click(object sender, System.EventArgs e)
        {
            FrmManager frmCardManager = new FrmManager();
            frmCardManager.ShowDialog();
        }

        private void tsBtnRecharge_Click(object sender, System.EventArgs e)
        {
            FrmRecharge frmRecharge = new FrmRecharge();
            frmRecharge.ShowDialog();
        }

        private void tsBtnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tsBtnUpdate_Click(object sender, System.EventArgs e)
        {
            Type type = ReflectionTools.GetTypeObject(Application.StartupPath, "Update", "Update.FrmCheckUpdate");
            if (type == null)
                throw new MissingMethodException("Update module not found!");

            ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
            if (constructor == null)
                throw new MissingMethodException("No public constructor defined for this object");

            IForm frmUpdateForm = constructor.Invoke(null) as IForm;
            frmUpdateForm.Start();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            initBll();
            initUI();
            loadGoods();
        }

        private void FrmView_SizeChanged(object sender, EventArgs e)
        {
            changeLoction();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.btnSearch.Enabled = false;
            this.txtKeyword.Enabled = false;

            this.cardNo = this.txtKeyword.Text.Trim();
            this.txtKeyword.Clear();

            this.FindMemberCard(this.cardNo);

            this.btnSearch.Enabled = true;
            this.txtKeyword.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.btnSearch_Click(this.btnSearch, null);
            }
        }

        private void btnGoods_Click(object sender, EventArgs e)
        {
            FrmSale sale = new FrmSale();
            sale.Callback = AddRecordToDataGridView;
            sale.Goods = (sender as Button).Tag as Goods;
            sale.ShowDialog();
            //FrmSale sale = new FrmSale(this, (sender as Button).Text, ((sender as Button).Tag as Models.Goods).Id);
            //sale.ShowDialog();
        }

        private void initBll()
        {
            catBll = BLLLoader.GetMemberCardCategoryBll();
            cardBll = BLLLoader.GetMemberCardBll();
            recordBll = BLLLoader.GetMemberCardRecordBll();
            logBll = BLLLoader.GetSaleLogBll();
        }

        private void initUI()
        {
            this.setLabelStatus("准备就绪", Color.Black);
            this.labType.Text = "已就绪";
            this.labStatus.Text = "已就绪";
            this.labExpire.Text = "已就绪";
            this.labCreatedAt.Text = "已就绪";
            this.labBalance.Text = "已就绪";
            this.labNo.Text = "已就绪";
            this.numValue.Enabled = false;
            this.btnSubmit.Enabled = false;

            this.cmbTerm.SelectedIndex = 0;
        }

        private void fullCardInfo()
        {
            if (this.card == null)
            {
                return;
            }

            this.labType.Text = this.card.Category.Name;
            this.labExpire.Text = this.card.Record == null ? "未激活" : TimeStamp.ConvertIntDateTime(this.card.Record.ExpiredAt).ToString("yyyy-MM-dd");
            this.labCreatedAt.Text = this.card.Record == null ? "未激活" : TimeStamp.ConvertIntDateTime(this.card.Record.BeginAt).ToString("yyyy-MM-dd");
            this.labBalance.Text = this.card.Record == null ? "未激活" : String.Format("{0}次", Convert.ToInt32(this.card.Record.Balance));
            this.labNo.Text = this.card.CardNo;
        }

        private void setLabelStatus(String msg, Color fontColor, String audioKey = null)
        {
            this.labStatus.Text = msg;
            this.labStatus.ForeColor = fontColor;
            this.labStatus.Left = (this.panelStatus.Width - this.labStatus.Width) / 2;

            if (String.IsNullOrEmpty(audioKey))
            {
                return;
            }

            try
            {
                player = new SoundPlayer();
                String audioSrc = ConfigurationManager.AppSettings[audioKey];
                player.FileName = audioSrc;
                player.play();
            }
            catch (ConfigurationErrorsException e)
            {
            }
            
            
        }

        private void changeLoction()
        {
            /*this.labCardNo.Left = (this.panel1.Width - this.labCardNo.Width) / 2;
            this.labCardNo.Top = (this.panel1.Height - this.labCardNo.Height) / 2;

            this.labCategory.Left = this.labCardNo.Left;
            this.labCategory.Top = this.labCardNo.Top;
            this.labCardNum.Left = this.labCardNo.Left;
            this.labCardNum.Top = this.labCardNo.Top;
            this.labExpire.Left = this.labCardNo.Left;
            this.labExpire.Top = this.labCardNo.Top;

            this.labStatus.Left = (this.panel1.Width - this.labStatus.Width) / 2;
            this.labStatus.Top = this.labCardNo.Top;*/
        }

        /// <summary>
        /// 查找会员卡信息
        /// </summary>
        /// <param name="no"></param>
        private void FindMemberCard(String no)
        {
            this.initUI();

            String audioKey = null;
            String msg = "";

            
            this.card = cardBll.GetMemberCardByNo(no);
            if (this.card != null)
            {
                this.card.Category = catBll.GetMemberCardCategoryById(this.card.CategoryId);
                this.card.Record = recordBll.GetMemberCardRecordByMemberCardId(this.card.Id);
                this.fullCardInfo();
            }
            

            //判断会员卡是否存在
            if (card == null)
            {
                msg = "此卡不存在!";
                audioKey = "AudioCardNotFound";
            }
            else if (card.Record == null)
            {
                msg = "此卡未开启!";
                audioKey = "AudioCardNotAvailable";
            }
            else if (card.Record.Balance <= 0)
            {
                msg = "此卡次数不足，请充值后再试!";
                audioKey = "AudioCardArrearage";
            }
            else if (card.Record.ExpiredAt < TimeStamp.GetNowTimeStamp())
            {
                msg = "此卡已过期!";
                audioKey = "AudioCardExpired";
            }
            else if ( ! card.Category.isDateAllow() || ! card.Category.isTimeAllow())
            {
                msg = "此卡不在可用时间段!";
                audioKey = "AudioCardTimeInvalid";
            }

            if (! String.IsNullOrEmpty(msg))
            {
                this.setLabelStatus(msg, Color.Red, audioKey);
                return;
            }
            
            this.setLabelStatus("此卡可以使用", Color.Green);
            this.numValue.Enabled = true;
            this.btnSubmit.Enabled = true;
            this.numValue.Maximum = card.Record.Balance;

            if (!this.ckbAuto.Checked)
            {
                return;
            }

            this.AddRecord();
        }

        /// <summary>
        /// 添加交易记录
        /// </summary>
        private void AddRecord()
        {
            if (card.Record.Balance <= 0)
            {
                this.setLabelStatus("此卡次数不足，请充值后再试!", Color.Red, "AudioCardArrearage");
                return;
            }

            this.btnSearch.Enabled = false;
            this.btnSubmit.Enabled = false;
            this.numValue.Enabled = false;

            Decimal num = this.numValue.Value;
            for (int i = 0; i < num; i++)
            {
                SaleLog log = new SaleLog();
                log.CreatedAt = TimeStamp.GetNowTimeStamp();
                log.Money = 0;
                log.GoodsId = Convert.ToInt32(ConfigurationManager.AppSettings["RecordGoodsID"]);
                log.MemberNo = this.card.CardNo;
                log.Summary = String.Format("卡号：{0}({1})在{2}进行了一笔消费", this.labNo.Text.Trim(), this.labType.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                logBll.AddLog(log);
            }

            this.AddRecordToDataGridView(String.Format("卡号：{0}({1})在{2}进行了{3}笔消费", this.labNo.Text.Trim(), this.labType.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToInt32(num)));
            this.card.Record.Balance -= num;
            recordBll.EditMemberCardRecord(this.card.Record);

            this.btnSearch.Enabled = true;
            this.btnSubmit.Enabled = true;
            this.numValue.Enabled = true;
            this.numValue.Maximum = this.card.Record.Balance;
            this.numValue.Value = this.numValue.Value > this.numValue.Maximum ? this.numValue.Maximum : this.numValue.Value;
        }

        private void AddRecordToDataGridView(String text)
        {
            this.dgvSalesLog.Rows.Insert(0, new String[]
            {
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                text
            });
        }

        private void loadGoods()
        {
            IGoodsBLL gbll = BLLLoader.GetGoodsBll();
            goodses = gbll.GetSaleGoods();
            reloadGoods(0);
        }

        private void reloadGoods(int start)
        {
            if (goodses == null || goodses.Count < 1)
            {
                return;
            }

            this.panelGoods.Controls.Clear();

            List<Goods> items = new List<Goods>();
            int endIndex = (pageIndex + 1) * pageSize;
            for (int i = start; i < (endIndex < goodses.Count ? endIndex : goodses.Count); i++)
            {
                items.Add(goodses[i]);
            }

            items.Reverse();
            foreach(Goods item in items)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Text = item.Name;
                btn.Height = 45;
                btn.Tag = item;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Click += new EventHandler(btnGoods_Click);
                btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                
                this.panelGoods.Controls.Add(btn);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(this.goodses.Count / pageSize);

            if (pageIndex >= size)
            {
                MessageBox.Show("已经是最后一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pageIndex++;
            reloadGoods(pageIndex * pageSize);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageIndex <= 0)
            {
                MessageBox.Show("已经是第一页了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pageIndex--;
            reloadGoods(pageIndex * pageSize);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.txtKeyword.Focus();
        }
    }
}
