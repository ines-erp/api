using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using ERP_INES.Domain.Modules.Finance.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ERP_INES.Data.Modules.Finance.Repositories.Concrete;

public class PSQLPaymentMethodRepository:IPaymentMethodRepository
{
    
    private readonly FinanceDbContext _context;

    public PSQLPaymentMethodRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<PaymentMethod>> GetPaymentMethodsAsync()
    {
        var paymentMethods = await _context.PaymentMethods.ToListAsync();
        return paymentMethods;
    }

    public async Task<List<PaymentMethod>> GetPaymentMethodsAsync(string name)
    {
        var paymentMethods = _context.PaymentMethods.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            paymentMethods = paymentMethods.Where(method => method.Name == name);
        }

        return await paymentMethods.ToListAsync();
    }
    
    public async Task<PaymentMethod> GetPaymentMethodByIdAsync(Guid id)
    {
        var paymentMethod = await _context.PaymentMethods.FindAsync(id);

        if (paymentMethod is null)
            return null;
        
        return paymentMethod;
    }

    public async Task<PaymentMethod?> CreatePaymentMethodAsync(PaymentMethod paymentMethod)
    {
        await _context.PaymentMethods.AddAsync(paymentMethod);
        await _context.SaveChangesAsync();

        return paymentMethod;
    }

    public async Task<PaymentMethod?> UpdatePaymentMethodAsync(Guid id, PaymentMethod paymentMethod)
    {
        var existingPaymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(method => method.Id == id);

        if (existingPaymentMethod is null)
            return null;

        existingPaymentMethod.Name = paymentMethod.Name;
        existingPaymentMethod.Description = paymentMethod.Description;

        await _context.SaveChangesAsync();
        return existingPaymentMethod;
    }

    public async Task<PaymentMethod?> DeletePaymentMethodAsync(Guid id)
    {
        var existingPaymentMethod = await _context.PaymentMethods.FirstOrDefaultAsync(method => method.Id == id);

        if (existingPaymentMethod is null)
            return null;

        _context.PaymentMethods.Remove(existingPaymentMethod);
        await _context.SaveChangesAsync();

        return existingPaymentMethod;
    }
}