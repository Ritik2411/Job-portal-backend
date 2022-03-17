using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.context{
    public class CvContext : DbContext{
        public CvContext(DbContextOptions<CvContext> options) : base(options){}

        public DbSet<CV> cv { get;set; }
    }
}