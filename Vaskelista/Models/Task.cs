using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vaskelista.Models
{
    public class Task
    {
        [Required]
        public virtual Activity Activity { get; set; }

        public DateTime Start { get; set; }

        public bool Finished { get; set; }
    }
}
