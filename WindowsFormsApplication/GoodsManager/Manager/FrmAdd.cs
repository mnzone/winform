using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FactoryImpl;
using IBLL;
using Models;

namespace GoodsManager.Manager
{
    public partial class FrmAdd : Form
    {
        private IGoodsBLL bll = null;
        private IGoodsCategoryBLL catBll = null;

        public FrmAdd()
        {
            InitializeComponent();
        }

        private void FrmAdd_Load(object sender, System.EventArgs e)
        {
            initBll();
            loadData();
            loadCategory();
        }

        private void initBll()
        {
            BllFactory.DLLBasePath = Application.StartupPath;
            bll = BllFactory.GetGoodsBll();
            catBll = BllFactory.GetGoodsCategoryBll();
        }

        private void loadData()
        {
            List<Goods> list = bll.GetAllGoods();
            foreach (Goods goods in list)
            {
                GoodsCategory cagtegory = catBll.GetCategory(goods.CategoryId);
                this.dgvList.Rows.Add(new String[]{
                    goods.Id.ToString(),
                    goods.Name,
                    cagtegory.Name,
                    goods.Sort.ToString()
                });
            }
        }

        private void loadCategory()
        {
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.ValueMember = "Id";
            this.cmbCategory.DataSource = catBll.GetAllCategories();
        }
    }
}
