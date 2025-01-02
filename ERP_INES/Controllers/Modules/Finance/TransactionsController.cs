
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

        var transactionMapper = _mapper.Map<Transaction>(createTransactionDto);
        var newTransaction = await _repository.CreateAsync(transactionMapper);
        
        return Ok(newTransaction);
    }
    
}