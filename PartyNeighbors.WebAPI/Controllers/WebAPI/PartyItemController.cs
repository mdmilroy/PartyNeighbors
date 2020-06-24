using Microsoft.AspNet.Identity;
using PartyNeighbors.Models.PartyItem;
using PartyNeighbors.Services;
using System;
using System.Web.Http;

namespace PartyNeighbors.WebAPI.WebAPI
{
    [Authorize]
    public class PartyItemController : ApiController
    {
        private PartyItemService CreatePartyItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var partyItemService = new PartyItemService(userId);
            return partyItemService;
        }

        public IHttpActionResult Get()
        {
            PartyItemService partyItemService = CreatePartyItemService();
            var partyItems = partyItemService.GetPartyItems();
            return Ok(partyItems);
        }

        public IHttpActionResult Post(PartyItemCreate partyItemToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePartyItemService();

            if (!service.CreatePartyItem(partyItemToCreate))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PartyItemEdit partyItemToEdit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePartyItemService();

            if (!service.EditPartyItem(partyItemToEdit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePartyItemService();

            if (!service.DeletePartyItem(id))
                return InternalServerError();

            return Ok();
        }
    }
}