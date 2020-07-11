using PartyNeighbors.Contracts;
using PartyNeighbors.Data;
using PartyNeighbors.Models.Resident;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PartyNeighbors.Services
{
    public class ResidentService : IResidentService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _db = new ApplicationDbContext();

        public ResidentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateResident(ResidentCreate residentToCreate)
        {
            var entity = new Resident
            {
                FirstName = residentToCreate.FirstName,
                LastName = residentToCreate.LastName,
                FullName = residentToCreate.FirstName + " " + residentToCreate.LastName,
                NeighborhoodId = residentToCreate.NeighborhoodId,
                ResidentId = _userId.ToString()
            };

            _db.Residents.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<ResidentListItem> GetResidents()
        {
            var query = _db.Residents.Select(r => new ResidentListItem
            {
                Id = r.ResidentId,
                FullName = r.FullName,
                Neighborhood = r.Neighborhood.Name
            });

            return query.ToArray();
        }

        public ResidentDetail GetResidentById(string id)
        {
            var entity = _db.Residents.Single(r => r.ResidentId == id);

            return new ResidentDetail
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Neighborhood = entity.Neighborhood.Name,
            };
        }

        public bool EditResident(ResidentEdit residentToEdit)
        {
            var entity = _db.Residents.Single(r => r.ResidentId == residentToEdit.Id);

            entity.FirstName = residentToEdit.FirstName;
            entity.LastName = residentToEdit.LastName;
            entity.FullName = residentToEdit.FirstName + " " + residentToEdit.LastName;
            entity.NeighborhoodId = residentToEdit.NeighborhoodId;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteResident(string id)
        {
            var entity = _db.Residents.Single(r => r.ResidentId == id);
            _db.Residents.Remove(entity);
            return _db.SaveChanges() == 1;
        }
    }
}
