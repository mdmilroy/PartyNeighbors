using PartyNeighbors.Contracts;
using PartyNeighbors.Data;
using PartyNeighbors.Models.Neighborhood;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Services
{
    public class NeighborhoodService : INeighborhoodService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public NeighborhoodService(Guid userId)
        {
            _userId = userId;
        }

        
        public bool CreateNeighborhood(NeighborhoodCreate neighborhoodToCreate)
        {
            var entity = new Neighborhood
            {
                Name = neighborhoodToCreate.Name,
                City = neighborhoodToCreate.City,
                StateId = neighborhoodToCreate.StateId,
                ZipCode = neighborhoodToCreate.ZipCode
            };

            _db.Neighborhoods.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<NeighborhoodListItem> GetNeighborhoods()
        {
            var query = _db.Neighborhoods.Select(n => new NeighborhoodListItem
            {
                Id = n.NeighborhoodId,
                City = n.City,
                Name = n.Name,
                State = n.State.StateName
            });

            return query.ToArray();
        }
        
        public NeighborhoodDetail GetNeighborhoodById(int id)
        {
            var entity = _db.Neighborhoods.Single(n => n.NeighborhoodId == id);

            return new NeighborhoodDetail
            {
                Name = entity.Name,
                City = entity.City,
                State = entity.State.StateName,
                ZipCode = entity.ZipCode,
                Locations = entity.Locations.Select(l => l.Name).ToList()
            };
        }

        public bool EditNeighborhood(NeighborhoodEdit neighborhoodToEdit)
        {
            var entity = _db.Neighborhoods.Single(n => n.NeighborhoodId == neighborhoodToEdit.Id);

            entity.Name = neighborhoodToEdit.Name;
            entity.City = neighborhoodToEdit.City;
            entity.StateId = neighborhoodToEdit.StateId;
            entity.ZipCode = neighborhoodToEdit.ZipCode;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteNeighborhood(int id)
        {
            var entity = _db.Neighborhoods.Single(n => n.NeighborhoodId == id);

            _db.Neighborhoods.Remove(entity);
            return _db.SaveChanges() == 1;
        }

        public bool AddLocation(NeighborhoodAddLocation locationToAdd)
        {
            var neighborhood = _db.Neighborhoods.Single(n => n.NeighborhoodId == locationToAdd.NeighborhoodId);
            var location = _db.Locations.Single(n => n.LocationId == locationToAdd.LocationId);
            neighborhood.Locations.Add(location);

            return _db.SaveChanges() == 1;
        }
    }
}
