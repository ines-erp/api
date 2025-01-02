
using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
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
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactionDomain = await _repository.GetTransactionsAsync();

        var transactionsDto = _mapper.Map<List<TransactionDto>>(transactionDomain);

        return Ok(transactionsDto);
    }
}