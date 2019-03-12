using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Models.Rating
{
    public class RatingDetail
    {
        public int RatingId { get; set; }

        [Display(Name = "My Point Rating")]
        public double GuestRating { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
