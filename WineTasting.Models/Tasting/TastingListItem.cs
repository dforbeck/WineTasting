using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;

namespace WineTasting.Models.Tasting
{
    public class TastingListItem
    {       
        public int TastingId { get; set; }
        public DateTime TastingDate { get; set; }
        public string Title { get; set; }
        public string Host { get; set; }
        public WineType TypeOfWine { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
