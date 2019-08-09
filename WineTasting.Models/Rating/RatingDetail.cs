using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Rating
{
    public class RatingDetail
    {
        public int RatingId { get; set; }
        public Guid OwnerId { get; set; }
        public int WineId { get; set; }

        [Display(Name = "Blind Tasting Code")]
        public TastingCode CodeForTasting { get; set; }

        [Display(Name = "My Point Rating")]
        public double GuestRating { get; set; }

        public string Comments { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
