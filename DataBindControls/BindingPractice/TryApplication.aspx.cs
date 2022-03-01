using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // HttpContext.Current.Application["test"] = new Uri("https://www.google.com");
            this.Application["test"] = new Uri("https://www.google.com");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Uri url = HttpContext.Current.Application["test"] as Uri;
            Uri url = this.Application["test"] as Uri;

            if (url == null)
            {
                this.Literal1.Text = "No Application";
            }
            else
            {
                this.Literal1.Text = url.ToString();
            }
        }
    }
}