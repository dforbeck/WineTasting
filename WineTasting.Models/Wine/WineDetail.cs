using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Wine
{
    public class WineDetail
    {
        public int WineId { get; set; }
        public Guid OwnerId { get; set; }
        public int TastingId { get; set; }
        
        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        public string Brand { get; set; }
        public string SubBrand { get; set; }

        [Display(Name = "Wine Varietal")]
        public WineType WineVarietal { get; set; }

        public string Region { get; set; }
        public int Year { get; set; }

        [Display(Name = "Tasting Code")]
        public TastingCode CodeForTasting { get; set; }

        public DateTimeOffset CreatedUtc
        { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
