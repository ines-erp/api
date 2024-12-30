using FINANCE_MODULE.Data.Models.Entities;
using FINANCE_MODULE.Data.Models.Entities.DTOs;
using FINANCE_MODULE.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FINANCE_MODULE.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class IncomesController : ControllerBase
{
    private readonly IIncomeRepository _incomeRepository;

    public IncomesController(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetIncomes()
    {
        var incomes = await _incomeRepository.GetIncomes();
        return Ok(incomes);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetIncomeById(Guid id)
    {
        var income = await _incomeRepository.GetIncomeById(id);
        if (income is null)
            return NotFound();

        return Ok(income);
    }

    [HttpPost]
    public async Task<IActionResult> CreateIncome(CreateIncomeDto createIncomeDto)
    {
        var income = await _incomeRepository.CreateIncome(
            new Income()
            {
                Name = createIncomeDto.Name,
                Description = createIncomeDto.Description,
                Date = createIncomeDto.Date,
                Amount = createIncomeDto.Amount,
                Currency = createIncomeDto.Currency,
                IncomeMethod = createIncomeDto.IncomeMethod,
                IncomeMethodDescription = createIncomeDto.IncomeMethodDescription,
                PaidBy = createIncomeDto.PaidBy,
                TypeOfIncome = createIncomeDto.TypeOfIncome
            }
        );


        return CreatedAtAction(nameof(GetIncomeById), new { id = income.Id }, income);
        // return Ok();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateIncome(Guid id, UpdateIncomeDto updateIncomeDto)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteIncome(Guid id)
    {
        var deletedIncome = await _incomeRepository.DeleteIncome(id);

        if (deletedIncome is null)
            return NotFound();
        
        return Ok(deletedIncome);
    }
}