using ERP_INES.Data;
using ERP_INES.Entities;
using ERP_INES.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RoleController : Controller
{
    private IRoleRepository _roleRepository;

    public RoleController()
    {
        _roleRepository = new RoleRepository(new InesDbContext());
    }


    //GET all roles
    [HttpGet]
    public IActionResult Get()
    {
        var roles = _roleRepository.GetRoles();
        return Json(roles);
    }
    
    
    //POST
    [HttpPost]
    public ActionResult<int> Post(Role role)
    {
        _roleRepository.InsertRole(role);
        return StatusCodes.Status201Created;
    }
}