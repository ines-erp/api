using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/{v:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class TransactionCategoriesController : ControllerBase
{
    
    
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory()
    {
        return Ok("Create categories");
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return Ok("categories");
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCategory([FromRoute] Guid id)
    {
        return Ok("category");
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> PutCategory([FromRoute] Guid id)
    {
        return Ok("Put category");
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
    {
        return Ok("Delete category");
    }
}