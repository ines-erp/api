using AutoMapper;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.DTOs;
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

    // GET by id request

    // POST request

    // PUT request

    // DELETE request
}