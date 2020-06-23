using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Resident
{
    public class ResidentListItem
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int NeighborhoodId { get; set; }
    }
}
