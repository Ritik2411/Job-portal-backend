using System.ComponentModel.DataAnnotations;

namespace IdentityModule.models{
    public class RegisterModel{
        [Required]
        public string userName { get;set; }
        
        [Required]
        public string firstName { get;set; }
        
        [Required]
        public string lastName { get;set; }
        
        [Required]
        [EmailAddress]
        public string Email { get;set; }
        
        [Required]
        public string Role { get;set; }
        [Required]
        [Compare("conformPassword")]
        public string password { get;set; }
        
        [Required]
        public string conformPassword { get;set; } 
    }
}