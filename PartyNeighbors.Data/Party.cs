using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Data
{
    public class Party
    {
        [Key]
        public int PartyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NeighborhoodId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public DateTimeOffset PartyTime { get; set; }
        [Required]
        public int HostId { get; set; }
        [Required]
        public int Capacity { get; set; }
        public int CategoryId { get; set; }
        public List<string> Guests { get; set; } // populate with Resident's Full Name
        public int PartyItemId { get; set; }
        public List<string> PartyItems { get; set; }
    }

}
