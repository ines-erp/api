using FINANCE_MODULE.Data;
using FINANCE_MODULE.Repositories;
using FINANCE_MODULE.Repositories.Implementations.PostgreSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDevFinance")));

//Injecting repository
builder.Services.AddScoped<IIncomeRepository, PostgreSQLIncomeRepository>();
builder.Services.AddScoped<IOutcomeRepository, PostgreSQLOutcomeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
