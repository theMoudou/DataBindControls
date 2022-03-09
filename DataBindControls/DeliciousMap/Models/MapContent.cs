using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.Models
{
    public class MapContent
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public string Content
        {
            get { return this.Body; }
            set { this.Body = value; }
        }

    }
}