﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingCreate
    {
        public int TastingId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "Tasting Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset TastingDate { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string Title { get; set; }

        [Required]
        public string Host { get; set; }
    }
}
