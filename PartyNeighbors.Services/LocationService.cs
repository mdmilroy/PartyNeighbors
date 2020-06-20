using PartyNeighbors.Data;
using PartyNeighbors.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Services
{
    public class LocationService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate locationToCreate)
        {
            var entity = new Location
            {
                Name = locationToCreate.Name
            };

            _db.Locations.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            var query = _db.Locations.Select(l => new LocationListItem
            {
                Id = l.Id,
                Name = l.Name
            });

            return query.ToArray();
        }

        public LocationDetail GetLocationById(int id)
        {
            var entity = _db.Locations.Single(l => l.Id == id);

            return new LocationDetail
            {
                Name = entity.Name
            };
        }

        public bool EditLocation(LocationEdit locationToEdit)
        {
            var entity = _db.Locations.Single(l => l.Id == locationToEdit.id);

            entity.Name = locationToEdit.Name;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteLocation(int id)
        {
            var entity = _db.Locations.Single(l => l.Id == id);

            _db.Locations.Remove(entity);
            return _db.SaveChanges() == 1;
        }
    }
}
