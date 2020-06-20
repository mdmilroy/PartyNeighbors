using Microsoft.AspNet.Identity;
using PartyNeighbors.Models.Resident;
using PartyNeighbors.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResidentNeighbors.MVC.WebAPI
{
    [Authorize]
    public class ResidentAPI : ApiController
    {
        private ResidentService CreateResidentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var residentService = new ResidentService(userId);
            return residentService;
        }

        public IHttpActionResult Get()
        {
            ResidentService residentService = CreateResidentService();
            var residents = residentService.GetResidents();
            return Ok(residents);
        }

        public IHttpActionResult Post(ResidentCreate residentToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateResidentService();

            if (!service.CreateResident(residentToCreate))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ResidentEdit residentToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateResidentService();

            if (!service.EditResident(residentToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateResidentService();

            if (!service.DeleteResident(id))
                return InternalServerError();

            return Ok();
        }
    }
}