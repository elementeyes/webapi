using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Movieexec
    {
        public Movieexec()
        {
            Movie = new HashSet<Movie>();
        }

        public int Cert { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Networth { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
