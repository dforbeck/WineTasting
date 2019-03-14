using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Rating
{
    public class RatingCreate
    {
        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }

        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        [Required]
        public double GuestRating { get; set; }

        [MaxLength(8000)]
        public string Comments { get; set; }
    }
}
