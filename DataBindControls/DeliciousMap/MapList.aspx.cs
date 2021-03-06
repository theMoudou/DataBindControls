using DeliciousMap.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap
{
    public partial class MapList : System.Web.UI.Page
    {
        private MapContentManager _mgr = new MapContentManager();
        private const int _pageSize = 2;

        public string aaa = "aaa";


        protected void Page_Load(object sender, EventArgs e)
        {
            string pageIndexText = this.Request.QueryString["Index"];
            int pageIndex =
                (string.IsNullOrWhiteSpace(pageIndexText))
                    ? 1
                    : Convert.ToInt32(pageIndexText);

            if (!this.IsPostBack)
            {
                string keyword = this.Request.QueryString["keyword"];

                if (!string.IsNullOrWhiteSpace(keyword))
                    this.txtKeyword.Text = keyword;

                int totalRows = 0;
                var list = this._mgr.GetMapList(keyword, _pageSize, pageIndex, out totalRows);
                //this.ProcessPager(keyword, pageIndex, totalRows);

                this.ucPager.TotalRows = totalRows;
                this.ucPager.PageIndex = pageIndex;
                this.ucPager.Bind("keyword", keyword);

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


        //private void ProcessPager(string keyword, int pageIndex, int totalRows)
        //{
        //    int pageCount = (totalRows / _pageSize);
        //    if ((totalRows % _pageSize) > 0)
        //        pageCount += 1;

        //    // LocalPath :   MapList.aspx
        //    string url = Request.Url.LocalPath;
        //    string paramKeyword = string.Empty;
        //    if (!string.IsNullOrWhiteSpace(keyword))
        //        paramKeyword = "&keyword=" + keyword;

        //    this.aLinkFirst.HRef = url + "?Index=1" + paramKeyword;
        //    this.aLinkPrev.HRef = url + "?Index=" + (pageIndex - 1)+ paramKeyword;
        //    this.aLinkNext.HRef = url + "?Index=" + (pageIndex + 1) + paramKeyword;
        //    this.aLinkLast.HRef = url + "?Index=" + pageCount + paramKeyword;

        //    this.aLinkPage1.HRef = url + "?Index=" + (pageIndex - 2) + paramKeyword;
        //    this.aLinkPage1.InnerText = (pageIndex - 2).ToString();
        //    if (pageIndex <= 2)
        //        this.aLinkPage1.Visible = false;

        //    this.aLinkPage2.HRef = url + "?Index=" + (pageIndex - 1) + paramKeyword;
        //    this.aLinkPage2.InnerText = (pageIndex - 1).ToString();
        //    if (pageIndex <= 1)
        //        this.aLinkPage2.Visible = false;

        //    this.aLinkPage3.HRef = "";
        //    this.aLinkPage3.InnerText = pageIndex.ToString();

        //    this.aLinkPage4.HRef = url + "?Index=" + (pageIndex + 1) + paramKeyword;
        //    this.aLinkPage4.InnerText = (pageIndex + 1).ToString();
        //    if ((pageIndex + 1) > pageCount)
        //        this.aLinkPage4.Visible = false;

        //    this.aLinkPage5.HRef = url + "?Index=" + (pageIndex + 2) + paramKeyword;
        //    this.aLinkPage5.InnerText = (pageIndex + 2).ToString();
        //    if ((pageIndex + 2) > pageCount)
        //        this.aLinkPage5.Visible = false;
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = this.Request.Url.LocalPath + "?keyword=" + this.txtKeyword.Text;
            this.Response.Redirect(url);
        }
    }
}