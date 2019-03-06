using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingCreate
    {
        [Required]
        [Display(Name = "Tasting Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime TastingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTimeOffset TastingDate { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string Title { get; set; }

        [Required]
        public string Host { get; set; }

        [Display(Name = "Type of Wine")]
        public WineType TypeOfWine { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
