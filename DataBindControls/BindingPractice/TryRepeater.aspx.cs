using BindingPractice.Managers;
using BindingPractice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                StudentManager mgr = new StudentManager();
                //DataTable dt = mgr.GetDataTable();
                //this.Repeater1.DataSource = dt;
                //this.Repeater1.DataBind();

                List<StudentInfo> list = mgr.GetStudentList();
                this.Repeater1.DataSource = list;
                this.Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            this.lbl.Text += e.Item.ItemType.ToString() + "<br/>";

            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltl = e.Item.FindControl("ltl1") as Literal;
                if (ltl != null)
                    ltl.Text = "Row No:" + e.Item.ItemIndex;

                Literal ltlMobile = e.Item.FindControl("ltlMobile") as Literal;
                //DataRowView drv = e.Item.DataItem as DataRowView;
                //string mobile = drv["Mobile"] as string;
                StudentInfo info = e.Item.DataItem as StudentInfo;
                string mobile = info.Mobile;
                if (ltlMobile != null)
                    ltlMobile.Text = mobile;
            }
        }

        protected void Repeater1_PreRender(object sender, EventArgs e)
        {
            foreach (RepeaterItem repeaterItem in this.Repeater1.Items)
            {
                if (repeaterItem.ItemType == ListItemType.Item ||
                    repeaterItem.ItemType == ListItemType.AlternatingItem)
                {
                    // 尋找控制項
                    Literal ltl = repeaterItem.FindControl("ltl1") as Literal;
                    if (ltl != null)
                        ltl.Text = "Row No:" + repeaterItem.ItemIndex;

                    Literal ltlID = repeaterItem.FindControl("ltlID") as Literal;
                    ltlID.Text = "[" + ltlID.Text + "]";

                    HtmlGenericControl div1 = repeaterItem.FindControl("div1") as HtmlGenericControl;
                    if (div1 != null)
                        div1.Style.Add("background-color", "gray");
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DeleteButton":
                    string id = e.CommandArgument as string;
                    StudentManager mgr = new StudentManager();
                    mgr.DeleteStudent(id);

                    Response.Redirect(this.Request.RawUrl);
                    break;

                case "EditButton":
                    TextBox txtName = e.Item.FindControl("txtName") as TextBox;
                    TextBox txtMobile = e.Item.FindControl("txtMobile") as TextBox;
                    TextBox txtImagePath = e.Item.FindControl("txtImagePath") as TextBox;
                    string id2 = e.CommandArgument as string;

                    if (txtName == null ||
                        txtMobile == null ||
                        txtImagePath == null)
                        return;

                    StudentManager mgr2 = new StudentManager();
                    mgr2.UpdateStudent(id2, txtName.Text, txtMobile.Text, txtImagePath.Text, new DateTime(2022, 2, 2));
                    break;

                default:
                    break;
            }
        }
    }
}