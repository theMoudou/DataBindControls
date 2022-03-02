using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page2.Page_Init <br/> ");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Main master = this.Master as Main;

            //if (master != null)
            //{
            //    master.HeaderText = "在程式裡，控制 MasterPage 的 Header column";

            //    master.SetFooterText(new Models.StudentInfo()
            //    {
            //        ID = "001",
            //        Name = "測試學生",
            //        Mobile = "0999999999"
            //    });
            //}

            Response.Write("Page2.Page_Load <br/> ");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Page2.Button1_Click <br/> ");
        }
    }
}