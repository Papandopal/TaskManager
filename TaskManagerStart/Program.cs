using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TaskManagerStart;
using Infrastructure.Database;
using UseCase.UserServices;
using UseCase.Database;
using UseCase.UserServices.Services;
using UseCase.ProjectServices.Services;
using Microsoft.EntityFrameworkCore;
using UseCase.GeneralServices;
using UseCase.ProjectTaskServices.Services;

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
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = authenticationOptions.GetSymmetricSecurityKey(),
        ValidateLifetime = false,
    };
});

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<Mapper>();
});

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssembly(typeof(UseCase.Database.IUnitOfWork).Assembly);
});

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<JwtService>();
builder.Services.AddTransient<CryptService>();

builder.Services.AddTransient<ProjectService>();
builder.Services.AddTransient(typeof(PaginationService<>));
builder.Services.AddTransient<ProjectTaskService>();

builder.Services.AddSingleton<AuthentificationOptions>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
