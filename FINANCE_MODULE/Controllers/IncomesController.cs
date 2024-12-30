using FINANCE_MODULE.Data.Models.Entities.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FINANCE_MODULE.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class IncomesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllIncomes()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetIncomeById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateIncome(CreateIncomeDto creteIncomeDto)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateIncome(Guid id, UpdateIncomeDto updateIncomeDto)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id;guid}")]
    public async Task<IActionResult> DeleteIncome(Guid id)
    {
        return Ok();
    }
}