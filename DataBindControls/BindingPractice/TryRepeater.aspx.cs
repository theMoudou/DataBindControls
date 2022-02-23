using BindingPractice.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentManager mgr = new StudentManager();
            DataTable dt = mgr.GetDataTable();

            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();

        }
    }
}