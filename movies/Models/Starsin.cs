using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Starsin
    {
        public string Movietitle { get; set; }
        public int Movieyear { get; set; }
        public string Starname { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Moviestar StarnameNavigation { get; set; }
    }
}
