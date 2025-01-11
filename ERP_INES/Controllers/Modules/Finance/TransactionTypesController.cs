using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class TransactionTypesController : ControllerBase

{
    private readonly ITransactionTypeRepository _repository;

    public TransactionTypesController(ITransactionTypeRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransactionType([FromBody] TransactionType transactionType)
    {
        var types = await _repository.CreateAsync(transactionType);
        return Ok(types);
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionType()
    {
        var types = await _repository.GetAsync();
        return Ok(types);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTransactionTypeById([FromRoute] Guid id)
    {
        var type = await _repository.GetByIdAsync(id);
        if (type is null)
            return NotFound();

        return Ok(type);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> PutTransactionType([FromRoute] Guid id, [FromBody] TransactionType transactionType)
    {
        var typeDomain = await _repository.PutAsync(id, transactionType);
        if (typeDomain is null)
            return NotFound();

        return Ok(typeDomain);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteTransactionType([FromRoute] Guid id)
    {
        var type = await _repository.DeleteAsync(id);
        if (type is null)
            return NotFound();

        return Ok(type);
    }
}