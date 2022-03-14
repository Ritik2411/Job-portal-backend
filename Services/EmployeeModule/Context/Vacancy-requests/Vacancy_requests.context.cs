using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Context{
    public class VacancyRequestsContext : DbContext{
        public VacancyRequestsContext(DbContextOptions<VacancyRequestsContext> options) : base(options){

        }
        
        public DbSet<VacancyRequests> vacancyRequests { get;set; } 
    }
}