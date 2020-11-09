using iRoloDex.Data;
using iRoloDex.Data.Entities;
using iRoloDex.Models.OwnerModels;
using iRoloDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace iRoloDex.WebAPI.Controllers
{
    [RoutePrefix("api/owner")]

    [Authorize]
    public class OwnerController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

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
        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = ownerService.Get();
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

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteOwner([FromUri] int id)
        {
            var service = CreateOwnerService();

            if (!service.DeleteOwner(id))
                return InternalServerError();

            return Ok();
        }
    }
}