using Microsoft.AspNetCore.Identity;

namespace IdentityModule.models{
    public class IdentityModel : IdentityUser{
        public string firstName { get;set; }
        public string lastName { get;set; }
        public string role { get;set; }
    }
}