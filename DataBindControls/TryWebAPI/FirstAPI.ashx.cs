using System.Collections.Generic;
using System.Web;
using TryWebAPI.Managers;
using TryWebAPI.Models;

namespace TryWebAPI
{
    /// <summary>
    /// FirstAPI 的摘要描述
    /// </summary>
    public class FirstAPI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string q = context.Request.QueryString["q"];
            string[] q = context.Request.QueryString.GetValues("q");
            if (q == null || q.Length == 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = 400;
                context.Response.Write("Query 未輸入參數: q 。");
                return;
            }

            if (string.Compare("get", context.Request.HttpMethod, true) == 0)
            {
                StudentInfo info = StudentManager.GetStudent(q[0]);
                //if (info == null)
                //{
                //    context.Response.ContentType = "text/plain";
                //    context.Response.StatusCode = 404;
                //    context.Response.Write("找不到資料: q=" + q[0] + " 。");
                //    return;
                //}

                List<StudentInfo> infoList = new List<StudentInfo>();
                if(info != null)
                    infoList.Add(info);

                string replyText = Newtonsoft.Json.JsonConvert.SerializeObject(infoList);
                context.Response.ContentType = "application/json";
                context.Response.Write(replyText);
            }
            else if (string.Compare("post", context.Request.HttpMethod, true) == 0)
            {
                //string[] postContent = context.Request.Form.GetValues("name");
                context.Response.ContentType = "text/plain";
                context.Response.Write("不支援的方法");
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