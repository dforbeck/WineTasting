using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Wine
{
    public class WineCreate
    {
        public Guid OwnerId { get; set; }
        public int WineId { get; set; }
        public int TastingId { get; set; }

        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        public string Brand { get; set; }

        public string SubBrand { get; set; }

        [Required]
        [Display(Name = "Wine Varietal")]
        public WineType WineVarietal { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }
    }
}
