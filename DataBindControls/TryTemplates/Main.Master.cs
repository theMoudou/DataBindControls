using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TryTemplates.Models;

namespace TryTemplates
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public string HeaderText { get; set; }

        public string LogoUrl { get; set; }

        public void SetFooterText (StudentInfo student)
        {
            this.ltlFooter.Text =
                $@" 姓名： {student.Name} <br/>
                    電話： {student.Mobile} <br/>
                ";
        }

        protected void Page_Init(object sender, EventArgs e)
        { 
            Response.Write("Main.Page_Init <br/> ");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ltlHeader.Text = this.HeaderText;
            Response.Write("Main.Page_Load <br/> ");
        }
    }
}