using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.Models
{
    public class AccountModel
    {
        public Guid ID { get; set; }

        /// <summary> 帳號 </summary>
        public string Account { get; set; }

        /// <summary> 密碼 </summary>
        public string Password { get; set; }

        /// <summary> 使用者權限 </summary>
        public UserLevelEnum UserLevel { get; set; }
    }
}