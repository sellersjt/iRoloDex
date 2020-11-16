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
    [RoutePrefix("api/Relationship")]
    public class RelationshipController : ApiController
    {
        /// <summary>
        /// Returns all available relationships. 
        /// </summary>
        /// <param name="id">The ID requires an integer argument.</param>
        /// <returns>Returns all available relationships.</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            RelationshipService relationshipService = CreateRelationshipService();

            var relationships = relationshipService.GetRelationship();

            return Ok(relationships);
        }

        /// <summary>
        /// Returns Relationship by the RelationshipId 
        /// </summary>
        /// <param name="id">The ID requires an integer argument.</param>
        /// <returns>Returns relationship by ID.</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            RelationshipService relationshipService = CreateRelationshipService();

            var relationship = relationshipService.GetRelationshipById(id);

            return Ok(relationship);
        }

        /// <summary>
        /// Creates new Relationship
        /// </summary>
        /// <param name="id">The ID requires an integer argument.</param>
        /// <returns>Creates new relationship.</returns>
        [HttpPost]
        public IHttpActionResult Post(RelationshipCreate relationship)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateRelationshipService();

            if (!service.CreateRelationship(relationship)) return InternalServerError();
            return Ok();
        }

        /// <summary>
        /// Edits Relationship by the RelationshipId 
        /// </summary>
        /// <param name="id">The ID requires an integer argument.</param>
        /// <returns>Edits relationship by ID.</returns>
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

        /// <summary>
        /// Deletes Relationship by the RelationshipId 
        /// </summary>
        /// <param name="id">The ID requires an integer argument.</param>
        /// <returns>Deletes relationship by ID.</returns>
        [HttpDelete]
        [Route("{id}")]
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