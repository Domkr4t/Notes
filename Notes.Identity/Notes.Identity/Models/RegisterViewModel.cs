using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = default!;

        public string ReturnUrl { get; set; } = default!;
    }
}
