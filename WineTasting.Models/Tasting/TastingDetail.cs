using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingDetail
    {
        public int TastingId { get; set; }

        public string Title { get; set; }
        
        public string Host { get; set; }

        public WineType TypeOfWine { get; set; }

        public DateTimeOffset TastingDate { get; set; }

        public DateTimeOffset CreatedUtc
        { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
