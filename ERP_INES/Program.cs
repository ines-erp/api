using ERP_INES.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// builder.Services.AddDbContextPool<InesDbContext>(opt =>
//     opt.UseNpgsql(
//         builder.Configuration.GetConnectionString("Development"),
//         o => o.SetPostgresVersion(17,2)
//         ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();