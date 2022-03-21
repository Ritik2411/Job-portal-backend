using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Repository{

    //EmployeeRepository implements IEmployee and defines all its methods.
    public class EmployeeRepository : IEmployee{
        //Used to create an instance of class EmployeeContext to access its members.
        private readonly EmployeeContext _employee;

        public EmployeeRepository(EmployeeContext employee){
            _employee = employee;
        }

        //Handles adding an employee    
        public async Task<Employee> AddEmployeeAsync(Employee employeeModel){
            var employee = new Employee(){
                id = employeeModel.id,
                Organization = employeeModel.Organization,
                OrganizationType = employeeModel.OrganizationType,
                CompanyEmail = employeeModel.CompanyEmail, 
                CompanyPhone = employeeModel.CompanyPhone,
                NoOfEmployee = employeeModel.NoOfEmployee,
                StartYear = employeeModel.StartYear,
                about = employeeModel.about,
                createdBy = employeeModel.createdBy
            };
            _employee.employee.Add(employee); 
            await _employee.SaveChangesAsync();

            return employee;
        }

        //Provides list of all employees.
        public async Task<List<Employee>> getAllEmployeeAsync(){
            var result = await _employee.employee.Select(x => new Employee(){
                id = x.id,
                Organization = x.Organization,
                OrganizationType = x.OrganizationType,
                CompanyEmail = x.CompanyEmail,
                CompanyPhone = x.CompanyPhone,
                NoOfEmployee = x.NoOfEmployee,
                StartYear = x.StartYear,
                about = x.about,
                createdBy = x.createdBy
            }).ToListAsync();

            return result;
        }

        // Deletes employee based on id(PK).
        public async Task DeleteEmployeeAsync(string id){
            var employee = new Employee(){
                id = id
            }; 

            _employee.employee.Remove(employee);
            
            await _employee.SaveChangesAsync();
        }    

        // Updates employee based on id(PK) and adds new data that is being received from the request.
        public async Task UpdateEmployeeAync(string id,EmployeeModel employeeModel){
            var employee = await _employee.employee.FindAsync(id);

            if(employee != null){
                employee.Organization = employeeModel.Organization;
                employee.OrganizationType = employeeModel.OrgnizationType;
                employee.CompanyEmail = employeeModel.CompanyEmail;
                employee.CompanyPhone = employeeModel.CompanyPhone;
                employee.NoOfEmployee = employeeModel.NoOfEmployees;
                employee.StartYear = employeeModel.StartYear;
                employee.about = employeeModel.About;
                employee.createdBy = employeeModel.CreatedBy;

                await _employee.SaveChangesAsync();
            }
        }

        //Provides detail of a particular employee based on their unique user_id.
        public async Task<List<Employee>> getEmlpoyeeByIdAsync(string id){
            var result = await _employee.employee.Where(x => x.id == id).Select(x => new Employee(){
                id = x.id,
                Organization = x.Organization,
                OrganizationType = x.OrganizationType,
                CompanyEmail = x.CompanyEmail,
                CompanyPhone = x.CompanyPhone,
                NoOfEmployee = x.NoOfEmployee,
                StartYear = x.StartYear,
                about = x.about,
                createdBy = x.createdBy
            }).ToListAsync();

            return result;
        }
    }
}