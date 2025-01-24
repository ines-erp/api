using ERP_INES.Domain.Modules.Finance.Entities;

namespace ERP_INES.Data.Modules.Finance.Repositories.Interfaces;

public interface IPaymentMethodRepository
{
    Task<List<PaymentMethod>> GetPaymentMethodsAsync(
        string? name,
        string? type,
        string? currency,
        string? sort,
        string order="asc",
        int page = 1,
        int limit = 1000
        );
    Task<PaymentMethod> GetPaymentMethodByIdAsync(Guid id);
    Task<PaymentMethod?> CreatePaymentMethodAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod?> UpdatePaymentMethodAsync(Guid id, PaymentMethod paymentMethod);
    Task<PaymentMethod?> DeletePaymentMethodAsync(Guid id);
}