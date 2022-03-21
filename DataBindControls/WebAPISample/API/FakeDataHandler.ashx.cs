using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPISample.Managers;

namespace WebAPISample.API
{
    /// <summary>
    /// FakeDataHandler 的摘要描述
    /// </summary>
    public class FakeDataHandler : IHttpHandler
    {
        private FakeDataManager _mgr = new FakeDataManager();

        public void ProcessRequest(HttpContext context)
        {
            // get(有id) : 查詢單筆
            if (string.Compare("GET", context.Request.HttpMethod, true) == 0 &&
                !string.IsNullOrEmpty(context.Request.QueryString["ID"]))
            {
                string id = context.Request.QueryString["ID"];
                var model = _mgr.Get(id);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
                return;
            }

            // get(無id) : 查詢單筆
            if (string.Compare("GET", context.Request.HttpMethod, true) == 0)
            {
                var list = _mgr.GetList();
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);

                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
                return;
            }

            // post: 更新
            if (string.Compare("POST", context.Request.HttpMethod) == 0 &&
                string.Compare("UPDATE", context.Request.QueryString["Action"], true) == 0)
            {
                string id = context.Request.Form["ID"];
                string name = context.Request.Form["Name"];
                string content = context.Request.Form["Content"];

                //TODO: 應加入各欄位必填、型別檢查

                FakeDataModel model = new FakeDataModel()
                {
                    ID = id,
                    Name = name,
                    Content = content
                };

                // 加入 NULL 檢查
                var dbModel = this._mgr.Get(model.ID);
                if (dbModel == null)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("NULL");
                }
                else
                {
                    this._mgr.UpdateFakeData(model);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("OK");
                }
                return;
            }
            // post: 新增
            // post: 刪除
            if (string.Compare("POST", context.Request.HttpMethod) == 0 &&
                string.Compare("DELETE", context.Request.QueryString["Action"], true) == 0)
            {
                string id = context.Request.Form["ID"];

                // 加入 NULL 檢查
                var dbModel = this._mgr.Get(id);
                if (dbModel == null)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("NULL");
                }
                else
                {
                    this._mgr.DeleteFakeData(id);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("OK");
                }
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}