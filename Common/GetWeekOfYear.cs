using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace CSADataReport.Common
{
    public class WeekOfYear
    {
        public static int GetWeekOfYear(DateTime dt)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            System.Globalization.Calendar cal = ci.Calendar;
            CalendarWeekRule cwr = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek dow = ci.DateTimeFormat.FirstDayOfWeek;
            return cal.GetWeekOfYear(dt, cwr, dow);
        }
    }
}
