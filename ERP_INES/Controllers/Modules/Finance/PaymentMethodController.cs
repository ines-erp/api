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
    public async Task<IActionResult> GetPaymentMethods([FromQuery] string? name)
    {
        var paymentMethodsDomain = await _repository.GetPaymentMethodsAsync(name);
        var paymentMethodsDto = _mapper.Map<List<PaymentMethodDto>>(paymentMethodsDomain);

        return Ok(paymentMethodsDto);
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

    [HttpPatch]
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
        var paymentMethod = await _repository.DeletePaymentMethodAsync(id);

        if (paymentMethod is null)
            return NotFound();
        
        return Ok(paymentMethod);
    }
}