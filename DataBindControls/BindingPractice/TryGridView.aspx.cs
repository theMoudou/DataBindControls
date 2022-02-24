using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using BindingPractice.Managers;
using System.Data;
using BindingPractice.Models;

namespace BindingPractice
{
    public partial class TryGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentManager mgr = new StudentManager();
            DataTable dt = mgr.GetDataTable();
            string id1 = dt.Rows[0]["ID"] as string;

            //this.GridView1.DataSource = dt;
            //this.GridView1.DataBind();

            //this.GridView2.DataSource = dt;
            //this.GridView2.DataBind();
            List<StudentInfo> list = mgr.GetStudentList();
            string id2 = list[0].ID;

            this.GridView1.DataSource = list;
            this.GridView1.DataBind();

            this.GridView2.DataSource = list;
            this.GridView2.DataBind();
        }
    }
}