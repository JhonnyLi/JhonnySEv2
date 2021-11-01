using System;
using System.Globalization;

namespace JhonnySEv2.Helpers
{
    public static class CultureHelpers
    {
        public static int GetCurrentWeek()
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var currentWeek = cultureInfo.Calendar.GetWeekOfYear(DateTime.UtcNow, calendarWeekRule, firstDayOfWeek);

            return currentWeek;
        }

        public static string GetCurrentCulture()
        {
            var currentCulture = CultureInfo.CurrentCulture;
            
            return currentCulture.Name;
        }
    }
}
