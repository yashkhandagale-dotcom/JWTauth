using System.ComponentModel.DataAnnotations;

namespace UserCRUDandJWT.DTOs
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,20}$", ErrorMessage = "Password must be 6-20 chars, include uppercase, lowercase, digit, and special character")]
        public string Password { get; set; } = null!;
    }
}
