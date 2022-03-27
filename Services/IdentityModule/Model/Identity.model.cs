using Microsoft.AspNetCore.Identity;

namespace IdentityModule.models{
    //Adds first name, last name and role with all default columns of identityCore in Identity table.
    public class IdentityModel : IdentityUser{
        public string firstName { get;set; }
        public string lastName { get;set; }
        public string role { get;set; }
    }
}