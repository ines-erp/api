using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;
using ERP_INES.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
[Authorize(Roles = "Writer, Reader")]
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
    public async Task<IActionResult> GetTransactions([FromQuery] string? currency)
    {
        var transactionDomain = await _repository.GetTransactionsAsync(currency);
        var transactionsDto = _mapper.Map<List<TransactionDto>>(transactionDomain);
        
        foreach (var transaction in transactionsDto)
        {
            var currencyInfo = CurrencyHelper.GetCurrencyInfoByIsoCode(transactionDomain.Find(t => t.Id == transaction.Id).PaymentMethod.ISOCurrencySymbol);
            transaction.PaymentMethod.Currency = currencyInfo;
        }
        
        return Ok(transactionsDto);
      
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto createTransactionDto)
    {
        var transactionMapperToDomain = _mapper.Map<Transaction>(createTransactionDto);
        transactionMapperToDomain.CreatedAt = DateTime.Now.ToUniversalTime();
        transactionMapperToDomain.UpdatedAt = transactionMapperToDomain.CreatedAt;

        if (createTransactionDto.TransactionTypeId == Guid.Parse("fd5e3535-5a7c-4294-abde-49e869d77957"))
        {
            transactionMapperToDomain.Amount *= -1;
        }

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
        var currencyInfo = CurrencyHelper.GetCurrencyInfoByIsoCode(transactionResult.PaymentMethod.ISOCurrencySymbol);
        transactionResultDto.PaymentMethod.Currency = currencyInfo;        

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
    public async Task<IActionResult> DeleteTransaction([FromRoute] Guid id)
    {
        var transactionResult = await _repository.DeleteTransactionsAsync(id);

        if (transactionResult is null)
            return NotFound();


        var transactionResultDto = _mapper.Map<TransactionDto>(transactionResult);


        return Ok(transactionResultDto);
    }
}