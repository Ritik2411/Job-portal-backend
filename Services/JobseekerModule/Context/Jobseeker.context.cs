using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.context{
    public class JobseekerContext : DbContext{
        public JobseekerContext(DbContextOptions<JobseekerContext> options) : base(options){

        } 

        public DbSet<JobSeeker> jobSeeker { get;set; }
    }
}