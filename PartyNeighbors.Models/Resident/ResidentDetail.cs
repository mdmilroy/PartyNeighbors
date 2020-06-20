using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Models.Resident
{
    public class ResidentDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
        public int NeighborhoodId { get; set; }
        public int PartyItemId { get; set; }
    }
}
