using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vaskelista.Models;

namespace Vaskelista.ViewModels
{
    public class TaskIndexViewModel
    {
        private ScheduleElement ScheduleElement { get; set; }

        public Int32 ScheduleElementId { get { return ScheduleElement.ScheduleElementId; }}

        [Display(Name = "Rom")]
        public string RoomName { get { return ScheduleElement.Activity.Room.Name; }}

        [Display(Name = "Dager")]
        public string Days { get { return ScheduleElement.Days.ToString(); } }

        [Display(Name = "Oppgavenavn")]
        public string Name { get { return ScheduleElement.Activity.Name;  } }

        public TaskIndexViewModel() { }
        public TaskIndexViewModel(ScheduleElement s) {
            ScheduleElement = s;
        }

    }
}