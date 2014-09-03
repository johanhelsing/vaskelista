using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Task
    {
        public Int32 TaskId { get; set; }

        [Required]
        public virtual Household Household { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        [Required]
        public Weekday Days { get; set; }

    }
}