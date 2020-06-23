using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Party
{
    public class PartyListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public DateTimeOffset PartyTime { get; set; }
        public int CategoryId { get; set; }
        public int Capacity { get; set; }
    }
}
