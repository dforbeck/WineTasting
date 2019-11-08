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
        public int WineId { get; set; }
        public Guid OwnerId { get; set; }
        public int TastingId { get; set; }

        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        [Required]
        public string Brand { get; set; }

        public string SubBrand { get; set; }

        [Required]
        [Display(Name = "Wine Varietal")]
        public WineType WineVarietal { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        [Range(1800, 3000, ErrorMessage = "Must select from 1800-3000")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Tasting Code")]
        public TastingCode CodeForTasting { get; set; }
    }
}
