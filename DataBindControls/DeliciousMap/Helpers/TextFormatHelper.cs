using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliciousMap.Helpers
{
    public class TextFormatHelper
    {
        const double num = 60;

        /// <summary>
        /// 數字經緯度和度分秒經緯度轉換 (Digital degree of latitude and longitude and vehicle to latitude and longitude conversion)
        /// </summary>
        /// <param name="digitalDegree">數字經緯度</param>
        /// <return>度分秒經緯度</return>
        public static string ConvertDigitalToDegrees(double digitalDegree)
        {
            int degree = (int)digitalDegree;
            double tmp = (digitalDegree - degree) * num;
            int minute = (int)tmp;
            double second = (tmp - minute) * num;
            string degrees = "" + degree + "°" + minute + "′" + second + "″";
            return degrees;
        }


    }
}