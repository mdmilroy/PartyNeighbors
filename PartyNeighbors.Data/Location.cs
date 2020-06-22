using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string Name { get; set; } // e.g. community center, pool, park, etc.
    }
}
