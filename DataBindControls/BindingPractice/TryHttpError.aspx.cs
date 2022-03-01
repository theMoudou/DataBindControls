using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BindingPractice
{
    public partial class TryHttpError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpContext.Current.Request
            //HttpContext.Current.Response
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.GoToError();
        }

        private void GoToError()
        {
            this.Response.StatusCode = 418; 
            this.Response.Write("我是個快樂的小茶壺");

            this.Response.Flush();          // 輸出目前所有內容
            this.Response.SuppressContent = true;

            // 中止目前的 Request ，直接前往 Response
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}