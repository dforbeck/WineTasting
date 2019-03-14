using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Data
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public Guid OwnerId { get; set; }
        public int TastingId { get; set; } //foreign key
        public int WineId { get; set; }

        public double GuestRating { get; set; }
        public string Comments { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual Tasting Tasting { get; set; } //virtual references
        public virtual Wine Wine { get; set; }
    }
}
