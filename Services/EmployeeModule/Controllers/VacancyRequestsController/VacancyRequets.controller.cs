using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeModule.Controller{
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyRequestsController : ControllerBase{
         private readonly IVacancyRequests _requests;
         public VacancyRequestsController(IVacancyRequests vacancyRequests){
             _requests = vacancyRequests;
         }    

         [HttpPost]   
         public async Task<IActionResult> AddVacancyRequests(VacancyRequests vacancyRequests){
             await _requests.AddVacancyRequestsAsync(vacancyRequests);
             return Ok(true);
         }

         [HttpGet]   
         public async Task<IActionResult> getVacancyRequests(){
             var result = await _requests.GetVacancyRequestsAsync();
             return Ok(result);
         }

         [HttpGet("{id}")]   
         public async Task<IActionResult> getVacancyRequestsById(int id){
             var result = await _requests.GetVacancyRequestsByIdAsync(id);
             return Ok(result);
         }
    }
}