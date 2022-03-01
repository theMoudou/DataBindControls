using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class ucSideBar : System.Web.UI.UserControl
    {
        public Color TextColor { get; set; } = Color.Black;
        public int Value { get; set; }
        public string SideBarTitle { get; set; }
        public string SideBarContent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltlTitle.Text = this.SideBarTitle;
            this.ltlTitle.ForeColor = this.TextColor;
            this.ltlContent.Text = this.SideBarContent;
        }
    }
}