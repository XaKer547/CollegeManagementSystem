using CollegeManagementSystem.API.Middlewares;
using CollegeManagementSystem.API.Validators.Behaviors;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Infrastucture.Common;
using CollegeManagementSystem.Infrastucture.Data.UnitOfWork;
using CollegeManagementSystem.Infrastucture.EventDispatcher;
using CollegeManagementSystem.Infrastucture.Exctentions;
using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SharedKernel;
using System.Reflection;
using static IdentityModel.OidcConstants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(m =>
{
    var assembly = Assembly.Load("CollegeManagementSystem.Application");

    m.RegisterServicesFromAssembly(assembly);

    m.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddDbContext(builder.Configuration);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMassTransit(options =>
{
    options.UsingRabbitMq((context, conf) =>
    {
        conf.Host("localhost", 5672, "/", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder
        .WithOrigins("https://localhost:7096")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "oidc";
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "http://localhost:5213";

        options.RequireHttpsMetadata = false;

        options.ClientId = "CollegeManagementSystem.API";
        options.ClientSecret = "Тёлка-тёлка, дай мне рэп! Твою жопу крутит Муз-ТВ!";

        options.ResponseType = GrantTypes.ClientCredentials;

        options.Scope.Clear();
        options.Scope.Add("fullaccess");

        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
    });

builder.Services.AddScoped<ICollegeManagementSystemRepository, CollegeManagementSystemDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDomainEventDispatcher, CollegeManagementSystemEventDispatcher>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "College management system",
            Version = "v1",
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "College management system v1"));

app.UseReDoc(options =>
{
    options.DocumentTitle = "College management system v1";
    options.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireCors();

app.Run();
