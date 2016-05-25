using System;
using System.Collections.Generic;

namespace DevZa.Utilities
{
    public class DateTimeHelper
    {
        public static int GetWeekOfMonth(System.DateTime date)
        {
            System.DateTime beginningOfMonth = new System.DateTime(date.Year, date.Month, 1);

            //while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            //    date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }


        public static IEnumerable<System.DateTime> EachDay(System.DateTime from, System.DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
