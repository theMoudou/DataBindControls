using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //this.txt.Text = this.ucText.Text;
                this.txt.Text = this.ucText.GetLabelText();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //this.ucText.Text = this.txt.Text;
            this.ucText.SetLabelText(this.txt.Text);
        }
    }
}