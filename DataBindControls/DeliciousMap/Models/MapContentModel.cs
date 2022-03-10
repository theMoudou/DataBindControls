using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.Models
{
    public class MapContentModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string CoverImage { get; set; }
        public bool IsEnable { get; set; }
        /// <summary> 經度 </summary>
        public double Longitude { get; set; }
        /// <summary> 緯度 </summary>
        public double Latitude { get; set; }

        #region 管理用欄位
        public DateTime CreateDate { get; set; }
        public Guid CreateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Guid? DeleteUser { get; set; }
        #endregion

        public string Content
        {
            get { return this.Body; }
            set { this.Body = value; }
        }
    }
}