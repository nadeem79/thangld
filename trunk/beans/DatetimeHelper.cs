using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class DatetimeHelper
    {
        public static DateTime TimestampToDatetime(long timestamp)
        {
            return (new DateTime()).AddMilliseconds(timestamp);
           

            //return Convert.ToDateTime((double)timestamp);
            //return DateTime.FromOADate((double)timestamp);
        }
        public static long DatetimeToInt64(DateTime time)
        {
            return (long)(time - (new DateTime())).TotalMilliseconds;
            //return Convert.ToInt64((DateTime)time);
            //return (long)time.ToOADate();
        }
    }
}
