using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Vaskelista.Models
{
    public class ScheduleElement
    {
        public Int32 ScheduleElementId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        public Weekday Days { get; set; }

        [Required]
        public virtual Activity Activity { get; set; }
        public Int32 ActivityId { get; set; }

        public IEnumerable<Task> CreateTasksForWeek(DateTime week)
        {
            var tasks = new List<Task>();
            DateTime weekStart = week.StartOfWeek(DayOfWeek.Monday);
            for (var day = weekStart; (day - weekStart).Days < 7; day = day.AddDays(1))
            {
                if (IncludesDay(day)) tasks.Add(new Task {
                    ActivityId = Activity.ActivityId,
                    Activity = Activity,
                    Start = day,
                    Finished = false
                });
            }
            return tasks;
        }

        public bool IncludesDay(DateTime day)
        {
            return (Days & day.DayOfWeek.ToWeekday()) != 0;
        }
    }
}
