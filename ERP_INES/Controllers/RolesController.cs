using ERP_INES.Data;
using ERP_INES.Models.DTOs.Role;
using ERP_INES.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RolesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetRoles()
    {
        var roles = _context.Roles.ToList();
        return Ok(roles);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetRoleById(Guid id)
    {
        var role = _context.Roles.Find(id);
        
        if(role is null)
            return NotFound();
        
        return Ok(role);
    }

    [HttpPost]
    public IActionResult CreateRole(CreateRoleDTO createRoleDto)
    {
     if(createRoleDto is null)
         return BadRequest();

     var newRole = new Role()
     {
         Name = createRoleDto.Name,
         Permissions = createRoleDto.Permissions,
         Scope = createRoleDto.Scope
     };
     _context.Roles.Add(newRole);
     _context.SaveChanges();

     return Ok(newRole);
    }
}