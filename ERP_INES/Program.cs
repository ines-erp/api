using System.Text;
using ERP_INES.Data.Modules.Auth;
using ERP_INES.Data.Modules.Auth.Repository.Concrete;
using ERP_INES.Data.Modules.Auth.Repository.Interfaces;
using ERP_INES.Data.Modules.Finance;
using ERP_INES.Data.Modules.Finance.Repositories.Concrete;
using ERP_INES.Data.Modules.Finance.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddApiVersioning();
builder.Services.AddAutoMapper(typeof(AutomapperFinanceProfiles));

//Injecting DbContext
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDevDb"))
);
builder.Services.AddDbContext<InesAuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityServerDb"))
);

builder.Services.AddScoped<ITransactionRepository, PSQLTransactionRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PsqlPaymentMethodRepository>();
builder.Services.AddScoped<ITransactionCategoryRespository, PsqlTransactionCategoryRepository>();
builder.Services.AddScoped<ITransactionTypeRepository, PsqlTransactionTypesRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();


//That will inject the identity to our solution.
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("InesUser")
    .AddEntityFrameworkStores<InesAuthDbContext>()
    .AddDefaultTokenProviders();

//That will inject options to our solution to override the defaults
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes((builder.Configuration["Jwt:Key"])))
        });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();