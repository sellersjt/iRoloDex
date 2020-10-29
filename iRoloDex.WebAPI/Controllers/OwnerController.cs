using iRoloDex.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

/*namespace iRoloDex.WebAPI.Controllers
{
    [Authorize]
    public class OwnerController : ApiController
    {
        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = OwnerService.GetOwners();
            return Ok(owners);
        }
    }

    private OwnerService CreateOwnerService()
    {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var noteService = new OwnerService(userId);
        return noteService;
    }

    public IHttpActionResult GetOwners(int id)
    {
        OwnerService ownerService = CreateOwnerService();
        var owner = ownerService.GetOwnerById(id);
        return Ok(owner);
    }
}*/