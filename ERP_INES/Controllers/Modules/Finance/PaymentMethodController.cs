using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP_INES.Controllers.Modules.Finance;
[Route("api/v{v:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
public class PaymentMethodController: ControllerBase
{
    private readonly IPaymentMethodRepository _repository;
    private readonly IMapper _mapper;

    public PaymentMethodController(IPaymentMethodRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaymentMethods()
    {
        var paymentMethodsDomain = await _repository.GetPaymentMethodsAsync();
        var paymenthMethodsDto = _mapper.Map<List<PaymentMethodDto>>(paymentMethodsDomain);

        return Ok(paymenthMethodsDto);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetPaymentMethodById([FromRoute] Guid id)
    {
        var paymentMethod = await _repository.GetPaymentMethodByIdAsync(id);
        if (paymentMethod is null)
            return NotFound();

        var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethod);

        return Ok(paymentMethodDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaymentMethod([FromBody] CreatePaymentMethodDto createPaymentMethodDto)
    {
        var paymentMethodDomain = _mapper.Map<PaymentMethod>(createPaymentMethodDto);
        paymentMethodDomain.CreatedAt = DateTime.Now.ToUniversalTime();

        var newPaymentMethod = await _repository.CreatePaymentMethodAsync(paymentMethodDomain);

        var newPaymentMethodDto = _mapper.Map<PaymentMethodDto>(newPaymentMethod);

        return Ok(newPaymentMethodDto);
    }

    // PUT request

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeletePaymentMethod([FromRoute] Guid id)
    {
        var paymentMethod = await _repository.DeletePaymentMethodAsync(id);

        if (paymentMethod is null)
            return NotFound();
        
        return Ok(paymentMethod);
    }
}