using System.ComponentModel.DataAnnotations;

namespace InternForge.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Account type")]
        public string Role { get; set; } = "Student"; // "Student" or "SME"

        // Common fields
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        // Optional for both
        [Phone]
        [Display(Name = "Phone (optional)")]
        public string? Phone { get; set; }

        // Optional, SME-only (we will hide/show in UI)
        [Display(Name = "Organization name (optional)")]
        public string? OrgName { get; set; }
    }
}
