using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class Page6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string val = this.Request.Form["txt1"];

            int number = Convert.ToInt32(val);
            
            this.lbl.Text = val;

            string[] vals = this.Request.Form.GetValues("txt1");

            if (vals != null)
                this.lbl.Text += "<br/>" + string.Join(" / ", vals);
        }
    }
}