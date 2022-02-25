using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class Source : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string q1 = this.txtQ1.Text.Trim();
            string q2 = this.txtQ2.Text.Trim();

            string url = $"Target.aspx?Q1={q1}&Q2={q2}";
            Response.Redirect(url);
        }
    }
}