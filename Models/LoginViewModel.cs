using System.ComponentModel.DataAnnotations;

namespace InternForge.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Account type")]
        public string Role { get; set; } = "Student"; // "Student" or "SME"

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
