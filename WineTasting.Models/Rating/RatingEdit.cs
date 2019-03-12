using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Models.Rating
{
    public class RatingEdit
    {
        public int RatingId { get; set; }
        public double GuestRating { get; set; }

        public string Comments { get; set; }

    }
}
