using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Data
{
    
    public class Tasting
    {
        public enum WineType { [Display(Name ="Cabernet Sauvignon")] CabernetSauvignon, Zinfandel, Merlot, [Display(Name="Pinot Noir")]PinotNoir, Malbec }

        [Key]
        public int TastingId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        public string LocationSpecs { get; set; }

        [Required]
        [Display(Name ="Wine Type")]
        public WineType TypeOfWine { get; set; }

        [Required]
        [Display(Name ="Tasting Date")]
        public DateTime TastingDate { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc
        { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
