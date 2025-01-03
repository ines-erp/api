
using AutoMapper;
using ERP_INES.Domain.Modules.Finance.DTOs;
using ERP_INES.Domain.Modules.Finance.Entities;


public class AutomapperFinanceProfiles : Profile
{
    public AutomapperFinanceProfiles()
    {
        CreateMap<TransactionDto, Transaction>().ReverseMap();
        CreateMap<CreateTransactionDto, Transaction>().ReverseMap();
        CreateMap<UpdateTransactionDto, Transaction>().ReverseMap();
    }
}