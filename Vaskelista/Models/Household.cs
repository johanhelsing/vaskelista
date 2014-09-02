using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Household
    {
        public Int32 HouseholdId { get; set; }

        [Required]
        [Display(Name = "Kodeord")]
        public string Token { get; set; }
    }
}