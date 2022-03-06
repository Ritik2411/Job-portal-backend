using IdentityModule.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityModule.context{
    public class IdentityContext : IdentityDbContext<IdentityModel>{
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) {
            
        }
    }
}