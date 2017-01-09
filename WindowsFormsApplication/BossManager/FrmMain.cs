using IBLL;
using IPlugin;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BossManager.Common;
using Models;
using Tools;

namespace BossManager
{
    public partial class FrmMain : Form, IForm
    {
        private bool connectionFlag = false;
        private int logId = 0;
        private ISaleLogBLL saleBll = null;
        private IReportBLL bll = null;
        private IGoodsCategoryBLL catBll = null;
        private DataGridViewRow lastRow = new DataGridViewRow();

        public FrmMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 填充年月
        /// </summary>
        private void loadData()
        {
            for (int year = 2014; year <= DateTime.Now.Year; year++)
            {
                this.cmbYear.Items.Add(year);
            }
            this.cmbYear.Text = DateTime.Now.Year.ToString();
            for (int month = 1; month < 13; month++)
            {
                String zero = month < 10 ? "0" : "";
                this.cmbMonth.Items.Add(zero + month);
            }
            this.cmbMonth.Text = DateTime.Now.Month.ToString();
        }

        private void loadMonthData(int year, int month)
        {

            List<Models.GoodsCategory> cats = this.cmbCategory.DataSource as List<Models.GoodsCategory>;

            if (this.dgvMonthDay.Columns.Count < 1)
            {
                //设置DataGridView列头
                dgvMonthDay.Columns.Add(new DataGridViewTextBoxColumn());
                dgvMonthDay.Columns[0].HeaderText = "日期";

                foreach (Models.GoodsCategory cat in cats)
                {
                    dgvMonthDay.Columns.Add(new DataGridViewTextBoxColumn());
                    dgvMonthDay.Columns[dgvMonthDay.Columns.Count - 1].HeaderText = cat.Name;
                }
                dgvMonthDay.Columns.Add(new DataGridViewTextBoxColumn());
                dgvMonthDay.Columns[dgvMonthDay.Columns.Count - 1].HeaderText = "合计";
            }

            //合计行
            lastRow = new DataGridViewRow();
            lastRow.Cells.Add(this.getDateGridViewCell("合计"));
            foreach (Models.GoodsCategory cat in cats)
            {
                lastRow.Cells.Add(this.getDateGridViewCell(0, cat.Id));
            }

            Decimal total = 0;
            this.dgvMonthDay.Rows.Clear();
            
            //填充数据
            List<ReportGoodsRank> dataSources = bll.GroupStatisticsByDay(year, month);
            int endDay = Convert.ToDateTime(Convert.ToDateTime(String.Format("{0}-{1}-01", year, month)).AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1).Day;
            for (int day = 1; day <= endDay; day++)
            {
                DataGridViewRow row = new DataGridViewRow();
                //添加月份
                row.Cells.Add(this.getDateGridViewCell(day.ToString() + "日"));

                decimal cellTotal = 0;
                foreach (GoodsCategory cat in cats)
                {
                    Boolean flag = false;
                    foreach (ReportGoodsRank item in dataSources)
                    {
                        if (item.Month == day
                            && cat.Name.Trim() == item.GoodsName.Trim())
                        {
                            flag = true;
                            cellTotal += item.Price;
                            row.Cells.Add(this.getDateGridViewCell(item.Price));
                            //统计某类商品年度销售总额
                            GetValue(cat, item);
                            break;
                        }
                    }

                    if (flag)
                    {
                        continue;
                    }

                    row.Cells.Add(this.getDateGridViewCell("0"));
                }

                total += cellTotal;
                //添加月份销售额小计
                row.Cells.Add(this.getDateGridViewCell(cellTotal));

                dgvMonthDay.Rows.Add(row);
            }
            lastRow.Cells.Add(this.getDateGridViewCell(total));
            dgvMonthDay.Rows.Add(lastRow);
        }

