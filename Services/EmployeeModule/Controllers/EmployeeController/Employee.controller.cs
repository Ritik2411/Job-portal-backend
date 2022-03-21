using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using EmployeeModule.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeModule.Controller{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDetailController : ControllerBase{
        private readonly IEmployee _employee;
        public EmployeeDetailController(IEmployee employee){
            _employee = employee;
        }

        [HttpPost]
        //Calls AddEmployeeAsync from IEmployee.
        public async Task<IActionResult> AddEmployee([FromBody]Employee employeeModel){
            var result = await _employee.AddEmployeeAsync(employeeModel);
            if(result != null){
                return Ok(result);
            }
            else{
                return Unauthorized();
            }
        }

        [HttpGet]
        //Calls AddEmployeeAsync from IEmployee.
        public async Task<IActionResult> getAllEmployee(){
            var result = await _employee.getAllEmployeeAsync();
            if(result != null){
                return Ok(result);
            }
            else{
                return Unauthorized();
            }
        }
        
        [HttpDelete("{id}")]
        //Calls DeleteEmployeeAsync from IEmployee.
        public async Task<IActionResult> DeleteEmployee([FromRoute]string id){
            await _employee.DeleteEmployeeAsync(id);    
            return Ok(true);
        }
        
        [HttpPut("{id}")]
        //Calls UpdateEmployeeAync from IEmployee.
        public async Task<IActionResult> updateEmployee([FromRoute]string id, [FromBody]EmployeeModel employeeModel){
            await _employee.UpdateEmployeeAync(id,employeeModel);
            return Ok(true);
        }

        [HttpGet("{id}")]
        //Calls getEmlpoyeeByIdAsync from IEmployee.
        public async Task<IActionResult> getEmployeeById([FromRoute]string id){
            var result = await _employee.getEmlpoyeeByIdAsync(id);
            return Ok(result);
        }
    }
}