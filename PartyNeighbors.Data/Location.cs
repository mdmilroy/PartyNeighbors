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
        [Display(Name = "Id")]
        public int LocationId { get; set; }
        [Required]
        [Display(Name = "Part of Neighborhood")]
        public string Name { get; set; } // e.g. community center, pool, park, etc.

        public ICollection<Neighborhood> Neighborhoods { get; set; }
        public ICollection<Party> Parties { get; set; }
    }
}
