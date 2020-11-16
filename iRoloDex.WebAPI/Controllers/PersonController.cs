using iRoloDex.Data;
using iRoloDex.Models.PersonModels;
using iRoloDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace iRoloDex.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/person")]
    public class PersonController : ApiController
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private PersonService CreatePersonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnerService(userId);
            var personService = new PersonService(ownerService.GetOwnerId().OwnerId);
            return personService;
        }
        /// <summary>
        /// This command will create a person record in the persons table of the iRoloDex database for the current owner.
        /// </summary>
        /// <param name="person">The parameters required for this request are listed below.</param>
        /// <returns>Running this endpoint will return a 200 response and a '1' to indicate a person record was successfully created.</returns>
        public IHttpActionResult Post(PersonCreate person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.CreatePerson(person))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// This command will display all the Persons an owner has created and that exist in the persons table of the iRoloDex database.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            PersonService personService = CreatePersonService();
            var persons = personService.GetPersons();
            return Ok(persons);
        }
        /// <summary>
        /// This command will retrieve a single person record by it's ID from the persons table in the iRoloDex database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            PersonService personService = CreatePersonService();
            var person = personService.GetPersonById(id);
            return Ok(person);
        }

        /// <summary>
        /// This command will update a person in the persons table of the iRoloDex database
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.UpdatePerson(person))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// This command will delete a person from the persons table in the iRoloDex database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePersonService();
            if (!service.DeletePerson(id))
                return InternalServerError();
            return Ok();
        }
    }
}