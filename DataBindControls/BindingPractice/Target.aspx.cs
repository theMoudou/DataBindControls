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
            //NameValueCollection collection = this.Request.QueryString;

            //string q1 = collection["Q1"];
            //string q2 = collection["Q2"];
            string q1 = this.Request.QueryString["Q1"];
            string q2 = this.Request.QueryString["Q2"];

            // 如果 Q1, Q2 都是必填
            if (string.IsNullOrWhiteSpace(q1) ||
               string.IsNullOrWhiteSpace(q2))
            {
                this.ltl1.Text = "QueryString 中， Q1, Q2 為必填";
                return;
            }

            this.ltl1.Text = q1;
            this.ltl2.Text = q2;
        }
    }
}