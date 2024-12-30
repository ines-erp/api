namespace FINANCE_MODULE.Data.Models.Entities.DTOs;

public class CreateIncomeDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public double Amount { get; set; }
    public string Currency { get; set; }
    public string IncomeMethod { get; set; }
    public string? IncomeMethodDescription { get; set; }
    public string? PaidBy { get; set; }
    public string? TypeOfIncome { get; set; }
}