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
    public partial class Admin : System.Web.UI.MasterPage
    {
        private string _loginPage = "~/Login.aspx";
        private string _indexPage = "~/BackAdmin/Index.aspx";
        private AccountManager _mgr = new AccountManager();

        protected void Page_Init(object sender, EventArgs e)
        {
            // 如果尚未登入，轉跳至登入頁
            // 且同時，要強制停止目前的 HttpContext 繼續執行
            if (!this._mgr.IsLogined())
                Response.Redirect(_loginPage, true);

            // 如果目前頁面是 AdminPageBase
            if (this.Page is AdminPageBase)
            {
                AdminPageBase adminPage = (AdminPageBase)this.Page;
                UserLevelEnum[] pageUserLevel = adminPage.GetUserLevel();

                // 判斷權限，如果不通過就跳回首頁
                AccountModel model = this._mgr.GetCurrentUser();
                if (!pageUserLevel.Contains(model.UserLevel))
                    Response.Redirect(_indexPage, true);
            }
        }
    }
}