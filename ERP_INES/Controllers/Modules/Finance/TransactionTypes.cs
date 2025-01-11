using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/{v:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class TransactionTypes : ControllerBase

{
    [HttpPost]
    public async Task<IActionResult> CreateTransactionType()
    {
        return Ok("Create TransactionType");
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionType()
    {
        return Ok("TransactionType");
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTransactionType([FromRoute] Guid id)
    {
        return Ok("TransactionType");
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> PutTransactionType([FromRoute] Guid id)
    {
        return Ok("Put TransactionType");
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteTransactionType([FromRoute] Guid id)
    {
        return Ok("Delete TransactionType");
    }
}