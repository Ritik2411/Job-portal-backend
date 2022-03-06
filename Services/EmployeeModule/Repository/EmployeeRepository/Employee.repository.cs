using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Repository{
    public class EmployeeRepository : IEmployee{

        private readonly EmployeeContext _employee;
        private readonly VacancyDetailContext _vacancy;

        public EmployeeRepository(EmployeeContext employee, VacancyDetailContext vacancy){
            _employee = employee;
            _vacancy = vacancy;
        }

        public async Task<Employee> AddEmployeeAsync(EmployeeModel employeeModel){
            var employee = new Employee(){
                Organization = employeeModel.Organization,
                OrganizationType = employeeModel.OrgnizationType,
                CompanyEmail = employeeModel.CompanyEmail, 
                CompanyPhone = employeeModel.CompanyPhone,
                NoOfEmployee = employeeModel.NoOfEmployees,
                StartYear = employeeModel.StartYear,
                about = employeeModel.About,
                createdBy = employeeModel.CreatedBy
            };
            _employee.employee.Add(employee); 
            await _employee.SaveChangesAsync();

            return employee;
        }

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

        public async Task DeleteEmployeeAsync(int id){
            var employee = new Employee(){
                id = id
            }; 

            _employee.employee.Remove(employee);
            
            await _employee.SaveChangesAsync();
        }    

        public async Task UpdateEmployeeAync(int id,EmployeeModel employeeModel){
            var employee = await _employee.employee.FindAsync(id);

            if(employee != null){
                employee.Organization = employeeModel.Organization;
                employee.OrganizationType = employee.OrganizationType;
                employee.CompanyEmail = employeeModel.CompanyEmail;
                employee.CompanyPhone = employeeModel.CompanyPhone;
                employee.NoOfEmployee = employeeModel.NoOfEmployees;
                employee.StartYear = employeeModel.StartYear;
                employee.about = employeeModel.About;
                employee.createdBy = employeeModel.CreatedBy;

                await _employee.SaveChangesAsync();
            }
        }
    }
}