using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
