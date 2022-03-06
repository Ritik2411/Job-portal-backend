using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Context{
    public class VacancyDetailContext : DbContext {
        public VacancyDetailContext(DbContextOptions<VacancyDetailContext> options) : base(options){}

        public DbSet<VacancyDetail> vacancies { get;set; }
    }
}