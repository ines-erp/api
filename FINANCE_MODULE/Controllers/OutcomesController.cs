using FINANCE_MODULE.Data.Models.Entities;
using FINANCE_MODULE.Data.Models.Entities.DTOs;
using FINANCE_MODULE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINANCE_MODULE.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OutcomesController : ControllerBase
{
    private readonly IOutcomeRepository _outcomeRepository;

    public OutcomesController(IOutcomeRepository outcomeRepository)
    {
        _outcomeRepository = outcomeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GeOutcomes()
    {
        var outcomes = await _outcomeRepository.GetOutcomes();
        return Ok(outcomes);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetOutcomeById(Guid id)
    {
        var outcome = await _outcomeRepository.GetOutcomeById(id);

        if (outcome is null)
            return NotFound();
        
        return Ok(outcome);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOutcome(CreateOutcomeDto createOutcomeDto)
    {
        var outcome = await _outcomeRepository.CreateOutcome(new Outcome()
        {
            Name = createOutcomeDto.Name,
            Description = createOutcomeDto.Description,
            Date = createOutcomeDto.Date,
            Amount = createOutcomeDto.Amount,
            Currency = createOutcomeDto.Currency,
            OutcomeMethod = createOutcomeDto.OutcomeMethod,
            OutcomeMethodDescription = createOutcomeDto.OutcomeMethodDescription,
            Beneficiary = createOutcomeDto.Beneficiary,
            TypeOfOutcome = createOutcomeDto.TypeOfOutcome
        });
            
        return CreatedAtAction(nameof(GetOutcomeById), new { id = outcome.Id }, outcome);

    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateOutcome(Guid id, UpdateOutcomeDto updateOutcomeDto)
    {
        var outcome = await _outcomeRepository.UpdateOutcome(id, new Outcome()
        {
            Name = updateOutcomeDto.Name,
            Description = updateOutcomeDto.Description,
            Date = updateOutcomeDto.Date,
            Amount = updateOutcomeDto.Amount,
            Currency = updateOutcomeDto.Currency,
            OutcomeMethod = updateOutcomeDto.OutcomeMethod,
            OutcomeMethodDescription = updateOutcomeDto.OutcomeMethodDescription,
            Beneficiary = updateOutcomeDto.Beneficiary,
            TypeOfOutcome = updateOutcomeDto.TypeOfOutcome
        });
            
        return CreatedAtAction(nameof(GetOutcomeById), new { id = outcome.Id }, outcome);

    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteOutcome(Guid id)
    {
        var deleteOutcome = await _outcomeRepository.DeleteOutcome(id);
        
        if(deleteOutcome is null)
            return NotFound();
        
        return Ok(deleteOutcome);
    }
}