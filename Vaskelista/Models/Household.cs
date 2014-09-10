using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Household
    {
        public Int32 HouseholdId { get; set; }

        [Required]
        [Display(Name = "Kodeord")]
        public string Token { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ScheduleElement> ScheduleElements { get; set; }

        public ICollection<Task> GetPlannedTasksForWeek(DateTime week)
        {
            var tasks = new List<Task>();
            foreach (var scheduleElement in ScheduleElements)
            {
                tasks.AddRange(scheduleElement.CreateTasksForWeek(week));
            }
            return tasks;
        }
    }
}