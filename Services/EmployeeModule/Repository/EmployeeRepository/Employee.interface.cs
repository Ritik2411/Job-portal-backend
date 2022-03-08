using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;

namespace EmployeeModule.Repository{
    public interface IEmployee{
        Task<Employee> AddEmployeeAsync(Employee employeeModel);
        Task<List<Employee>> getAllEmployeeAsync();
        Task DeleteEmployeeAsync(string id);
        Task UpdateEmployeeAync(string id,EmployeeModel employeeModel);
        Task<List<Employee>> getEmlpoyeeByIdAsync(string id);
    }
}