        /// <summary>
        /// 加载销售记录
        /// </summary>
        /// <param name="begin">起始时间</param>
        /// <param name="end">截止时间</param>
        private void loadSaleLogs(DateTime begin, DateTime end)
        {
            if (saleBll == null)
            {
                saleBll = BLLLoader.GetSaleLogBll();
            }

            List<SaleLog> result = saleBll.GetAllSaleLogsByDate(begin, end);

            this.dgvSalelogs.Rows.Clear();

            foreach (SaleLog log in result)
            {
                this.dgvSalelogs.Rows.Add(new String[]
                {
                    log.Id.ToString(),
                    TimeStamp.ConvertIntDateTime(log.CreatedAt).ToString(),
                    log.Summary,
                    log.Money.ToString()
                });
            }
            
        }

        /// <summary>
        /// 加载商品类目
        /// </summary>
        private void LoadCategories()
        {
            if (catBll == null)
            {
                catBll = BLLLoader.GetGoodsCategoryBll();
            }

            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.ValueMember = "Id";
            this.cmbCategory.DataSource = catBll.GetAllCategories();
        }

        /// <summary>
        /// 统计数据按年份分组
        /// </summary>
        private void LoadYears()
        {

            if (bll == null)
            {
                bll = BLLLoader.GetReportBll();
            }


            for (int year = 2014; year <= DateTime.Now.Year; year ++)
            {
                TabPage page = new TabPage(String.Format("{0}年", year));
                page.Controls.Add(initDataGridView(year, this.cmbCategory.DataSource as List<Models.GoodsCategory>));
                this.tabYears.TabPages.Add(page);
            }
        }

