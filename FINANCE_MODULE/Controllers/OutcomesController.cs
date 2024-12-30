using FINANCE_MODULE.Data.Models.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FINANCE_MODULE.Controllers;

[Route("api/vi/[controller]")]
[ApiController]
public class OutcomesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOutcomes()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetOutcomeById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOutcome(CreateOutcomeDto creteOutcomeDto)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateOutcome(Guid id, UpdateOutcomeDto updateOutcomeDto)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id;guid}")]
    public async Task<IActionResult> DeleteOutcome(Guid id)
    {
        return Ok();
    }
}