using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingDetail
    {
        [Display(Name = "Tasting Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset TastingDate { get; set; }

        [Display(Name = "Event Title")]
        public string Title { get; set; }

        [Display(Name = "Host Name")]
        public string Host { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
