using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var authenticationOptions = new AuthentificationOptions(configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults)

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class AuthentificationOptions(IConfiguration configuration)
{
    public string ISSUER { get; } = configuration["JWTBearer:ISSUER"] ?? throw new Exception("\"ISSUER\" not found in configuration");

    public string AUDIENCE { get; } = configuration["JWTBearer:AUDIENCE"] ?? throw new Exception("\"ISSUER\" not found in configuration");
    public string KEY { get; } = configuration["JWTBearer:KEY"] ?? throw new Exception("\"ISSUER\" not found in configuration");
    public SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}
