using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Wine
{
    public class WineEdit
    {
        public int WineId { get; set; }
        public int TastingId { get; set; }

        [Display(Name = "Tasting Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset TastingDate { get; set; }

        public string Brand { get; set; }
        public string SubBrand { get; set; }

        [Display(Name = "Wine Varietal")]
        public WineType WineVarietal { get; set; }

        public string Region { get; set; }
        public int Year { get; set; }

        [Display(Name = "Blind Tasting Code")]
        public BlindTastingCode CodeForBlindTasting { get; set; }
    }
}
