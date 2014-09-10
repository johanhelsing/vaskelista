using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vaskelista.Models
{
    [Flags]
    public enum Weekday
    {
        NoDay = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    public static class WeekdayHelpers {
        public static Weekday FromBooleans(bool mon, bool tue, bool wed, bool thu, bool fri, bool sat, bool sun)
        {
            return
                (mon ? Weekday.Monday    : 0) |
                (tue ? Weekday.Tuesday   : 0) |
                (wed ? Weekday.Wednesday : 0) |
                (thu ? Weekday.Thursday  : 0) |
                (fri ? Weekday.Friday    : 0) |
                (sat ? Weekday.Saturday  : 0) |
                (sun ? Weekday.Sunday    : 0);
        }
        public static List<DayOfWeek> ToDayOfWeekList(this Weekday weekday)
        {
            var days = new List<DayOfWeek>();
            if (weekday.HasFlag(Weekday.Monday)) days.Add(DayOfWeek.Monday);
            if (weekday.HasFlag(Weekday.Tuesday)) days.Add(DayOfWeek.Tuesday);
            if (weekday.HasFlag(Weekday.Wednesday)) days.Add(DayOfWeek.Wednesday);
            if (weekday.HasFlag(Weekday.Thursday)) days.Add(DayOfWeek.Thursday);
            if (weekday.HasFlag(Weekday.Friday)) days.Add(DayOfWeek.Friday);
            if (weekday.HasFlag(Weekday.Saturday)) days.Add(DayOfWeek.Saturday);
            if (weekday.HasFlag(Weekday.Sunday)) days.Add(DayOfWeek.Sunday);
            return days;
        }
        public static Weekday ToWeekday(this DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday: return Weekday.Monday;
                case DayOfWeek.Tuesday: return Weekday.Tuesday;
                case DayOfWeek.Wednesday: return Weekday.Wednesday;
                case DayOfWeek.Thursday: return Weekday.Thursday;
                case DayOfWeek.Friday: return Weekday.Friday;
                case DayOfWeek.Saturday: return Weekday.Saturday;
                case DayOfWeek.Sunday: return Weekday.Sunday;
                default: return Weekday.NoDay;
            }
        }

    }
}
