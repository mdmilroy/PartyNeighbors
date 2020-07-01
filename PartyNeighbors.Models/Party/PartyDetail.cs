using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Party
{
    public class PartyDetail
    {
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public int LocationId { get; set; }
        public DateTimeOffset PartyTime { get; set; }
        public string Host { get; set; }
        public int Capacity { get; set; }
        public string Category { get; set; }
    }
}
