using System.Collections;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;
using ERP_INES.Helpers;
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
        var transactionsResult = await _repository.GetTransactionsAsync(currency, null, null, 1, 1000);
        
        List<CurrencyDto> availableCurrencies = new List<CurrencyDto>();
        
        foreach (var transaction in transactionsResult)
        {
            availableCurrencies.Add(CurrencyHelper.GetCurrencyInfoByIsoCode(transaction.PaymentMethod.ISOCurrencySymbol));
                        
        }
        var balance = new List<BalanceByCurrency>();
        foreach (var transaction in transactionsResult)
        {
            var transactionCurrency = availableCurrencies.Find(currency =>
                currency.ISOCode == transaction.PaymentMethod.ISOCurrencySymbol);
            
            var currencyExists = balance.Find(x => x.Currency == transactionCurrency.Name);
            
            if (currencyExists is null)
            {
                balance.Add(new BalanceByCurrency
                {
                    Currency = transactionCurrency.Name,
                    Amount = transaction.Amount,
                    Symbol = transactionCurrency.Symbol
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