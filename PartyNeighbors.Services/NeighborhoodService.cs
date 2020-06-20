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
    public class NeighborhoodService
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
                State = neighborhoodToCreate.State,
                ZipCode = neighborhoodToCreate.ZipCode
            };

            _db.Neighborhoods.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<NeighborhoodListItem> GetNeighborhoods()
        {
            var query = _db.Neighborhoods.Select(n => new NeighborhoodListItem
            {
                Id = n.Id,
                City = n.City,
                Name = n.Name
            });

            return query.ToArray();
        }
        
        public NeighborhoodDetail GetNeighborhoodById(int id)
        {
            var entity = _db.Neighborhoods.Single(n => n.Id == id);

            return new NeighborhoodDetail
            {
                Name = entity.Name,
                City = entity.City,
                State = entity.State,
                ZipCode = entity.ZipCode
            };
        }

        public bool EditNeighborhood(NeighborhoodEdit neighborhoodToEdit)
        {
            var entity = _db.Neighborhoods.Single(n => n.Id == neighborhoodToEdit.Id);

            entity.Name = neighborhoodToEdit.Name;
            entity.City = neighborhoodToEdit.City;
            entity.State = neighborhoodToEdit.State;
            entity.ZipCode = neighborhoodToEdit.ZipCode;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteNeighborhood(int id)
        {
            var entity = _db.Neighborhoods.Single(n => n.Id == id);

            _db.Neighborhoods.Remove(entity);
            return _db.SaveChanges() == 1;
        }

    }
}
