using System.ComponentModel.DataAnnotations;
using ERP_INES.Data.Modules.Auth.Repository.Interfaces;
using ERP_INES.Domain.Modules.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Auth;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _tokenRepository;

    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
    }

    [HttpPost]
    [Route("Register")]
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

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
    {
        //need to check the user nam
        var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);
        if (user != null)
        {
            //need to check the password
            var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (checkPasswordResult != null)
            {
                //need to check the roles
                var roles = await _userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    //need to generate the token
                    var jwtToken = _tokenRepository.CreateJwtToken(user, roles.ToList());


                    //need to deliver the token as response.
                    var response = new LoginResponseDto
                    {
                        JwtToken = jwtToken
                    };

                    return Ok(response);
                }
            }
        }


        return BadRequest("Something went wrong, so please review username or password");
    }
}