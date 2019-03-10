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
        public string Brand { get; set; }
        public string SubBrand { get; set; }

        [Display(Name = "Wine Varietal")]
        public Varietal WineVarietal { get; set; }

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