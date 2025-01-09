using ERP_INES.Data.Modules.Finance;
using ERP_INES.Data.Modules.Finance.Repositories.Concrete;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApiVersioning();
builder.Services.AddAutoMapper(typeof(AutomapperFinanceProfiles));

//Injecting DbContext
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDevDb"))
);

builder.Services.AddScoped<ITransactionRepository, PSQLTransactionRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PSQLPaymentMethodRepository>();
builder.Services.AddScoped<ICurrencyRepository, PSQLCurrencyRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();