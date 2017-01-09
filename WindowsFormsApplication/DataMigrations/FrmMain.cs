using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace DataMigrations
{
    public partial class FrmMain : Form
    {
        private String ds = "Data Source=";
        private List<Member> members = null;
        private List<SaleLog> logs = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            members = new List<Member>();
            String sql = "SELECT id, no, category_id, created_at, expire_at, money FROM members";
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(ds + this.txtSrc.Text.Trim(), CommandType.Text, sql))
            {
                while (rdr.Read())
                {
                    Member member = new Member();
                    member.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"].ToString());
                    member.No = rdr["no"] == DBNull.Value ? "" : rdr["no"].ToString();
                    member.CategoryId = rdr["category_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["category_id"].ToString());
                    member.CreatedAt = rdr["created_at"] == DBNull.Value ? "" : rdr["created_at"].ToString();
                    member.BeginAt = rdr["created_at"] == DBNull.Value ? "" : rdr["created_at"].ToString();
                    member.EndAt = rdr["expire_at"] == DBNull.Value ? "" : rdr["expire_at"].ToString();
                    member.Money = rdr["money"] == DBNull.Value ? "" : rdr["money"].ToString();
                    members.Add(member);
                }
            }
            this.labTotal.Text = members.Count.ToString();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnMigrationMember_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO members_cards(card_no, category_id, created_at) VALUES";

            int row = 0;
            int i = 0;
            foreach (Member member in members)
            {

                sql += String.Format("('{0}', {1}, {2}),", member.No, member.CategoryId, member.BeginAt == "0001/1/1 0:00:00" || member.BeginAt == "0001-1-1 0:00:00" ? 0 : TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(member.BeginAt)));
                i++;

                if (i > 5000)
                {
                    sql = sql.Substring(0, sql.Length - 1);
                    row = SQLiteHelper.ExecuteNonQuery(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql);
                    Console.WriteLine("本次处理：" + row);
                    row = Tools.MySqlHelper.ExecuteNonQuery(this.txtServer.Text.Trim(), CommandType.Text, sql);
                    this.labOk.Text = i.ToString();
                    this.labNone.Text = (Convert.ToInt32(this.labTotal.Text) - Convert.ToInt32(this.labOk.Text)).ToString();

                    sql = "INSERT INTO members_cards(card_no, category_id, created_at) VALUES";
                }
            }

            sql = sql.Substring(0, sql.Length - 1);
            row = SQLiteHelper.ExecuteNonQuery(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql);
            if (row < 1)
            {
                Console.WriteLine("最后一次处理失败：" + sql);
                return;
            }


            row = Tools.MySqlHelper.ExecuteNonQuery(this.txtServer.Text.Trim(), CommandType.Text, sql);
            Console.WriteLine("最后一次处理：" + row);
            this.labOk.Text = i.ToString();
            this.labNone.Text = (Convert.ToInt32(this.labTotal.Text) - Convert.ToInt32(this.labOk.Text)).ToString();

            MessageBox.Show("会员卡迁移完成");
        }

        private void btnMemberValue_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO members_cards_records(member_card_id, balance, begin_at, expired_at, status, created_at) VALUES";

            int row = 0;
            int i = 0;
            foreach (Member member in members)
            {
                if(Convert.ToInt32(member.Money) < 1 || member.CreatedAt == "0001/1/1 0:00:00" || member.CreatedAt == "0001-1-1 0:00:00" || member.EndAt == "")
                {
                    continue;
                }

                MemberCard card = this.getCard(member.No);
                sql += String.Format("({0}, {1}, {2}, {3}, 'Enabled', {4}),", card.Id, member.Money, Tools.TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(member.BeginAt)), TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(member.EndAt)), Tools.TimeStamp.GetNowTimeStamp());
                i++;

                if (i > 5000)
                {
                    sql = sql.Substring(0, sql.Length - 1);
                    row = SQLiteHelper.ExecuteNonQuery(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql);
                    Console.WriteLine("本次处理：" + row);
                    row = Tools.MySqlHelper.ExecuteNonQuery(this.txtServer.Text.Trim(), CommandType.Text, sql);
                    this.labOk.Text = i.ToString();
                    this.labNone.Text = (Convert.ToInt32(this.labTotal.Text) - Convert.ToInt32(this.labOk.Text)).ToString();

                    sql = "INSERT INTO members_cards_records(member_card_id, balance, begin_at, expired_at, status, created_at) VALUES";
                }
            }

            sql = sql.Substring(0, sql.Length - 1);
            row = SQLiteHelper.ExecuteNonQuery(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql);
            if (row < 1)
            {
                Console.WriteLine("最后一次处理失败：" + sql);
                return;
            }
            row = Tools.MySqlHelper.ExecuteNonQuery(this.txtServer.Text.Trim(), CommandType.Text, sql);
            Console.WriteLine("最后一次处理：" + row);
            this.labOk.Text = i.ToString();
            this.labNone.Text = (Convert.ToInt32(this.labTotal.Text) - Convert.ToInt32(this.labOk.Text)).ToString();

            MessageBox.Show("会员卡迁移完成");
        }

        private MemberCard getCard(String no)
        {
            MemberCard card = new MemberCard();

            String sql = String.Format("SELECT id FROM members_cards WHERE card_no = '{0}'", no);
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql))
            {
                if (rdr.Read())
                {
                    card.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"].ToString());
                }
                /*while (rdr.Read())
                {
                    member.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"].ToString());
                    member.Balance = rdr["no"] == DBNull.Value ? "" : rdr["no"].ToString();
                    member.CreatedAt = Tools.TimeStamp.GetNowTimeStamp();
                    member.BeginAt = rdr["created_at"] == DBNull.Value ? "" : rdr["created_at"].ToString();
                    member.ExpiredAt = rdr["expire_at"] == DBNull.Value ? 0 : rdr["expire_at"].ToString();
                    member.Status = "Enabled";
                    members.Add(member);
                }*/
            }
            return card;
        }

        private void btnReadRecord_Click(object sender, EventArgs e)
        {
            logs = new List<SaleLog>();
            String sql = String.Format("SELECT id, member_no, member_id, category_id, goods_id, name, created_at, money FROM sales_record WHERE id > {0} LIMIT 5000", this.txtId.Text.Trim());
            using (SQLiteDataReader rdr = SQLiteHelper.ExecuteReader(ds + this.txtSrc.Text.Trim(), CommandType.Text, sql))
            {
                while (rdr.Read())
                {
                    SaleLog log = new SaleLog();
                    log.Id = rdr["id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["id"].ToString());
                    log.MemberId = rdr["member_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["member_id"].ToString());
                    log.MemberNo = rdr["member_no"] == DBNull.Value ? "" : rdr["member_no"].ToString();
                    log.CategoryId = rdr["category_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["category_id"].ToString());
                    log.CreatedAt = rdr["created_at"] == DBNull.Value ? "" : rdr["created_at"].ToString();
                    log.BeginAt = rdr["goods_id"] == DBNull.Value ? "" : rdr["goods_id"].ToString();
                    log.EndAt = rdr["name"] == DBNull.Value ? "" : rdr["name"].ToString();
                    log.Money = rdr["money"] == DBNull.Value ? "" : rdr["money"].ToString();
                    logs.Add(log);
                }
            }
            this.labTotal.Text = logs.Count.ToString();
            btnWriterLog_Click(null, null);
        }

        private void btnWriterLog_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO sales_records(goods_id, money, summary, created_at) VALUES";

            int row = 0;
            int i = 0;
            foreach (SaleLog log in logs)
            {
                int goods_id = Convert.ToInt32(log.BeginAt);
                switch (log.BeginAt.ToString())
                {
                    case "0":
                        goods_id = 24;
                        break;
                    case "-1":
                        goods_id = 30;
                        break;
                    case "-2":
                        goods_id = 19;
                        break;
                    case "-3":
                        if (log.CategoryId == 6)
                        {
                            goods_id = 21;
                        }else if (log.CategoryId == 7)
                        {
                            goods_id = 22;
                        }
                        else if (log.CategoryId == 8)
                        {
                            goods_id = 23;
                        }
                        break;
                }
                sql += String.Format("({0}, {1}, '{2}',{3}),", goods_id, log.Money, log.EndAt, log.CreatedAt == "0001/1/1 0:00:00" ? 0 : TimeStamp.ConvertDateTimeInt(Convert.ToDateTime(log.CreatedAt)));
                i++;

                this.txtId.Text = log.Id.ToString();

                if (i > 5000)
                {   
                    sql = sql.Substring(0, sql.Length - 1);
                    row = SQLiteHelper.ExecuteNonQuery(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql);
                    Console.WriteLine("本次处理：" + row);
                    row = Tools.MySqlHelper.ExecuteNonQuery(this.txtServer.Text.Trim(), CommandType.Text, sql);
                    this.labOk.Text = i.ToString();
                    this.labNone.Text = (Convert.ToInt32(this.labTotal.Text) - Convert.ToInt32(this.labOk.Text)).ToString();
                    Thread.Sleep(500);
                    sql = "INSERT INTO sales_records(goods_id, money, summary, created_at) VALUES";
                }
            }

            sql = sql.Substring(0, sql.Length - 1);
            row = SQLiteHelper.ExecuteNonQuery(ds + this.txtTarget.Text.Trim(), CommandType.Text, sql);
            if (row < 1)
            {
                Console.WriteLine("最后一次处理失败：" + sql);
                return;
            }

            Console.WriteLine("最后一次处理：" + row);
            row = Tools.MySqlHelper.ExecuteNonQuery(this.txtServer.Text.Trim(), CommandType.Text, sql);
            this.labOk.Text = i.ToString();
            this.labNone.Text = (Convert.ToInt32(this.labTotal.Text) - Convert.ToInt32(this.labOk.Text)).ToString();

            this.labTotal.Text = "已完成";
            this.logs.Clear();
        }
    }
}
