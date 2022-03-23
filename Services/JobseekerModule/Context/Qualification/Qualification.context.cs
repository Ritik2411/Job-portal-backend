using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.context{
    public class QualificationContext : DbContext{
        public QualificationContext(DbContextOptions<QualificationContext> options) : base(options){

        }

        public DbSet<Qualification> qualification { get;set; }
    }
}