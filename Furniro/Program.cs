using Application;
using Application.Common.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.GlobalExceptionHandlingMiddleware;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(v => v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token} \")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
builder.Services.AddScoped<IApplicationDbContext, AppDbContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AdminMapper(provider.GetService<IHttpContextAccessor>()));
}).CreateMapper());

//builder.Services.AddSingleton<InputHasher>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//Logger log = new LoggerConfiguration()
//    .WriteTo.File("h:/root/home/immutable858-001/www/furniro/logs/log.txt")
//    .Enrich.FromLogContext()
//    .MinimumLevel.Information()
//    .CreateLogger();

//builder.Host.UseSerilog(log);

builder.Services.AddApplicationServices();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(
   builder => builder.RegisterModule(new AutoFacBusiness()));

var app = builder.Build();

#region Middleware
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());
app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();
app.UseCors("AllowFrontend");
app.Run();
#endregion
