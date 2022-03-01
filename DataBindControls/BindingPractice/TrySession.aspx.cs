using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TrySession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // HttpContext.Current.Session["test"] = new Uri("https://www.google.com");
            //this.Session["test"] = new Uri("https://www.google.com");
            this.Session["Account"] = this.txt.Text;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Uri url = HttpContext.Current.Session["test"] as Uri;
            //Uri url = this.Session["test"] as Uri;

            //if (url == null)
            //    this.Literal1.Text = "No Session";
            //else
            //    this.Literal1.Text = url.ToString();
            string acc = this.Session["Account"] as string;

            if (string.IsNullOrWhiteSpace(acc))
                this.Literal1.Text = "No Session";
            else
                this.Literal1.Text = acc.ToString();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            this.Session.Clear();
            this.Session.Remove("Account");
            this.Session.Abandon();
        }
    }
}