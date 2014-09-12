using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vaskelista.Models
{
    public class Task
    {
        public Int32 TaskId { get; set; }

        public virtual Activity Activity { get; set; }
        public Int32 ActivityId { get; set; }

        public DateTime Start { get; set; }

        public bool Finished { get; set; }
    }
}
