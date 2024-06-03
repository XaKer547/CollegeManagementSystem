using Duende.IdentityServer.AspNetIdentity;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO;
using SmartCollege.SSO.Data;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.HostedServices;
using SmartCollege.SSO.Models.Commands;
using SmartCollege.SSO.Shared;
using SmartCollege.SSO.Validators;
using SmartCollege.SSO.Validators.AccountCommands;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x =>
{
    x.AddSeq(builder.Configuration.GetSection("SeqLogging"));
});

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateRepresentativeOfCompanyCommand>, CreateAccountCommandValidator>();
builder.Services.AddScoped<IValidator<UpdatePasswordCommand>, UpdatePasswordCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateRepresentativeOfCompanyCommand>, UpdateAccountCommandValidator>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program).Assembly);

    x.UsingRabbitMq((context, conf) =>
    {
        conf.Host("localhost", 5672, "/", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
        conf.ConfigureEndpoints(context);
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder
        .WithOrigins("https://localhost:7137")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAntiforgery();

var identitySettings = builder.Configuration.GetRequiredSection(nameof(IdentityServerSettings))
                                            .Get<IdentityServerSettings>()!;

//var migrationsAssembly = Assembly.GetExecutingAssembly().GetName().Name;

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("RepresentationRolePolicy", x =>
    {
        x.RequireClaim(ClaimsIdentity.DefaultRoleClaimType, Roles.RepresentativeOfTheCompany.ToString());
    });
});

builder.Services.AddDbContext<AuthorizationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("LocalConnection");

    options.UseNpgsql(connectionString);
});

builder.Services.AddHostedService<ApplyMigrationService>();
builder.Services.AddHostedService<InizializationRoleBGService>();

builder.Services.AddIdentity<AccountIdentity, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Lockout.AllowedForNewUsers = false;

    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
})
    .AddEntityFrameworkStores<AuthorizationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
})
   .AddInMemoryApiResources(identitySettings.ApiResources)
   .AddInMemoryApiScopes(identitySettings.ApiScopes)
   .AddInMemoryClients(identitySettings.Clients)
   .AddInMemoryIdentityResources(identitySettings.IdentityResources)
   .AddAspNetIdentity<AccountIdentity>()
   .AddResourceOwnerValidator<AccountOwnerPasswordValidator>()
   .AddProfileService<ProfileService<AccountIdentity>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors();

app.UseAntiforgery();
app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers()
    .RequireCors();

app.Run();
