using System.ComponentModel.DataAnnotations;

namespace IdentityModule.models{
    public class UpdateProfileModel{
        
        [Required]
        public string first_name { get;set; }
        [Required]
        public string last_name { get;set; }
    }
}