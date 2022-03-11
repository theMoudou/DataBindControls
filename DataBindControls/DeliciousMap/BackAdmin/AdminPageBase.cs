using DeliciousMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.BackAdmin
{
    /// <summary> 後台管理頁面的基礎類別 (需部份覆寫) </summary>
    public abstract class AdminPageBase : System.Web.UI.Page
    {
        /// <summary> 頁面的權限 </summary>
        public virtual UserLevelEnum[] PageUserLevel { get; set; } = { UserLevelEnum.Admin, UserLevelEnum.Super };

        /// <summary> 取得目前頁面的權限 </summary>
        /// <returns></returns>
        public UserLevelEnum[] GetUserLevel()
        {
            return this.PageUserLevel;
        }
    }
}