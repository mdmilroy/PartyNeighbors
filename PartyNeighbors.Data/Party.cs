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
        public int Id { get; set; }
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
        public List<Resident> Guests { get; set; }
        public int PartyItemId { get; set; }
        public List<PartyItem> PartyItems { get; set; }
    }
}
