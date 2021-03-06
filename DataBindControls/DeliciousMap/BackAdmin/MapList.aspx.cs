using DeliciousMap.Managers;
using DeliciousMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap.BackAdmin
{
    public partial class MapList : AdminPageBase
    {
        //public override UserLevelEnum[] PageUserLevel { get; set; } = { UserLevelEnum.Super };

       
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
            List<Guid> ids = new List<Guid>();
            foreach (RepeaterItem item in this.rptList.Items)
            {
                CheckBox ckb = item.FindControl("ckbDel") as CheckBox;
                HiddenField hf = item.FindControl("hfID") as HiddenField;

                if (ckb != null && hf != null && ckb.Checked)
                {
                    Guid id;
                    if (Guid.TryParse(hf.Value, out id))
                    {
                        ids.Add(id);
                    }
                }
            }

            if (ids.Count > 0)
            {
                List<MapContentModel> pickedList = this._mgr.GetMapList(ids);
                foreach (MapContentModel model in pickedList)
                {
                    this.DeleteImage(model.CoverImage);
                }

                this._mgr.DeleteMapContent(ids);
            }
        }

        private void DeleteImage(string imagePath)
        {
            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + imagePath);

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }
    }
}