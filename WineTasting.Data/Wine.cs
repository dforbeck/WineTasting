using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Data
{
    public enum WineType {[Display(Name = "Cabernet Sauvignon")] CabernetSauvignon, Zinfandel, Merlot, [Display(Name = "Pinot Noir")] PinotNoir, Malbec, Syrah}

    public enum BlindTastingCode {A,B,C,D,E,F,G,H,I,J,K,L,M}

    public class Wine
    {
        [Key]
        public int WineId { get; set; }
        public Guid OwnerId { get; set; }
        public int TastingId { get; set; } //foreign key

        [Required]
        public string Brand { get; set; }

        public string SubBrand { get; set; }

        [Required]
        [Display(Name = "Wine Varietal")]
        public WineType WineVarietal { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public int Year { get; set; }

        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc
        { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public double OverallRating { get; set; }

        public virtual Tasting Tasting { get; set; } //virtual references
    }

}
