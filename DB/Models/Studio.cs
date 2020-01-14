using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Studio
    {
        public Studio()
        {
            Movie = new HashSet<Movie>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public int? Presc { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
