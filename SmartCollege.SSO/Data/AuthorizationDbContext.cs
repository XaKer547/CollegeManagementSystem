using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Data.Entities;

namespace SmartCollege.SSO.Data;

public class AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> options) : IdentityDbContext<AccountIdentity, IdentityRole, string>(options)
{
    public DbSet<RepresentationOfTheCompany> RepresentationOfTheCompanies => Set<RepresentationOfTheCompany>();
}
