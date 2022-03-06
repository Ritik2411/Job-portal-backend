using System.ComponentModel.DataAnnotations;

namespace IdentityModule.models{
    public class LoginModel{
        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        public string password { get;set; }
    }
}