using DeliciousMap.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap.BackAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private string _loginPage = "~/Login.aspx";

        protected void Page_Init(object sender, EventArgs e)
        {
            // 如果尚未登入，轉跳至登入頁
            // 且同時，要強制停止目前的 HttpContext 繼續執行
            if (!new AccountManager().IsLogined())
                Response.Redirect(_loginPage, true);
        }
    }
}