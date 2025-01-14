using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Auth;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
    {
        var identityUser = new IdentityUser
        {
            UserName = registerUserDto.Username,
            Email = registerUserDto.Username
        };

        var identityUserResult = await _userManager.CreateAsync(identityUser, registerUserDto.Password);

        if (identityUserResult.Succeeded)
        {
            if (registerUserDto.Roles != null && registerUserDto.Roles.Any())
            {
                await _userManager.AddToRolesAsync(identityUser, registerUserDto.Roles);
                if (identityUserResult.Succeeded)
                {
                    return Ok("User was created, now you could login");
                }
            }
        }

        return BadRequest();
    }
}

public class RegisterUserDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string[] Roles { get; set; }
}