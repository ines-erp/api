using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface IPaymentMethodRepository
{
    Task<List<PaymentMethod>> GetPaymentMethodsAsync(
        string? name,
        string? type,
        string? currency,
        string? sortBy,
        bool isAscending=true,
        int pageNumber = 1,
        int pageSize = 1000
        );
    Task<PaymentMethod> GetPaymentMethodByIdAsync(Guid id);
    Task<PaymentMethod?> CreatePaymentMethodAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod?> UpdatePaymentMethodAsync(Guid id, PaymentMethod paymentMethod);
    Task<PaymentMethod?> DeletePaymentMethodAsync(Guid id);
}