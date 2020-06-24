using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Neighborhood
{
    public class NeighborhoodCreate
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int ZipCode { get; set; }
    }
}