        /// <summary>
        /// 加载销售排行榜
        /// </summary>
        private void LoadGoodsRank()
        {
            this.dgvGoodsRank.Rows.Clear();
            bll = BLLLoader.GetReportBll();

            List<ReportGoodsRank> ranks = null;
            try
            {
                ranks = bll.SaleGoodsRankByAll();
            } catch (Exception e) {
                MessageBox.Show(e.Message, "数据库不可用", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ranks == null)
            {
                return;
            }

            foreach (ReportGoodsRank rank in ranks)
            {
                this.dgvGoodsRank.Rows.Add(new String[] {
                    rank.GoodsName,
                    rank.Price.ToString(),
                    rank.Count.ToString()
                });
            }
        }

        /// <summary>
        /// 初始化DataGridView控件
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="cats">商品分类信息</param>
        /// <returns></returns>
        private DataGridView initDataGridView(int year, List<Models.GoodsCategory> cats)
        {
            //设置DataGridView
            DataGridView dgv = new DataGridView();
            //设置DataGridView样式
            dgv.Dock = DockStyle.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true;
            dgv.RowHeadersVisible = false;
            //设置DataGridView列头
            dgv.Columns.Add(new DataGridViewTextBoxColumn());
            dgv.Columns[0].HeaderText = "月份";

            lastRow = new DataGridViewRow();
            lastRow.Cells.Add(this.getDateGridViewCell("合计"));
            foreach (Models.GoodsCategory cat in cats)
            {
                lastRow.Cells.Add(this.getDateGridViewCell(0, cat.Id));
                dgv.Columns.Add(new DataGridViewTextBoxColumn());
                dgv.Columns[dgv.Columns.Count - 1].HeaderText = cat.Name;
            }
            dgv.Columns.Add(new DataGridViewTextBoxColumn());
            dgv.Columns[dgv.Columns.Count - 1].HeaderText = "合计";
            //设置DataGridView数据
            AddData(dgv, year, cats);
            return dgv;
        }

        /// <summary>
        /// 填充DataGridView数据源
        /// </summary>
        /// <param name="dgv">DataGridView控件</param>
        /// <param name="year">年份</param>
        /// <param name="cats">商品分类列表</param>
        private void AddData(DataGridView dgv, int year, List<Models.GoodsCategory> cats)
        {
            Decimal total = 0;
            this.dgvGoodsRank.Rows.Clear();
            List<ReportGoodsRank> dataSources = bll.GroupStatisticsByYear(year);

            for (int month = 1; month < 13; month++)
            {
                DataGridViewRow row = new DataGridViewRow();
                //添加月份
                row.Cells.Add(this.getDateGridViewCell(month.ToString()));

                decimal cellTotal = 0;
                foreach (GoodsCategory cat in cats)
                {
                    Boolean flag = false;
                    foreach (ReportGoodsRank item in dataSources)
                    {
                        if (item.Id == year 
                            && item.Month == month
                            && cat.Name.Trim() == item.GoodsName.Trim())
                        {
                            flag = true;
                            cellTotal += item.Price;
                            row.Cells.Add(this.getDateGridViewCell(cat.Name.Trim() == "刷卡" ? item.Count : item.Price));
                            //统计某类商品年度销售总额
                            GetValue(cat, item);
                            break;
                        }
                    }

                    if (flag)
                    {
                        continue;
                    }

                    row.Cells.Add(this.getDateGridViewCell("0"));
                }

                total += cellTotal;
                //添加月份销售额小计
                
                row.Cells.Add(this.getDateGridViewCell(cellTotal));

                dgv.Rows.Add(row);
            }
            lastRow.Cells.Add(this.getDateGridViewCell(total));
            dgv.Rows.Add(lastRow);
        }

        /// <summary>
        /// 累计某类商品销售额度
        /// </summary>
        /// <param name="cat">商品分类</param>
        /// <param name="item">被统计数据项</param>
        private void GetValue(GoodsCategory cat, ReportGoodsRank item)
        {
            for (int i = 0; i < lastRow.Cells.Count; i++)
            {
                if (Convert.ToInt32(lastRow.Cells[i].Tag) == cat.Id)
                {
                    lastRow.Cells[i].Value = Convert.ToDecimal(lastRow.Cells[i].Value) + (cat.Name.Trim() == "刷卡" ? item.Count : item.Price);
                    break;
                }
            }
        }

        /// <summary>
        /// 创建一个DataGridViewCell
        /// </summary>
        /// <param name="text">显示的内容</param>
        /// <param name="tag">绑定的数据</param>
        /// <returns></returns>
        private DataGridViewTextBoxCell getDateGridViewCell(Object text, Object tag = null)
        {
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            cell.Tag = tag;
            cell.Value = text.ToString();
            return cell;
        }

        #region IForm接口实现

        public void Start()
        {
            this.Show();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public string GetProcessText()
        {
            throw new NotImplementedException();
        }

        public bool IsNext()
        {
            throw new NotImplementedException();
        }


        #endregion

        private void btnMonthReportSearch_Click(object sender, EventArgs e)
        {
            String msg = null;
            if (String.IsNullOrEmpty(this.cmbMonth.Text.Trim()))
            {
                msg = "请选择月份!";
            }else if (String.IsNullOrEmpty(this.cmbYear.Text.Trim()))
            {
                msg = "请选择年份!";
            }

            if (! String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "数据不完整", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            loadMonthData(Convert.ToInt32(this.cmbYear.Text.Trim()), Convert.ToInt32(this.cmbMonth.Text.Trim()));
        }

        private void btnSaleLogSearch_Click(object sender, EventArgs e)
        {
            loadSaleLogs(Convert.ToDateTime(this.dtpDataBegin.Value.ToString("yyyy-MM-dd 00:00:00")), Convert.ToDateTime(this.dtpDataEnd.Value.ToString("yyyy-MM-dd 23:59:59")));
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (logId < 1)
            {
                return;
            }

            saleBll.DeleteLog(logId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddLog frmLog = new FrmAddLog();
            frmLog.ShowDialog();
        }

        private void dgvSalelogs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvSalelogs.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            logId = Convert.ToInt32(row.Cells[0].Value);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            String fileUrl = Application.StartupPath + "/Assets/Icon/icon_8.ico";
            this.Icon = new System.Drawing.Icon(fileUrl);
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            timerStart.Stop();

            loadData();
            LoadCategories();
            LoadGoodsRank();
            LoadYears();
            loadMonthData(DateTime.Now.Year, DateTime.Now.Month);
            loadSaleLogs(DateTime.Now.AddDays(-7), DateTime.Now);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
