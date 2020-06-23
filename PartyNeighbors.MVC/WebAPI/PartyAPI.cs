﻿using Microsoft.AspNet.Identity;
using PartyNeighbors.Data;
using PartyNeighbors.Models.Party;
using PartyNeighbors.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartyNeighbors.MVC
{
    [Authorize]
    public class PartyAPI : ApiController
    {
        private PartyService CreatePartyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var partyService = new PartyService(userId);
            return partyService;
        }

        public IHttpActionResult Get()
        {
            PartyService partyService = CreatePartyService();
            var parties = partyService.GetParties();
            return Ok(parties);
        }

        public IHttpActionResult Post(PartyCreate partyToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePartyService();

            if (!service.CreateParty(partyToCreate))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PartyEdit partyToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePartyService();

            if (!service.EditParty(partyToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePartyService();

            if (!service.DeleteParty(id))
                return InternalServerError();

            return Ok();
        }
    }
}