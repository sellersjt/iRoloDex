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

        /// <summary>
        /// Creates a New Owner
        /// </summary>
        /// <param name="owner">The owner requires a string of characters.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates an Owner's Info
        /// </summary>
        /// <param name="owner">Requires Owner Id, Name, and Email Address</param>
        /// <returns>Called by passing the Owner's Id and requires a name and an email address.</returns>
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

        /// <summary>
        /// Gets a List of All Owners
        /// </summary>
        /// <returns>Returns a list of all owner names and Ids.</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = ownerService.Get();
            return Ok(owners);
        }

        /// <summary>
        /// Gets One Owner
        /// </summary>
        /// <param name="id">Requires Owner Id</param>
        /// <returns>Returns the name and email address of one owner.</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetOwnerById(int id)
        {
            OwnerService ownerService = CreateOwnerService();
            var owner = ownerService.GetOwnerById(id);
            return Ok(owner);
        }

        /// <summary>
        /// Deletes an Owner
        /// </summary>
        /// <param name="id">Requires Owner Id</param>
        /// <returns>Deletes one owner by Owner Id.</returns>
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