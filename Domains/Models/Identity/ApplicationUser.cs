using Microsoft.AspNetCore.Identity;

namespace Domains.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        [MaxLength(20)]
        public override string? PhoneNumber { get; set; }

        public override string UserName { get; set; } = null!;

        public override string Email { get; set; } = null!;
    }
}
