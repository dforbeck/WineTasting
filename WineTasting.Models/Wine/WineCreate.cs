﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Wine
{
    public class WineCreate
    {

        [Required]
        public string Brand { get; set; }

        public string SubBrand { get; set; }

        [Required]
        [Display(Name = "Wine Varietal")]
        public Varietal WineVarietal { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
