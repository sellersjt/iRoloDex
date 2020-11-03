using iRoloDex.Models.OwnerModels;
using iRoloDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace iRoloDex.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Owner")]
    public class OwnerController : ApiController
    {
        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnerService(userId);
            return ownerService;
        }

        [HttpPost]
        public IHttpActionResult CreateOwner(OwnerCreate owner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OwnerService ownerService = CreateOwnerService();

            if (!ownerService.CreateOwner(owner))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateOwner(OwnerUpdate owner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            OwnerService ownerService = CreateOwnerService();

            if (!ownerService.UpdateOwner(owner))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetOwners()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = ownerService.GetOwners();
            return Ok(owners);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetOwnerById(int id)
        {
            OwnerService ownerService = CreateOwnerService();
            var owner = ownerService.GetOwnerById(id);
            return Ok(owner);
        }
    }
}