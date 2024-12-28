using ERP_INES.Data;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoleController : Controller
{
    //We will list our endpoints
    //GET all roles
    [HttpGet(Name = "all_roles")]
    public IActionResult Get()
    {
        //TODO: Access database, perform a query to get all roles and return it
        using var context = new InesDbContext();
        var roles = context.Roles.ToList();
        
        return Json(roles);
    }
}