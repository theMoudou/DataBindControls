using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.Models
{
    public class MemberAccount
    {
        public Guid ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}