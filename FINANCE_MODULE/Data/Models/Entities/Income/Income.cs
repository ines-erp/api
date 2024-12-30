using System.Runtime.InteropServices.JavaScript;

namespace FINANCE_MODULE.Data.Models.Entities;

public class Income
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string IncomeMethod { get; set; }
    public string? IncomeMethodDescription { get; set; }
    public string? PaidBy { get; set; }
    public string? TypeOfIncome { get; set; }
    
    //Many to one
    // public Guid UserId { get; set; } 
    
    //we must in future register the user who created the entry
    
}