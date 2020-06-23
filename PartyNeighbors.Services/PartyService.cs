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
    public class PartyService
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
                Name = partyToCreate.Name,
                NeighborhoodId = partyToCreate.NeighborhoodId,
                LocationId = partyToCreate.LocationId,
                PartyTime = partyToCreate.PartyTime,
                HostId = _userId.ToString(),
                Capacity = partyToCreate.Capacity,
                CategoryId = partyToCreate.Category
            };

            _db.Parties.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<PartyListItem> GetParties()
        {
            var query = _db.Parties.Select(p => new PartyListItem
            {
                Id = p.PartyId,
                Name = p.Name,
                Neighborhood = p.Neighborhood.Name,
                PartyTime = p.PartyTime,
                Category = p.Category.Name,
                Capacity = p.Capacity
            });
            return query.ToArray();
        }

        public PartyDetail GetPartById(int id)
        {
            var entity = _db.Parties.Single(p => p.PartyId == id);

            return new PartyDetail
            {
                Name = entity.Name,
                Neighborhood = entity.Neighborhood.Name,
                LocationId = entity.LocationId,
                PartyTime = entity.PartyTime,
                HostId = entity.HostId,
                Capacity = entity.Capacity,
                Category = entity.Category.Name,
                Guests = entity.Residents.Select(e => e.FullName),
                PartyItems = entity.PartyItems.Select(e => e.Name)
            };
        }

        public bool EditParty(PartyEdit partyToEdit)
        {
            var entity = _db.Parties.Single(p => p.PartyId == partyToEdit.Id);

            entity.Name = partyToEdit.Name;
            entity.NeighborhoodId = partyToEdit.NeighborhoodId;
            entity.LocationId = partyToEdit.LocationId;
            entity.PartyTime = partyToEdit.PartyTime;
            entity.HostId = partyToEdit.HostId;
            entity.Capacity = partyToEdit.Capacity;
            entity.CategoryId = partyToEdit.Category;

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
