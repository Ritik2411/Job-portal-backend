using System.ComponentModel.DataAnnotations;

namespace IdentityModule.models{
    public class LoginModel{
        [Required]
        public string Username { get;set; }

        [Required]
        public string password { get;set; }
    }
}