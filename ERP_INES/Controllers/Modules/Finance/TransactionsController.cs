using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    public TransactionsController(ITransactionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactions()
    {
        var transactionDomain = await _repository.GetTransactionsAsync();

        var transactionsDto = _mapper.Map<List<TransactionDto>>(transactionDomain);

        return Ok(transactionsDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto createTransactionDto)
    {
        var transactionMapperToDomain = _mapper.Map<Transaction>(createTransactionDto);
        transactionMapperToDomain.CreatedAt = DateTime.Now.ToUniversalTime();
        transactionMapperToDomain.UpdatedAt = transactionMapperToDomain.CreatedAt;

        var newTransaction = await _repository.CreateAsync(transactionMapperToDomain);

        var transactionMapperToDto = _mapper.Map<TransactionDto>(newTransaction);

        return CreatedAtAction(nameof(GetTransactionById), new { id = transactionMapperToDto.Id },
            transactionMapperToDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTransactionById([FromRoute] Guid id)
    {
        var transactionResult = await _repository.GetTransactionsByIdAsync(id);
        
        if (transactionResult is null)
            return NotFound();


        var transactionResultDto = _mapper.Map<TransactionDto>(transactionResult);


        return Ok(transactionResultDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateTransaction([FromRoute] Guid id,
        [FromBody] UpdateTransactionDto updateTransactionDto)
    {
        var trasactionMappedToDomain = _mapper.Map<Transaction>(updateTransactionDto);

        var transactionResult = await _repository.UpdateTransactionsAsync(id, trasactionMappedToDomain);

        if (transactionResult is null)
            return NotFound();

        var transactionResultDto = _mapper.Map<TransactionDto>(transactionResult);


        return Ok(transactionResultDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteTransaction([FromBody] UpdateTransactionDto updateTransactionDto)
    {
        return Ok();
    }
}