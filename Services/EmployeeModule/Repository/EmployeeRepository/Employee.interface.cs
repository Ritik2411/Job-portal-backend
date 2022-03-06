using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;

namespace EmployeeModule.Repository{
    public interface IEmployee{
        Task<Employee> AddEmployeeAsync(EmployeeModel employeeModel);
        Task<List<Employee>> getAllEmployeeAsync();
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAync(int id,EmployeeModel employeeModel);
    }
}