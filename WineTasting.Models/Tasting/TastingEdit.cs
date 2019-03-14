using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingEdit
    {
        [Display(Name = "Tasting Date")]
        [DataType(DataType.Date)]
        public DateTimeOffset TastingDate { get; set; }

        [Display(Name = "Event Title")]
        public string Title { get; set; }

        public string Host { get; set; }
    }
}
