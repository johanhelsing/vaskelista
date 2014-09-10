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
        public TaskEditViewModel(ScheduleElement s) {
            ScheduleElementId = s.ScheduleElementId;
            Name = s.Activity.Name;
            Description = s.Activity.Description;
            RoomId = s.Activity.RoomId;
            Start = s.Start;
            Monday = s.Days.HasFlag(Models.Weekday.Monday);
            Tuesday = s.Days.HasFlag(Models.Weekday.Tuesday);
            Wednesday = s.Days.HasFlag(Models.Weekday.Wednesday);
            Thursday = s.Days.HasFlag(Models.Weekday.Thursday);
            Friday = s.Days.HasFlag(Models.Weekday.Friday);
            Saturday = s.Days.HasFlag(Models.Weekday.Saturday);
            Sunday = s.Days.HasFlag(Models.Weekday.Sunday);
        }

        [Required]
        public Int32 ScheduleElementId { get; set; }

        public void ApplyChanges(ScheduleElement scheduleElement)
        {
            scheduleElement.Activity.Name = Name;
            scheduleElement.Start = Start;
            scheduleElement.Activity.RoomId = RoomId;
            scheduleElement.Days = WeekdayHelpers.FromBooleans(Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday);
        }
    }
}