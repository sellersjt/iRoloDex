using iRoloDex.Data.Entities;
using iRoloDex.Models.Household;
using iRoloDex.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace iRoloDex.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Household")]
    public class HouseholdController : ApiController
    {
        private HouseholdService CreateHouseholdService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            int ownerId = 1;
            var householdService = new HouseholdService(ownerId);
            return householdService;
        }

        // get  api/Household
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            HouseholdService householdService = CreateHouseholdService();
            var households = householdService.GetHouseholds();
            return Ok(households);
        }

        // get api/Household/{id}
        [HttpGet]
        [Route("{id}", Name= "GetById")]
        public IHttpActionResult GetById(int id)
        {
            HouseholdService householdService = CreateHouseholdService();
            var household = householdService.GetHouseholdById(id);
            if (household == null)
            {
                return NotFound();
            }
            return Ok(household);
        }


        // post  api/Household
        [HttpPost]
        public IHttpActionResult Create(HouseholdCreate household)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateHouseholdService();

            if (!service.CreateHousehold(household))
                return InternalServerError();
            return Ok();

            // test code for CreatedAtRoute
            //Household newHousehold = service.CreateHousehold(household);
            //return CreatedAtRoute("GetById", new { newHousehold.HouseholdId }, newHousehold);
        }

        // put api/Household/{id}
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult Update([FromBody] HouseholdEdit household)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateHouseholdService();

            if (!service.UpdateHousehold(household))
                return InternalServerError();

            return Ok();
        }

        // delete api/Household/{id}
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateHouseholdService();
            int result = service.DeleteHousehold(id);
            if (result == 1)
            {
                return Ok();
            }
            else if (result == 2)
            {
                return NotFound();
            }
            else
            {
            return InternalServerError();
            }
        }
    }
}
