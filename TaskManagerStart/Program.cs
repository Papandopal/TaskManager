using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TaskManagerStart;
using Infrastructure.Database;
using UseCase.AuthorisationServices;
using UseCase.Database;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var authenticationOptions = new AuthentificationOptions(configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authenticationOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = authenticationOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = authenticationOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<Mapper>();
});

builder.Services.AddSingleton<AuthentificationOptions>();
builder.Services.AddSingleton<IUnitOfWork, LocalUnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
