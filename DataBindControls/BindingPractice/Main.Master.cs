using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 假設讀取資料庫
            List<HeaderLink> list = ReadDBLinks();

            this.rptHeaderLink.DataSource = list;
            this.rptHeaderLink.DataBind();
        }

        private static List<HeaderLink> ReadDBLinks()
        {
            return new List<HeaderLink>()
            {
                new HeaderLink() { Name = "Index", Url = "./index.html" },
                new HeaderLink() { Name = "About Us", Url = "./index.html" },
                new HeaderLink() { Name = "Contact Us", Url = "./index.html" },
                new HeaderLink() { Name = "測試", Url = "./index.html" },
            };
        }

        class HeaderLink
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}