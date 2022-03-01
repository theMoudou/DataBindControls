using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class ucSideBar : System.Web.UI.UserControl
    {
        public string SideBarTitle { get; set; }
        public string SideBarContent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlTitle.Text = this.SideBarTitle;
            this.ltlContent.Text = this.SideBarContent;
        }
    }
}