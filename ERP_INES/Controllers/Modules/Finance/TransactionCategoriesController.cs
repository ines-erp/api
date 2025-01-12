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
        var categoryDomain = await _repository.CreateAsync(transactionCategory);

        var categoriesDto = new
        {
            Id = categoryDomain.Id,
            Name = categoryDomain.Name
        };

        return Ok(categoriesDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetTransactionCategory()
    {
        var categoriesDomain = await _repository.GetAsync();

        List<object> categoriesDto = [];

        foreach (var category in categoriesDomain)
        {
            categoriesDto.Add(category);
        }
        
        
        return Ok(categoriesDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetTransactionCategoryById([FromRoute] Guid id)
    {
        var categoryDomain = await _repository.GetByIdAsync(id);
        if (categoryDomain is null)
            return NotFound();

        var categoriesDto = new
        {
            Id = categoryDomain.Id,
            Name = categoryDomain.Name
        };

        return Ok(categoriesDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> PutTransactionCategory([FromRoute] Guid id,
        [FromBody] TransactionCategory transactionCategory)
    {
        var categoryDomain = await _repository.PutAsync(id, transactionCategory);
        if (categoryDomain is null)
            return NotFound();

        var categoriesDto = new
        {
            Id = categoryDomain.Id,
            Name = categoryDomain.Name
        };

        return Ok(categoriesDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteTransactionCategory([FromRoute] Guid id)
    {
        var categoryDomain = await _repository.DeleteAsync(id);
        if (categoryDomain is null)
            return NotFound();

        var categoriesDto = new
        {
            Id = categoryDomain.Id,
            Name = categoryDomain.Name
        };

        return Ok(categoriesDto);
    }
}