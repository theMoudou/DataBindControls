using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.Models
{
    /// <summary> 使用者權限 </summary>
    public enum UserLevelEnum
    {
        /// <summary> 最高權限管理者 </summary>
        Super = 1,

        /// <summary> 一般管理者 </summary>
        Admin = 2
    }
}