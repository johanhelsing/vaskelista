using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Room
    {
        public Int32 RoomId { get; set; }

        [Required]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }
    }
}