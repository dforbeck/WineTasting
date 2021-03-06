﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingEdit
    {
        public int TastingId { get; set; }
        public Guid OwnerId { get; set; }

        [Display(Name = "Tasting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        [Display(Name = "Event Title")]
        public string Title { get; set; }

        [Display(Name = "Host Name")]
        public string Host { get; set; }
    }
}
