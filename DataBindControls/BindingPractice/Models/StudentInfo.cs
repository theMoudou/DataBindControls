using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingPractice.Models
{
    public class StudentInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? IsMale { get; set; }

        //public int Number1 = 50;

        public int DiffDays
        {
            get
            {
                if (!this.Birthday.HasValue)
                    return 0;

                TimeSpan ts = this.Birthday.Value - new DateTime(2000, 1, 1);
                return ts.Days;
            }
        }
    }
}