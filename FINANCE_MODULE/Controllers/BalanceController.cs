using FINANCE_MODULE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINANCE_MODULE.Controllers;

[Route("api/v1/[controller]")]
[ApiController]

public class BalanceController : ControllerBase
{
        private readonly IIncomeRepository _incomeRepository;
        private readonly IOutcomeRepository _outcomeRepository;

        public BalanceController(IIncomeRepository incomeRepository, IOutcomeRepository outcomeRepository)
        {
                _incomeRepository = incomeRepository;
                _outcomeRepository = outcomeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance()
        {
                var incomes = await _incomeRepository.GetIncomes();
                var incomesSumResult = incomes.Sum(income => income.Amount);
                
                var outcomes = await _outcomeRepository.GetOutcomes();
                var outcomesSumResult = outcomes.Sum(outcome => outcome.Amount);
                
                var balance = incomesSumResult - outcomesSumResult;
                return Ok(balance);
        }
}