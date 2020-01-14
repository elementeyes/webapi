using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Starsin = new HashSet<Starsin>();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public int? Length { get; set; }
        public string Incolor { get; set; }
        public string Studioname { get; set; }
        public int? Producerc { get; set; }

        public virtual Movieexec ProducercNavigation { get; set; }
        public virtual Studio StudionameNavigation { get; set; }
        public virtual ICollection<Starsin> Starsin { get; set; }
    }
}
