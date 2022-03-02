using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class Form7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbl.Text = Request.QueryString["AAA"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string schema = this.Request.Url.Scheme;
            string host = this.Request.Url.Host;
            string path = this.Request.Url.LocalPath;

            NameValueCollection nvc = new NameValueCollection()
            {
                { "BBB", "123" },
                { "AAA", "123" },
                { "AAA", "111" },
                { "AAA", "111" }
            };
            string qs = this.BuildQueryString(nvc);
            this.lbl.Text = schema + "://" + host + path + "?" + qs;
        }
        private string BuildQueryString(NameValueCollection nvc)
        {
            List<string> vals = new List<string>();
            foreach (string item in nvc.AllKeys)
            {
                // .NET: AAA=111,222,111
                // 正常: AAA=111&AAA=222&AAA=111
                foreach(string val in nvc.GetValues(item))
                {
                    vals.Add($"{item}={val}");
                }
            }
            string result = string.Join("&", vals);
            return result;
        }
    }
}