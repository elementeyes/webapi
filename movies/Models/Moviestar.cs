using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Moviestar
    {
        public Moviestar()
        {
            Starsin = new HashSet<Starsin>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Starsin> Starsin { get; set; }
    }
}
