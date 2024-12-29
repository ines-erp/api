using ERP_INES.Data;
using ERP_INES.Models.DTOs.User;
using ERP_INES.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // var users = _context.Users.ToList();
        
        var users = await _context.Users.Include(u => u.Roles).ToListAsync();
        
        return Ok( users);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetUserByID(Guid id)
    {
        var user = _context.Users.Find(id);
    
        if (user is null)
            return NotFound();
        
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDTO createUserDto)
    {
        
        var relatedRoles = new List<Role>(); 
        
        if (createUserDto is null)
            return BadRequest();

        if (createUserDto.Roles is not null)
        {
            foreach (var roleId in createUserDto.Roles)
            {
                _context.Roles.Find(roleId);
                relatedRoles.Add(_context.Roles.Find(roleId));
            }
        }
            
        var newUser = new User()
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email,
            Password = createUserDto.Password,
            Roles = relatedRoles 
        };

        Console.WriteLine(newUser.Roles);
        
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
    
        return Ok(newUser);
    }
    
}