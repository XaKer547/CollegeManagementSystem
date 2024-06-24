using CollegeManagementSystem.API.HostedServices;
using CollegeManagementSystem.API.Middlewares;
using CollegeManagementSystem.API.SchemaFilters;
using CollegeManagementSystem.API.Validators.Behaviors;
using CollegeManagementSystem.Domain.Services;
using CollegeManagementSystem.Infrastucture.Common;
using CollegeManagementSystem.Infrastucture.Data.UnitOfWork;
using CollegeManagementSystem.Infrastucture.EventDispatcher;
using CollegeManagementSystem.Infrastucture.Extensions;
using FluentValidation;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SharedKernel;
using System.Reflection;
using System.Text.Json.Serialization;
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
        conf.Host("rabbitmq", 5672, "/", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
    });
});

builder.Services.AddCors(options =>
{
    var origins = builder.Configuration.GetValue<string>("AllowedOrigins")!
    .Split(';');

    options.AddDefaultPolicy(
        builder => builder
        .WithOrigins("https://smartcollege.sso")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true));
});
builder.WebHost.ConfigureKestrel(options =>
options.ConfigureHttpsDefaults(options => options.ClientCertificateMode = ClientCertificateMode.NoCertificate));
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "oidc";
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://smartcollege.sso";
        //builder.Configuration.GetValue<string>("SmartCollege.SSO.Base");

        options.RequireHttpsMetadata = false;

        options.ClientId = "CollegeManagementSystem.API";

        options.ClientSecret = "4d0dabf05d184decbbaae4acc9e89a81";

        options.ResponseType = GrantTypes.ClientCredentials;

        options.Scope.Clear();
        options.Scope.Add("fullaccess");

        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;

        var handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
        };

        options.BackchannelHttpHandler = handler;
    });

builder.Services.AddHostedService<DbMigrationWorker>();

builder.Services.AddScoped<ICollegeManagementSystemRepository, CollegeManagementSystemDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDomainEventDispatcher, CollegeManagementSystemEventDispatcher>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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

    options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
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
