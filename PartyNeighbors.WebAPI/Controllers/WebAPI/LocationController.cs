using Microsoft.AspNet.Identity;
using PartyNeighbors.Models.Location;
using PartyNeighbors.Services;
using System;
using System.Web.Http;

namespace PartyNeighbors.WebAPI.WebAPI
{
    [Authorize]
    public class LocationController : ApiController
    {
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }

        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            return Ok(locations);
        }

        public IHttpActionResult Post(LocationCreate locationToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(locationToCreate))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LocationEdit locationToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.EditLocation(locationToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(id))
                return InternalServerError();

            return Ok();
        }
    }
}