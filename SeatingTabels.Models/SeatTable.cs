using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeatingTabels.Models
{
    public partial class TableVM
    {
        public long TableId { get; set; }
        public int TableNum { get; set; }
        public string Title { get; set; }
        public int NumberOfSeats { get; set; }
        public Nullable<long> PersonId { get; set; }
    }
}
