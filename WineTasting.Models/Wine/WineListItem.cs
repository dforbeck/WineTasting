﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Wine
{
    public class WineListItem
    {
        public int WineId { get; set; }
        public int TastingId { get; set; }

        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        public string Brand { get; set; }
        public string SubBrand { get; set; }

        [Display(Name = "Wine Varietal")]
        public WineType WineVarietal { get; set; }

        public string Region { get; set; }
        public int Year { get; set; }

        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
