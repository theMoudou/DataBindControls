﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap.ShareControls
{
    public partial class ucPager : System.Web.UI.UserControl
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalRows { get; set; } = 0;

        private string _url = null;
        public string Url
        {
            get
            {
                if (this._url == null)
                    return Request.Url.LocalPath;
                else
                    return this._url;
            }
            set
            {
                this._url = value;
            }
        }

        public void Bind()
        {
            NameValueCollection collection = new NameValueCollection();
            this.Bind(collection);
        }

        public void Bind(string paramKey, string paramValue)
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add(paramKey, paramValue);
            this.Bind(collection);
        }

        public void Bind(NameValueCollection collection)
        {
            int pageCount = (this.TotalRows / this.PageSize);
            if ((this.TotalRows % this.PageSize) > 0)
                pageCount += 1;

            // LocalPath :   MapList.aspx
            string url = this.Url;
            string qsText = this.BuildQueryString(collection);

            this.aLinkFirst.HRef = url + "?Index=1" + qsText;
            this.aLinkPrev.HRef = url + "?Index=" + (this.PageIndex - 1) + qsText;
            this.aLinkNext.HRef = url + "?Index=" + (this.PageIndex + 1) + qsText;
            this.aLinkLast.HRef = url + "?Index=" + pageCount + qsText;

            this.aLinkPage1.HRef = url + "?Index=" + (this.PageIndex - 2) + qsText;
            this.aLinkPage1.InnerText = (this.PageIndex - 2).ToString();
            if (this.PageIndex <= 2)
                this.aLinkPage1.Visible = false;

            this.aLinkPage2.HRef = url + "?Index=" + (this.PageIndex - 1) + qsText;
            this.aLinkPage2.InnerText = (this.PageIndex - 1).ToString();
            if (this.PageIndex <= 1)
                this.aLinkPage2.Visible = false;

            this.aLinkPage3.HRef = "";
            this.aLinkPage3.InnerText = this.PageIndex.ToString();

            this.aLinkPage4.HRef = url + "?Index=" + (this.PageIndex + 1) + qsText;
            this.aLinkPage4.InnerText = (this.PageIndex + 1).ToString();
            if ((this.PageIndex + 1) > pageCount)
                this.aLinkPage4.Visible = false;

            this.aLinkPage5.HRef = url + "?Index=" + (this.PageIndex + 2) + qsText;
            this.aLinkPage5.InnerText = (this.PageIndex + 2).ToString();
            if ((this.PageIndex + 2) > pageCount)
                this.aLinkPage5.Visible = false;
        }

        /// <summary> 組合 QueryString </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private string BuildQueryString(NameValueCollection collection)
        {
            List<string> paramList = new List<string>();
            // &key=value
            foreach (string key in collection.AllKeys)
            {
                if (collection.GetValues(key) == null)
                    continue;

                foreach (string val in collection.GetValues(key))
                {
                    paramList.Add($"&{key}={val}");
                }
            }
            string result = string.Join("", paramList);
            return result;
        }
    }
}