using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.context{
    public class ExperienceContext : DbContext{
        public ExperienceContext(DbContextOptions<ExperienceContext> options) : base(options){

        }

        public DbSet<Experience> experience { get;set; }
    }
}