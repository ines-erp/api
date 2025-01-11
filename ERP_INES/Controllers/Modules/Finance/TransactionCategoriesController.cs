using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiVersion("1")]
[ApiController]
public class TransactionCategoriesController : ControllerBase
{
    private readonly ITransactionCategoryRespository _repository;

    public TransactionCategoriesController(ITransactionCategoryRespository repository)
    {
        this._repository = repository;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateTransactionCategory([FromBody] TransactionCategory transactionCategory)
    {
        var category = await _repository.CreateAsync(transactionCategory);
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionCategory()
    {
        var categories = await _repository.GetAsync();
        return Ok(categories);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTransactionCategoryById([FromRoute] Guid id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category is null)
            return NotFound();

        return Ok(category);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> PutTransactionCategory([FromRoute] Guid id, [FromBody] TransactionCategory transactionCategory)
    {
        var categoryDomain = await _repository.PutAsync(id, transactionCategory);
        if (categoryDomain is null)
            return NotFound();

        return Ok(categoryDomain);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteTransactionCategory([FromRoute] Guid id)
    {
        var category = await _repository.DeleteAsync(id);
        if (category is null)
            return NotFound();

        return Ok(category);
    }
}