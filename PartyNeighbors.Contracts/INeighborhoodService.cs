using PartyNeighbors.Models.Neighborhood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Contracts
{
    public interface INeighborhoodService
    {
        bool CreateNeighborhood(NeighborhoodCreate neighborhoodToCreate);
        IEnumerable<NeighborhoodListItem> GetNeighborhoods();
        NeighborhoodDetail GetNeighborhoodById(int id);
        bool EditNeighborhood(NeighborhoodEdit neighborhoodToEdit);
        bool DeleteNeighborhood(int id);
    }
}
