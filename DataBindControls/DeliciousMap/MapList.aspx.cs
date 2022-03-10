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

        protected void Page_Load(object sender, EventArgs e)
        {
            string pageIndexText = this.Request.QueryString["Index"];
            int pageIndex =
                (string.IsNullOrWhiteSpace(pageIndexText))
                    ? 1
                    : Convert.ToInt32(pageIndexText);

            if (!this.IsPostBack)
            {
                int totalRows = 0;
                var list = this._mgr.GetMapList(_pageSize, pageIndex, out totalRows);
                this.ProcessPager(pageIndex, totalRows);

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


        private void ProcessPager(int pageIndex, int totalRows)
        {
            int pageCount = (totalRows / _pageSize);
            if ((totalRows % _pageSize) > 0)
                pageCount += 1;

            // LocalPath :   MapList.aspx
            string url = Request.Url.LocalPath;

            this.aLinkFirst.HRef = url + "?Index=1";
            this.aLinkPrev.HRef = url + "?Index=" + (pageIndex - 1);
            this.aLinkNext.HRef = url + "?Index=" + (pageIndex + 1);
            this.aLinkLast.HRef = url + "?Index=" + pageCount;

            this.aLinkPage1.HRef = url + "?Index=" + (pageIndex - 2);
            this.aLinkPage1.InnerText = (pageIndex - 2).ToString();
            if (pageIndex <= 2)
                this.aLinkPage1.Visible = false;

            this.aLinkPage2.HRef = url + "?Index=" + (pageIndex - 1);
            this.aLinkPage2.InnerText = (pageIndex - 1).ToString();
            if (pageIndex <= 1)
                this.aLinkPage2.Visible = false;

            this.aLinkPage3.HRef = "";
            this.aLinkPage3.InnerText = pageIndex.ToString();

            this.aLinkPage4.HRef = url + "?Index=" + (pageIndex + 1);
            this.aLinkPage4.InnerText = (pageIndex + 1).ToString();
            if ((pageIndex + 2) > pageCount)
                this.aLinkPage4.Visible = false;

            this.aLinkPage5.HRef = url + "?Index=" + (pageIndex + 2);
            this.aLinkPage5.InnerText = (pageIndex + 2).ToString();
            if ((pageIndex + 1) > pageCount)
                this.aLinkPage5.Visible = false;
        }
    }
}