using System.ComponentModel.DataAnnotations;

namespace IdentityModule.models{
    public class ChangePasswordModel{
        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        public string current_password { get;set; } 
        
        [Required]
        public string password { get;set; }
    }
}