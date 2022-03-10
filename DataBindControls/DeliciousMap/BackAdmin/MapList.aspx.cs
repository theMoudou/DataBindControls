using DeliciousMap.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap.BackAdmin
{
    public partial class MapList : System.Web.UI.Page
    {
        private MapContentManager _mgr = new MapContentManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string keyword = this.Request.QueryString["keyword"];
                this.txtSearch.Text = keyword;

                var list = this._mgr.GetAdminMapList(keyword);
                if (list.Count == 0)
                {
                    this.plcEmpty.Visible = true;
                    this.rptList.Visible = false;
                }
                else
                {
                    this.plcEmpty.Visible = false;
                    this.rptList.Visible = true;

                    this.rptList.DataSource = list;
                    this.rptList.DataBind();
                }
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("MapDetail.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtSearch.Text))
            {
                this.Response.Redirect("MapList.aspx");
            }
            else
            {
                string keyword = this.txtSearch.Text.Trim();
                this.Response.Redirect("MapList.aspx?keyword=" + keyword);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

    }
}