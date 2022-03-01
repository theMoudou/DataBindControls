using System;
using System.Collections.Generic;
using System.Drawing;
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
            List<HeaderLink> headerList = this.ReadDBLinks();

            this.rptHeaderLink.DataSource = headerList;
            this.rptHeaderLink.DataBind();


            List<SideBar> sideBarList = this.ReadDBSideBar();
            this.ucSideBar1.Value = 100;
            this.ucSideBar1.TextColor = Color.Snow;
            this.ucSideBar1.SideBarTitle = sideBarList[0].Title;
            this.ucSideBar1.SideBarContent = sideBarList[0].Content;

            this.ucSideBar2.SideBarTitle = sideBarList[1].Title;
            this.ucSideBar2.SideBarContent = sideBarList[1].Content;

            this.ucSideBar3.SideBarTitle = sideBarList[2].Title;
            this.ucSideBar3.SideBarContent = sideBarList[2].Content;
        }

        private List<HeaderLink> ReadDBLinks()
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

        private List<SideBar> ReadDBSideBar()
        {
            return new List<SideBar>()
            {
                new SideBar() { Title = "側邊一", Content = "<p>測邊一，內文第一行</p>" },
                new SideBar() { Title = "側邊二", Content = "<p>測邊二，內文第一行</p>" },
                new SideBar() { Title = "側邊三", Content = "<p>測邊三，內文第一行</p>" },
            };
        }

        class SideBar
        {
            public string Title { get; set; }
            public string Content { get; set; }
        }
    }
}