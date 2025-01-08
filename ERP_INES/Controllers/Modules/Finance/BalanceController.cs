using System.Collections;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class BalanceController : ControllerBase
{
    private readonly ITransactionRepository _repository;

    public BalanceController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    private class BalanceByCurrency
    {
        public string Currency { get; set; }
        public double Amount { get; set; }
        public string Symbol { get; set; }
    }

    //TODO: Verify if there is another way to get that as some kind o aggregation
    [HttpGet]
    public async Task<IActionResult> GetBalance([FromQuery] string? currency)
    {
        List<Transaction> transactionsResult;
        if (string.IsNullOrWhiteSpace(currency) == false)
        {
            transactionsResult = await _repository.GetTransactionsAsync(currency);
        }
        else
        {
            transactionsResult = await _repository.GetTransactionsAsync();
        }

        //TODO: it must return a list of [{currency:X, balance:0.0, symbol:""}]
        var balance = new List<BalanceByCurrency>();
        foreach (var transaction in transactionsResult)
        {
            var currencyExists = balance.Find(x => x.Currency == transaction.Currency.Name);
            if (currencyExists is null)
            {
                balance.Add(new BalanceByCurrency
                {
                    Currency = transaction.Currency.Name,
                    Amount = transaction.Amount,
                    Symbol = transaction.Currency.Symbol
                });
            }
            else
            {
                currencyExists.Amount += transaction.Amount;
            }
        }

        return Ok(balance);
    }
}