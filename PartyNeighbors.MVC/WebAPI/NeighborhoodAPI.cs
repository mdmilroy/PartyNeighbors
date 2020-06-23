using Microsoft.AspNet.Identity;
using PartyNeighbors.Models.Neighborhood;
using PartyNeighbors.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NeighborhoodNeighbors.MVC.WebAPI
{
    [Authorize]
    public class NeighborhoodAPI : ApiController
    {
        private NeighborhoodService CreateNeighborhoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var neighborhoodService = new NeighborhoodService(userId);
            return neighborhoodService;
        }

        public IHttpActionResult Get()
        {
            NeighborhoodService neighborhoodService = CreateNeighborhoodService();
            var neighborhoods = neighborhoodService.GetNeighborhoods();
            return Ok(neighborhoods);
        }

        public IHttpActionResult Post(NeighborhoodCreate neighborhoodToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNeighborhoodService();

            if (!service.CreateNeighborhood(neighborhoodToCreate))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(NeighborhoodEdit neighborhoodToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNeighborhoodService();

            if (!service.EditNeighborhood(neighborhoodToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateNeighborhoodService();

            if (!service.DeleteNeighborhood(id))
                return InternalServerError();

            return Ok();
        }
    }
}