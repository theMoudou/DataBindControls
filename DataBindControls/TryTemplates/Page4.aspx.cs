using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryTemplates
{
    public partial class Page4 : System.Web.UI.Page
    {
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    //int number = Convert.ToInt32(this.Request.QueryString["Count"]);
        //    //object n = this.Session["Count"];
        //    string n = this.hfCount.Value;
        //    int number = Convert.ToInt32(n);

        //    this.BuildTextBox(number);
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
        //    string n = this.hfCount.Value;
        //    int number = Convert.ToInt32(n);

        //    this.BuildTextBox(number);
        }

        private void BuildTextBox(int number)
        {
            for (int i = 0; i < number; i++)
            {
                this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>學生" + i + ":" });
                this.form1.Controls.Add(new TextBox() { ID = "txt" + i });
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(this.txtCtlNumber.Text);

            //// 組 querystring  =>  localhost:xxxx/Page4.aspx?Count=15
            //Response.Redirect(this.Request.RawUrl + "?Count=" + this.txtCtlNumber.Text);

            //// 放 Session
            //this.Session["Count"] = n;
            //this.BuildTextBox(n);

            // 放 HiddenField
            this.hfCount.Value = n.ToString();
            this.BuildTextBox(n);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}