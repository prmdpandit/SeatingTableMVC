using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeatingTabels.Models
{
    public partial class PersonVM
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Nullable<int> ReqNoOfSheat { get; set; }
    }
}
