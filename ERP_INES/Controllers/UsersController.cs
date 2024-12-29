using ERP_INES.Data;
using ERP_INES.Models.DTOs.User;
using ERP_INES.Models.Entity;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList(); 
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
    public IActionResult CreateUser(CreateUserDTO createUserDto)
    {
        if (createUserDto is null)
            return BadRequest();
    
        var newUser = new User()
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email,
            Password = createUserDto.Password
        };
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
    
        return Ok(newUser);
    }
    
}