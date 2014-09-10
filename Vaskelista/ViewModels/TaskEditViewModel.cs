using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vaskelista.Models;

namespace Vaskelista.ViewModels
{
    public class TaskEditViewModel : TaskCreateViewModel
    {
        public TaskEditViewModel() { }
        public TaskEditViewModel(Activity t) {
            ActivityId = t.ActivityId;
            Name = t.Name;
            Description = t.Description;
            Start = t.ScheduleElement.Start;
            RoomId = t.RoomId;
            Monday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Monday);
            Tuesday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Tuesday);
            Wednesday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Wednesday);
            Thursday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Thursday);
            Friday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Friday);
            Saturday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Saturday);
            Sunday = t.ScheduleElement.Days.HasFlag(Models.Weekday.Sunday);
        }

        [Required]
        public Int32 ActivityId { get; set; }

        public void ApplyChanges(Activity task)
        {
            task.Name = Name;
            task.ScheduleElement.Start = Start;
            task.RoomId = RoomId;
            task.ScheduleElement.Days = WeekdayHelpers.FromBooleans(Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday);
        }
    }
}