using BlazorApp.Definitions;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
