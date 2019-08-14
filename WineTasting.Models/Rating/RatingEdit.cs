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
        public int RatingId { get; set; }
        public Guid OwnerId { get; set; }
        public int WineId { get; set; }

        [Display(Name = "Blind Tasting Code")]
        public TastingCode CodeForTasting { get; set; }

        public double GuestRating { get; set; }

        public string Comments { get; set; }
    }
}
