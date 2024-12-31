using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Controllers;

[Route("api/v1/auth/test")]
[ApiController]

public class AuthTestingController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAuth()
    {
        return Ok("Auth route");
    }

    [Authorize]
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetAuthById(int id)
    {
        return Ok("Auth route");
    }
}