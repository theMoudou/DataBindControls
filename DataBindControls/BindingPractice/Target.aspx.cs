using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;

namespace BindingPractice
{
    public partial class Target : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string q1 = this.Request.QueryString["Q1"];
            string q2 = this.Request.QueryString["Q2"];

            string[] q1Arr = this.Request.QueryString.GetValues("Q1");

            // 如果 Q1, Q2 都是必填
            if (string.IsNullOrWhiteSpace(q1) ||
               string.IsNullOrWhiteSpace(q2))
            {
                this.ltl1.Text = "QueryString 中， Q1, Q2 為必填";
                return;
            }

            this.ltl1.Text = q1 + "，陣列內容為 [" + string.Join(" / ", q1Arr) + "]";
            this.ltl2.Text = q2;


            NameValueCollection qsCollection = this.Request.QueryString;
            this.ltlRequestInfo.Text = "QueryString: <br/>";
            foreach(string key in qsCollection.AllKeys)
            {
                string val = qsCollection[key];
                this.ltlRequestInfo.Text += $"{key}: {val} <br/>";
            }

            this.ltlRequestInfo.Text += $"RawUrl: {this.Request.RawUrl} <br/>";
            this.ltlRequestInfo.Text += $"Url: {this.Request.Url} <br/>";
            this.ltlRequestInfo.Text += $"Referrer: {this.Request.UrlReferrer} <br/>";

            NameValueCollection headerCollection = this.Request.Headers;
            this.ltlRequestInfo.Text += $"Host: {headerCollection["Host"]} <br/>";

            this.ltlRequestInfo.Text += $"Http Method: {this.Request.HttpMethod} <br/>";
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string txt1 = this.txt1.Text;
            string txt2 = this.Request.Form["txt1"];
        }
    }
}