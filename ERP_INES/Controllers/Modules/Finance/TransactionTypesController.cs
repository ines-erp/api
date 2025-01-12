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
        var typeDomain = await _repository.CreateAsync(transactionType);

        var typeDto = new
        {
            Id = typeDomain.Id,
            Name = typeDomain.Name
        };

        return Ok(typeDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionType()
    {
        var typeDomain = await _repository.GetAsync();

        List<object> typesDto = [];

        foreach (var type in typeDomain)
        {
            typesDto.Add(new
            {
                Id = type.Id,
                Name = type.Name
            });
        }

        return Ok(typesDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTransactionTypeById([FromRoute] Guid id)
    {
        var typeDomain = await _repository.GetByIdAsync(id);
        if (typeDomain is null)
            return NotFound();

        var typesDto = new
        {
            Id = typeDomain.Id,
            Name = typeDomain.Name
        };

        return Ok(typesDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> PutTransactionType([FromRoute] Guid id, [FromBody] TransactionType transactionType)
    {
        var typeDomain = await _repository.PutAsync(id, transactionType);
        if (typeDomain is null)
            return NotFound();

        var typesDto = new
        {
            Id = typeDomain.Id,
            Name = typeDomain.Name
        };

        return Ok(typesDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteTransactionType([FromRoute] Guid id)
    {
        var typeDomain = await _repository.DeleteAsync(id);
        if (typeDomain is null)
            return NotFound();

        var typesDto = new
        {
            Id = typeDomain.Id,
            Name = typeDomain.Name
        };

        return Ok(typesDto);
    }
}