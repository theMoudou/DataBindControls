using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class ucPercent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string number = this.txt.Text;
            this.ltlPercent.Text = number;

            //另一個方式
            this.ltlPercent2.Text = number;
            this.div1.Style["width"] = number + "%";
        }
    }
}