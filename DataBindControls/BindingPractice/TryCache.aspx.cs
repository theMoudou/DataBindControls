using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Cache["Test"] == null)
                this.Literal1.Text = "No cache[Test]";
            else
                this.Literal1.Text = this.Cache["Test"] as string;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Cache["Test"] = "123";
            this.Cache["Test"] = "123";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.Cache["Test"] = null;
            //this.Cache["Test"] = null;
            this.Cache.Remove("Test");
        }
    }
}