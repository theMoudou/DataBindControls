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
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
    }
}