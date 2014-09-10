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
        private Activity Activity { get; set; }

        public Int32 ActivityId { get { return Activity.ActivityId; }}

        [Display(Name = "Rom")]
        public string RoomName { get { return Activity.Room.Name; }}

        [Display(Name = "Dager")]
        public string Days { get { return Activity.ScheduleElement.Days.ToString(); } }

        [Display(Name = "Oppgavenavn")]
        public string Name { get { return Activity.Name;  } }

        public TaskIndexViewModel() { }
        public TaskIndexViewModel(Activity a) {
            Activity = a;
        }

    }
}