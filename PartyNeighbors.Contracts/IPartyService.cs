using PartyNeighbors.Models.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Contracts
{
    public interface IPartyService
    {
        bool CreateParty(PartyCreate neighborhoodToCreate);
        IEnumerable<PartyListItem> GetParties();
        PartyDetail GetPartyById(int id);
        bool EditParty(PartyEdit neighborhoodToEdit);
        bool DeleteParty(int id);
    }
}
