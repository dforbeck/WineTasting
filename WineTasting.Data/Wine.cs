﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Data
{
    public enum Varietal {[Display(Name = "Cabernet Sauvignon")] CabernetSauvignon, Zinfandel, Merlot, [Display(Name = "Pinot Noir")] PinotNoir, Malbec, Syrah}

    public enum BlindTastingCode {A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z}

    public class Wine
    {
        [Key]
        public int WineId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

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

        [Display(Name = "Code for Blind Tasting")]
        public BlindTastingCode CodeForBlindTasting { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc
        { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


        public virtual Tasting Tasting { get; set; }
        [Required]
        public int TastingId { get; set; }      
    }
}
