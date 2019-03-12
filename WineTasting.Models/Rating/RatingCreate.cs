using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Models.Rating
{
    public class RatingCreate
    {
        public Guid OwnerId { get; set; }

        [Required]
        public double GuestRating { get; set; }

        [MaxLength(8000)]
        public string Comments { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
