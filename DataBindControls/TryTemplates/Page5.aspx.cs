using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class Page5 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //int n = Convert.ToInt32(this.txtCtlNumber.Text);
            //this.BuildTextBox(n);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //int n = Convert.ToInt32(this.txtCtlNumber.Text);
            //this.BuildTextBox(n);
        }

        private void BuildTextBox(int number)
        {
            for (int i = 0; i < number; i++)
            {
                this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>學生" + i + ":" });
                this.form1.Controls.Add(new TextBox() { ID = "txt" + i });
            }
        }

    }
}