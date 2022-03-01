using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("MyCookie");
            cookie.Name = "test";
            cookie.Value = "123";
            cookie.Expires = DateTime.Today.AddDays(3);
            
            cookie.HttpOnly = true;     // 是否只允許使用 http 讀取
            cookie.Secure = true;       // 僅允許使用 https
            Response.Cookies.Add(cookie);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["test"];

            if (cookie != null)
            {
                this.Literal1.Text =
                    "Name: " + cookie.Name +
                    "<br/>Value: " + cookie.Value;
            }
            else
                this.Literal1.Text = "No cookie: MyCookie";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("MyCookie");
            cookie.Name = "test";
            cookie.Expires = DateTime.Today.AddDays(-30);
            Response.Cookies.Add(cookie);
        }
    }
}