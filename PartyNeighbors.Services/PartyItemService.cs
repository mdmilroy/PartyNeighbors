using PartyNeighbors.Data;
using PartyNeighbors.Models.PartyItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Services
{
    public class PartyItemService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public PartyItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePartyItem(PartyItemCreate partyItemToCreate)
        {
            var entity = new PartyItem
            {
                Name = partyItemToCreate.Name,
                Price = partyItemToCreate.Price
            };

            _db.PartyItems.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<PartyItemListItem> GetPartyItems()
        {
            var query = _db.PartyItems.Select(pi => new PartyItemListItem
            {
                Name = pi.Name,
            });

            return query.ToArray();
        }

        public bool EditPartyItem(PartyItemEdit partyItemToEdit)
        {
            var entity = _db.PartyItems.Single(p => p.PartyItemId == partyItemToEdit.Id);

            entity.Name = partyItemToEdit.Name;
            entity.Price = partyItemToEdit.Price;

            return _db.SaveChanges() == 1;
        }

        public bool DeletePartyItem(int id)
        {
            var entity = _db.PartyItems.Single(p => p.PartyItemId == id);

            _db.PartyItems.Remove(entity);
            return _db.SaveChanges() == 1;
        }

    }
}
