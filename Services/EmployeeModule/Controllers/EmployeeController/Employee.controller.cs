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
        public async Task<IActionResult> DeleteEmployee([FromRoute]string id){
            await _employee.DeleteEmployeeAsync(id);    
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateEmployee([FromRoute]string id, [FromBody]EmployeeModel employeeModel){
            await _employee.UpdateEmployeeAync(id,employeeModel);
            return Ok(true);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getEmployeeById([FromRoute]string id){
            var result = await _employee.getEmlpoyeeByIdAsync(id);
            return Ok(result);
        }
    }
}