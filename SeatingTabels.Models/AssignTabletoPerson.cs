using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeatingTabels.Models
{
  public  class AssignTabletoPersonVM
    {
        public int Id { get; set; }
        public long TableId { get; set; }
        public long PersonId { get; set; }
    }
}
