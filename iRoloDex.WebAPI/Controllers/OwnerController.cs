using iRoloDex.Data.Entities;
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
    public class OwnerController : ApiController
    {
        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnerService(userId);
            return ownerService;
        }

        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = ownerService.GetOwners();
            return Ok(owners);
        }

        public IHttpActionResult GetOwners(int id)
        {
            OwnerService ownerService = CreateOwnerService();
            var owner = ownerService.GetOwnerById(id);
            return Ok(owner);
        }
    }
}