using PartyNeighbors.Contracts;
using PartyNeighbors.Data;
using PartyNeighbors.Models.Party;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Services
{
    public class PartyService : IPartyService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public PartyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateParty(PartyCreate partyToCreate)
        {
            var entity = new Party()
            {
                PartyName = partyToCreate.PartyName,
                NeighborhoodId = partyToCreate.NeighborhoodId,
                LocationId = partyToCreate.LocationId,
                PartyTime = partyToCreate.PartyTime,
                HostId = _userId.ToString(),
                Capacity = partyToCreate.Capacity,
                CategoryId = partyToCreate.CategoryId
            };

            _db.Parties.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<PartyListItem> GetParties()
        {
            var host = _db.Residents.Find(_userId.ToString());
            var query = _db.Parties.Select(p => new PartyListItem
            {
                Id = p.PartyId,
                Name = p.PartyName,
                Neighborhood = p.Neighborhood.Name,
                Location = p.Location.Name,
                PartyTime = p.PartyTime,
                Host = host.FullName,
                Category = p.Category.Name,
                Capacity = p.Capacity
            });
            return query.ToList();
        }

        public PartyDetail GetPartyById(int id)
        {
            var host = _db.Residents.Find(_userId.ToString());
            var entity = _db.Parties.Single(p => p.PartyId == id);

            return new PartyDetail
            {
                Name = entity.PartyName,
                Neighborhood = entity.Neighborhood.Name,
                LocationId = entity.LocationId,
                PartyTime = entity.PartyTime,
                Host = host.FullName,
                Capacity = entity.Capacity,
                Category = entity.Category.Name,
            };
        }

        public bool EditParty(PartyEdit partyToEdit)
        {
            var entity = _db.Parties.Single(p => p.PartyId == partyToEdit.Id);

            entity.PartyName = partyToEdit.Name;
            entity.NeighborhoodId = partyToEdit.NeighborhoodId;
            entity.LocationId = partyToEdit.LocationId;
            entity.PartyTime = partyToEdit.PartyTime;
            entity.HostId = partyToEdit.HostId;
            entity.Capacity = partyToEdit.Capacity;
            entity.CategoryId = partyToEdit.CategoryId;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteParty(int id)
        {
            var entity = _db.Parties.Single(p => p.PartyId == id);
            _db.Parties.Remove(entity);
            return _db.SaveChanges() == 1;
        }
    }
}
