using System.Runtime.InteropServices.JavaScript;

namespace FINANCE_MODULE.Data.Models.Entities;

public class Outcome
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string OutcomeMethod { get; set; }
    public string? OutcomeMethodDescription { get; set; }
    public string? Beneficiary { get; set; }
    public string? TypeOfOutcome { get; set; }
    
    //Many to one
    // public Guid UserId { get; set; } 
    
    //we must in future register the user who created the entry
}