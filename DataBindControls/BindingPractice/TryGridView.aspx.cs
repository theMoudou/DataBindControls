using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using BindingPractice.Managers;
using System.Data;

namespace BindingPractice
{
    public partial class TryGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentManager mgr = new StudentManager();
            DataTable dt = mgr.GetDataTable();

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

            this.GridView2.DataSource = dt;
            this.GridView2.DataBind();
        }
    }
}