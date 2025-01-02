using ERP_INES.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionRepository _repository;

    public TransactionsController(ITransactionRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var transactionDomain = _repository.GetTransactionsAsync();
        
        
        return Ok();
    }
}