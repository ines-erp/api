using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class CurrenciesController:ControllerBase
{
    private readonly ICurrencyRepository _repository;
    private readonly IMapper _mapper;

    public CurrenciesController(ICurrencyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCurrencies([FromQuery] string? name, string? isoCode, string? symbol)
    {
        var currencies = await _repository.GetCurrenciesAsync(name, isoCode, symbol);
        return Ok(currencies);
    }
}