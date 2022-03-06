using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Context{
    public class EmployeeContext : DbContext{
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options){

        }

        public DbSet<Employee> employee { get;set; }
    }
}