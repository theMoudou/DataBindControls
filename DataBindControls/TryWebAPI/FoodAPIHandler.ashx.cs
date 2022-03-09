using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryWebAPI
{
    /// <summary>
    /// FoodAPIHandler 的摘要描述
    /// </summary>
    public class FoodAPIHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Write("Hello World");
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