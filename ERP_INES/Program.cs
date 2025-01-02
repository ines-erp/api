using ERP_INES.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApiVersioning();

//Injecting DbContext
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDevDb"))
);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();