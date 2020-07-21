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
        bool CreateParty(PartyCreate partyToCreate);
        IEnumerable<PartyListItem> GetParties();
        PartyDetail GetPartyById(int id);
        bool EditParty(PartyEdit partyToEdit);
        bool DeleteParty(int id);
    }
}
