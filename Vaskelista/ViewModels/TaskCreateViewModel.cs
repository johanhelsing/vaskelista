using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.ViewModels
{
    public class TaskCreateViewModel
    {
        [Required]
        [Display(Name = "Oppgavenavn")]
        public string Name { get; set; }
        
        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Startdato")]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "Rom")]
        public Int32? RoomId { get; set; }

        [Display(Name = "Mandag")]
        public bool Monday { get; set; }

        [Display(Name = "Tirsdag")]
        public bool Tuesday { get; set; }

        [Display(Name = "Onsdag")]
        public bool Wednesday { get; set; }

        [Display(Name = "Torsdag")]
        public bool Thursday { get; set; }

        [Display(Name = "Fredag")]
        public bool Friday { get; set; }

        [Display(Name = "Lørdag")]
        public bool Saturday { get; set; }

        [Display(Name = "Søndag")]
        public bool Sunday { get; set; }

    }
}