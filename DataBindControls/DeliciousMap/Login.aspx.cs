using DeliciousMap.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeliciousMap
{
    public partial class Login : System.Web.UI.Page
    {
        private AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();

            if (this._mgr.TryLogin(account, pwd))
            {
                Response.Redirect("~/BackAdmin/Index.aspx");
            }
            else
            {
                this.ltlMessage.Text = "登入失敗，請檢查帳號密碼。";
            }
        }
    }
}