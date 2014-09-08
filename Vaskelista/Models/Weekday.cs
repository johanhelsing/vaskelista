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
    }
}
