

using Microsoft.AspNetCore.Identity;

namespace Vaajak.Domain.Entities
{
    internal class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
