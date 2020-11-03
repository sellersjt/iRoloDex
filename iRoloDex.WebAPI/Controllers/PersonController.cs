using iRoloDex.Data;
using iRoloDex.Models.Person;
using iRoloDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iRoloDex.WebAPI.Controllers
{   [Authorize]
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

        
        public IHttpActionResult Post(PersonCreate person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePersonService();

            if (!service.CreatePerson(person))
                return InternalServerError();
            
            return Ok();
        }
        public IHttpActionResult Get()
        {
            PersonService personService = CreatePersonService();
            var persons = personService.GetPersons();
            return Ok(persons);
        }

        public IHttpActionResult Get(int id)
        {
            PersonService personService = CreatePersonService();
            var person = personService.GetPersonById(id);
            return Ok(person);
        }
     
        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePersonService();

            if (!service.UpdatePerson(person))
                return InternalServerError();
           
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePersonService();

            if (!service.DeletePerson(id))
                return InternalServerError();

            return Ok();
        }
    }
}
