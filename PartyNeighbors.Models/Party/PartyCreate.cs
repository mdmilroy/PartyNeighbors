using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Party
{
    public class PartyCreate
    {
        public string Name { get; set; }
        public int NeighborhoodId { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset PartyTime { get; set; }
        public int HostId { get; set; }
        public string Category { get; set; }
        public int Capacity { get; set; }
    }
}
