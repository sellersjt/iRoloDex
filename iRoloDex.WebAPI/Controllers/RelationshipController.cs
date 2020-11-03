using iRoloDex.Models;
using iRoloDex.Models.RelationshipModels;
using iRoloDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace iRoloDex.WebAPI.Controllers
{
    [Authorize]
    public class RelationshipController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            RelationshipService relationshipService = CreateRelationshipService();

            var relationships = relationshipService.GetRelationship();

            return Ok(relationships);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            RelationshipService relationshipService = CreateRelationshipService();

            var relationship = relationshipService.GetRelationshipById(id);

            return Ok(relationship);
        }

        [HttpPost]
        public IHttpActionResult Post(RelationshipCreate relationship)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateRelationshipService();

            if (!service.CreateRelationship(relationship)) return InternalServerError();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(RelationshipEdit relationship)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRelationshipService();

            if (!service.UpdateRelationship(relationship))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRelationshipService();

            if (!service.DeleteRelationship(id))
                return InternalServerError();

            return Ok();
        }

        private RelationshipService CreateRelationshipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var relationshipService = new RelationshipService(userId);
            return relationshipService;
        }
    }
}