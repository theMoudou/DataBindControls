using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryHttpItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Method1()
        {
            //string val = HttpContext.Current.Items["Test"] as string;
            string val = this.Items["Test"] as string;

            if (string.IsNullOrWhiteSpace(val))
                this.ltl.Text = "HttpItem[Test] 不存在";
            else
                this.ltl.Text = "HttpItem[Test]: " + val;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Items["Test"] = "Val";
            this.Method1();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.Items["AnotherHttpItem"] = "Val";
            this.Method1();
        }
    }
}