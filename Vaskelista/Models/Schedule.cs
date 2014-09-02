using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Schedule
    {
        public Int32 ScheduleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}