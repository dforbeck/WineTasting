﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineTasting.Data
{
    public class Tasting
    {       
        [Key]
        public int TastingId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        //public DateTime TastingDate { get; set; }
        public DateTimeOffset TastingDate { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Host {get; set;}

 
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
