using System.ComponentModel.DataAnnotations;

namespace Vaajak.Application.Dto.Account
{
    public class SigninDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
