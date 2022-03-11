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
    public partial class MemberDetail : AdminPageBase
    {
        /// <summary> 頁面的權限 </summary>
        public override UserLevelEnum[] PageUserLevel { get; set; } = { UserLevelEnum.Super };

        private bool _isEditMode = true;
        private AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.Request.QueryString["ID"]))
                _isEditMode = true;
            else
                _isEditMode = false;


            if (_isEditMode)
            {
                string idText = this.Request.QueryString["ID"];
                Guid id;
                if (!Guid.TryParse(idText, out id))
                    this.lblMsg.Text = "id 錯誤";
                else
                    this.InitEditMode(id);
            }
            else
            {
                this.InitCreateMode();
            }
        }

        /// <summary> 初始化新增模式的內頁 </summary>
        private void InitCreateMode()
        {
            this.ltlAccount.Visible = false;
            this.txtAccount.Visible = true;

            this.ltlID.Text = "尚待新增";
        }

        /// <summary> 初始化編輯模式的內頁 </summary>
        private void InitEditMode(Guid id)
        {
            this.ltlAccount.Visible = true;
            this.txtAccount.Visible = false;

            AccountModel member = this._mgr.GetAccount(id);

            if (member == null)
            {
                this.lblMsg.Text = "查無此 id ";
                return;
            }

            this.ltlAccount.Text = member.Account;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();

            if (!_isEditMode)
            {
                AccountModel member = new AccountModel();
                member.Account = account;
                member.Password = pwd;

                this._mgr.CreateAccount(member);
                Response.Redirect("MemberDetail.aspx?ID=" + member.ID);
            }
            else
            {
                string idText = this.Request.QueryString["ID"];
                Guid id;
                if (!Guid.TryParse(idText, out id))
                {
                    this.lblMsg.Text = "id 錯誤";
                    return;
                }

                // 從資料庫查出來更新
                AccountModel member = this._mgr.GetAccount(id);
                member.Password = pwd;
                this._mgr.UpdateAccount(member);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberList.aspx");
        }
    }
}