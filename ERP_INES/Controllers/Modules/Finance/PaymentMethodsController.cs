using System.Globalization;
using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;
using ERP_INES.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;

[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class PaymentMethodsController : ControllerBase
{
    private readonly IPaymentMethodRepository _repository;
    private readonly IMapper _mapper;

    public PaymentMethodsController(IPaymentMethodRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentMethods(
        [FromQuery] string? name,
        [FromQuery] string? currency,
        [FromQuery] string? type,
        [FromQuery] string? sortBy,
        [FromQuery] bool? isAscending,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize
        )
    {
        var paymentMethodsDomain = await _repository.GetPaymentMethodsAsync(name, type, currency, sortBy, isAscending ?? true, pageNumber ?? 1, pageSize ?? 1000);
        var paymentMethodsDto = _mapper.Map<List<PaymentMethodDto>>(paymentMethodsDomain);
        foreach (var pm in paymentMethodsDto)
        {
            var currencyInfo =
                CurrencyHelper.GetCurrencyInfoByIsoCode(paymentMethodsDomain.Find(method => method.Id == pm.Id)
                    .ISOCurrencySymbol);
            pm.Currency = currencyInfo;
        }

        return Ok(paymentMethodsDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetPaymentMethodById([FromRoute] Guid id)
    {
        var paymentMethodDomain = await _repository.GetPaymentMethodByIdAsync(id);
        if (paymentMethodDomain is null)
            return NotFound();

        var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethodDomain);
        var currencyInfo = CurrencyHelper.GetCurrencyInfoByIsoCode(paymentMethodDomain.ISOCurrencySymbol);

        paymentMethodDto.Currency = currencyInfo;

        return Ok(paymentMethodDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodDto createPaymentMethodDto)
    {
        //Validate if currency ISO is valid
        var localSymbol = createPaymentMethodDto.ISOCurrencySymbol;

        if (!string.IsNullOrWhiteSpace(localSymbol))
        {
            var currencyInfo = CurrencyHelper.GetCurrencyInfoByIsoCode(localSymbol);

            if (currencyInfo is null)
                return Problem("Currency code is wrong");

            createPaymentMethodDto.ISOCurrencySymbol = currencyInfo.ISOCode;
        }
        else
        {
            createPaymentMethodDto.ISOCurrencySymbol = "EUR";
        }


        var paymentMethodDomain = _mapper.Map<PaymentMethod>(createPaymentMethodDto);
        paymentMethodDomain.CreatedAt = DateTime.Now.ToUniversalTime();

        var newPaymentMethod = await _repository.CreatePaymentMethodAsync(paymentMethodDomain);

        var newPaymentMethodDto = _mapper.Map<PaymentMethodDto>(newPaymentMethod);

        return Ok(newPaymentMethodDto);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdatePaymentMethod([FromRoute] Guid id,
        [FromBody] UpdatePaymentMethodDto updatePaymentMethodDto)
    {
        var updatePaymentMethodDomain = _mapper.Map<PaymentMethod>(updatePaymentMethodDto);
        updatePaymentMethodDomain.UpdatedAt = DateTime.Now.ToUniversalTime();
        if (!string.IsNullOrWhiteSpace(updatePaymentMethodDomain.ISOCurrencySymbol))
        {
            var currencyInfo = CurrencyHelper.GetCurrencyInfoByIsoCode(updatePaymentMethodDomain.ISOCurrencySymbol);

            if (currencyInfo is null)
                return Problem("Currency code is wrong");

            updatePaymentMethodDomain.ISOCurrencySymbol = currencyInfo.ISOCode;
        }
        else
        {
            updatePaymentMethodDomain.ISOCurrencySymbol = "EUR";
        }

        var paymentMethod = await _repository.UpdatePaymentMethodAsync(id, updatePaymentMethodDomain);

        if (paymentMethod is null)
            return NotFound();

        var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethod);
        return Ok(paymentMethodDto);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeletePaymentMethod([FromRoute] Guid id)
    {
        var paymentMethodDomain = await _repository.DeletePaymentMethodAsync(id);

        if (paymentMethodDomain is null)
            return NotFound();

        var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethodDomain);
        return Ok(paymentMethodDto);
    }
}