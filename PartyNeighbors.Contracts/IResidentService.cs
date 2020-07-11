using PartyNeighbors.Models.Resident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Contracts
{
    public interface IResidentService
    {
        bool CreateResident(ResidentCreate neighborhoodToCreate);
        IEnumerable<ResidentListItem> GetResidents();
        ResidentDetail GetResidentById(string id);
        bool EditResident(ResidentEdit neighborhoodToEdit);
        bool DeleteResident(string id);
    }
}
