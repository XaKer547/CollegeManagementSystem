using Microsoft.AspNetCore.Identity;

namespace SmartCollege.SSO.Data.Entities
{
    public class AccountIdentity : IdentityUser
    {
        public bool ChangeTempPassword { get; set; }
    }
}
