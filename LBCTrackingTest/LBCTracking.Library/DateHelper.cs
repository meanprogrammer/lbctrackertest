using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LBCTracking.Library
{
    public static class DateHelper
    {
        public static DateTime MergeDateWithTime(string date, string time)
        {
            DateTime dt = DateTime.Parse(date, CultureInfo.InvariantCulture);
            DateTime tm = DateTime.Parse(time, CultureInfo.InvariantCulture);

            DateTime result = new DateTime(dt.Year, dt.Month, dt.Day, tm.Hour, tm.Minute, tm.Second);

            return result;
        }
    }
}