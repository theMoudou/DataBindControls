using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class ucDynamicControls : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            TextBox textbox = new TextBox() { ID = "txt1" };
            this.PlaceHolder1.Controls.Add(textbox);

            ucText uc = Page.LoadControl("~/ucText.ascx") as ucText;
            this.PlaceHolder1.Controls.Add(uc);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                this.WriteChildControlName(ctl);
            }
        }

        // 遞迴列出全部控制項內容
        private void WriteChildControlName(Control ctl)
        {
            Response.Write($"{ctl.GetType()} ({ctl.ID})<br/>");

            foreach (Control subctl in ctl.Controls)
            {
                this.WriteChildControlName(subctl);
            }
        }
    }
}