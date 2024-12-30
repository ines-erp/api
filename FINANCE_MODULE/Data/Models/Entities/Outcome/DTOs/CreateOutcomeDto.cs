namespace FINANCE_MODULE.Data.Models.Entities.DTOs;

public class CreateOutcomeDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string OutcomeMethod { get; set; }
    public string? OutcomeMethodDescription { get; set; }
    public string? Beneficiary { get; set; }
    public string? TypeOfOutcome { get; set; }
}