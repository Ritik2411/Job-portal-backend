using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.context{
    public class JobseekerDetailContext : DbContext{
        public JobseekerDetailContext(DbContextOptions<JobseekerDetailContext> options) : base(options){

        } 

        public DbSet<JobSeekerDetail> jobSeeker { get;set; }
    }
}