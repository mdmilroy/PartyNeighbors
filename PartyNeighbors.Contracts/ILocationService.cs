using PartyNeighbors.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Contracts
{
    public interface ILocationService
    {
        bool CreateLocation(LocationCreate neighborhoodToCreate);
        IEnumerable<LocationListItem> GetLocations();
        LocationDetail GetLocationById(int id);
        bool EditLocation(LocationEdit neighborhoodToEdit);
        bool DeleteLocation(int id);
    }
}
