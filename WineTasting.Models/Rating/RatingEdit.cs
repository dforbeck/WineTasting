using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Rating
{
    public class RatingEdit
    {
        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }

        public double GuestRating { get; set; }

        public string Comments { get; set; }
    }
}
