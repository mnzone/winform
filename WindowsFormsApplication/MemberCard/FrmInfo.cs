using Models;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Tools;

namespace MemberCard
{
    public partial class FrmInfo : Form
    {
        private int left;

        public FrmInfo()
        {
            InitializeComponent();
        }

        public FrmInfo(int left) : this()
        {
            this.left = left;
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            this.Left = left;
            this.WindowState = FormWindowState.Maximized;
            changeLoction();
            loadAds();
        }

        private void loadAds()
        {
            String domain = ConfigurationManager.AppSettings["domain"];
            NetResult result = request(String.Format("{0}/api/ad/items/feiyu.json", domain));

            if (result == null || result.Status == "err")
            {
                return;
            }

            JArray items = result.Data as JArray;
            int count = 0;
            foreach (JObject item in items) {
                Image image = this.getImage(String.Format("{0}/api/ad/get_resource/{1}.json", domain, item["id"]));
                if (image == null)
                {
                    continue;
                }

                
                Point point = new Point(10, 10);

                if (count > 0) {
                    point = new Point(this.Width - image.Width - 10, 10);
                }

                Size size = new Size(image.Width, image.Height);
                this.addAd(image, point, size);
                count++;
            }
            
        }

        private Image getImage(String url) {

            Image image = null;

            try {
                Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream();
                image = Image.FromStream(stream);
            } catch (System.Net.WebException e) {
                return null;
            }
            
            return image;
        }

        private void addAd(Image image, Point point, Size size)
        {
            PictureBox picture = new PictureBox();
            picture.Location = point;
            picture.Size = size;
            picture.TabIndex = 2;
            picture.TabStop = false;
            picture.Image = image;
            this.Controls.Add(picture);

            foreach (Control control in this.Controls)
            {
                this.Controls.SetChildIndex(control, control.GetType().Name == "TableLayoutPanel" ? this.Controls.Count - 1 : 0);
                Console.WriteLine(control.GetType().Name + ":" + this.Controls.GetChildIndex(control) + "#");
            }
            
        }

        /// <summary>
        /// 显示刷卡信息
        /// </summary>
        /// <param name="card">会员卡实体</param>
        /// <param name="status">其它信息</param>
        /// <param name="color">字体颜色</param>
        public void ChangeText(Models.MemberCard card, String status, System.Drawing.Color color)
        {
            if (card == null)
            {
                return;
            }

            String balance = "未找到";
            String expire = "未找到";
            if (card.Record != null)
            {
                expire = TimeStamp.ConvertIntDateTime(card.Record.ExpiredAt).ToString("yyyy-MM-dd");
                balance = card.Record == null ? "0" : card.Record.Balance.ToString();

                if (card.Record.Status == Status.Disabled)
                {
                    expire = "已收回";
                }
                else if (card.Record.ExpiredAt < TimeStamp.GetNowTimeStamp())
                {
                    balance = "此卡已过期";
                }
            }
            this.labCategory.Text = String.Format("会员类别：{0}", card.Category == null ? "未找到" : card.Category.Name);
            this.labCardNo.Text = String.Format("会员卡号：{0}", card == null ? "未找到" : card.CardNo);
            this.labCardNum.Text = String.Format("剩余次数：{0}", balance);
            this.labExpire.Text = String.Format("到期时间：{0}", expire);
            this.labStatus.Text = String.Format("{0}", status);
            this.labStatus.ForeColor = color;
            changeLoction();
        }

        private void changeLoction()
        {
            this.labCardNo.Left = (this.panel1.Width - this.labCardNo.Width) / 2;
            this.labCardNo.Top = (this.panel1.Height - this.labCardNo.Height) / 2;

            this.labCategory.Left = this.labCardNo.Left;
            this.labCategory.Top = this.labCardNo.Top;
            this.labCardNum.Left = this.labCardNo.Left;
            this.labCardNum.Top = this.labCardNo.Top;
            this.labExpire.Left = this.labCardNo.Left;
            this.labExpire.Top = this.labCardNo.Top;

            this.labStatus.Left = (this.panel1.Width - this.labStatus.Width) / 2;
            this.labStatus.Top = this.labCardNo.Top;
        }

        private void FrmInfo_SizeChanged(object sender, EventArgs e)
        {
            changeLoction();
        }

        private NetResult request(String url) {
            NetResult result = null;
            try {
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url, null, 30000, "WinForm", null);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                String json = reader.ReadToEnd();

                result = JsonHelper.DeserializeJsonToObject<NetResult>(json);
            } catch (WebException e) {
                MessageBox.Show(e.Message, "网络异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return result;
        }
    }
}
