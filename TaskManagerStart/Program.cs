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
using UseCase.UserServices.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

#if DEBUG
builder.Configuration.AddJsonFile("DbConnection.json", optional: false, reloadOnChange: true);
#endif

var authenticationOptions = new AuthentificationOptions(builder.Configuration);

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
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<ICryptService, CryptService>();

builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient(typeof(IPaginationService<>), typeof(PaginationService<>));
builder.Services.AddTransient<IProjectTaskService, ProjectTaskService>();

builder.Services.AddSingleton<AuthentificationOptions>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddValidatorsFromAssembly(typeof(UseCase.Database.IUnitOfWork).Assembly);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
