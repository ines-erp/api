using System.Globalization;
using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class PaymentMethodsController: ControllerBase
{
    private readonly IPaymentMethodRepository _repository;
    private readonly IMapper _mapper;

    public PaymentMethodsController(IPaymentMethodRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentMethods([FromQuery] string? search)
    {
        var paymentMethodsDomain = await _repository.GetPaymentMethodsAsync(search);
        var paymentMethodsDto = _mapper.Map<List<PaymentMethodDto>>(paymentMethodsDomain);

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

        return Ok(paymentMethodDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodDto createPaymentMethodDto)
    {
        //Validate if currency ISO is valid
        var localSymbol = createPaymentMethodDto.ISOCurrencySymbol;

        if (!string.IsNullOrWhiteSpace(localSymbol))
        {
            var culturesInfo = CultureInfo
                .GetCultures((CultureTypes.SpecificCultures))
                .Select(ci => new RegionInfo(ci.Name));

            var regionInfoLocale = culturesInfo.FirstOrDefault(ri => ri.ISOCurrencySymbol == localSymbol);
            
            if (regionInfoLocale is null)
                return Problem("Currency code is wrong");
            
            createPaymentMethodDto.ISOCurrencySymbol = regionInfoLocale.ISOCurrencySymbol;
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