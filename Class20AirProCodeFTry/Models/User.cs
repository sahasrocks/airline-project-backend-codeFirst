using System.ComponentModel.DataAnnotations;

namespace Class20AirProCodeFTry.Models
{
    public class User
    {
        [Key]
        public string username { get; set; } = null!;

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match")]
        public string ConfirmPassword { get; set; } = null!;
        public string? Role { get; set; }

    }
}
