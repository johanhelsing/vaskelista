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
        public TaskEditViewModel(Task t) {
            TaskId       = t.TaskId;
            Name         = t.Name;
            Description  = t.Description;
            Start        = t.Start;
            RoomId       = t.RoomId;
            Monday       = t.Days.HasFlag(Models.Weekday.Monday);
            Tuesday      = t.Days.HasFlag(Models.Weekday.Tuesday);
            Wednesday    = t.Days.HasFlag(Models.Weekday.Wednesday);
            Thursday     = t.Days.HasFlag(Models.Weekday.Thursday);
            Friday       = t.Days.HasFlag(Models.Weekday.Friday);
            Saturday     = t.Days.HasFlag(Models.Weekday.Saturday);
            Sunday       = t.Days.HasFlag(Models.Weekday.Sunday);
        }

        [Required]
        public Int32 TaskId { get; set; }

        public void ApplyChanges(Task task)
        {
            task.Name = Name;
            task.Start = Start;
            task.RoomId = RoomId;
            task.Days = WeekdayHelpers.FromBooleans(Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday);
        }
    }
}