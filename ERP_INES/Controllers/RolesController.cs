using ERP_INES.Data;
using ERP_INES.Models.DTOs.Role;
using ERP_INES.Models.Entity;
using ERP_INES.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetRoles()
    {
        // var roles = _context.Roles.ToList();
        var roles = await _context.Roles.Include(r => r.Users).ToListAsync();
        return Ok(roles);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetRoleById(Guid id)
    {
        var role = _context.Roles.Find(id);

        if (role is null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public async Task<ActionResult<Role>> CreateRole(CreateRoleDTO createRoleDto)
    {
        if (createRoleDto is null)
            return BadRequest();


        var newRole = new Role()
        {
            Name = createRoleDto.Name,
            Permissions = [],
            Scope = createRoleDto.Scope
        };

        //create a service to validate that
        foreach (PermissionLevel level in createRoleDto.Permissions)
        {
            if (Enum.IsDefined(typeof(PermissionLevel), level))
            {
                newRole.Permissions.Add(level);
            }
        }

        if (Enum.IsDefined(typeof(PermissionScope), createRoleDto.Scope) && newRole.Permissions.Count > 0)
        {
            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();

            return Ok(newRole);
        }

        return BadRequest("Your dummy pass something that exists!!!!");
    }
}