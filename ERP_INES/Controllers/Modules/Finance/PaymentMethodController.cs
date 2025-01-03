using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<IActionResult> GetPaymentMethodById(Guid id)
    {
        var paymentMethod = await _repository.GetPaymentMethodByIdAsync(id);
        if (paymentMethod is null)
            return NotFound();

        var paymentMethodDto = _mapper.Map<PaymentMethodDto>(paymentMethod);

        return Ok(paymentMethodDto);
    }

    

    // PUT request

    // DELETE request
}