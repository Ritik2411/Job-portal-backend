using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Repository;
using Microsoft.AspNetCore.JsonPatch;
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
         //Calls AddVacancyRequestsAsync from IVacancyRequests.
         public async Task<IActionResult> AddVacancyRequests(VacancyRequests vacancyRequests){
             await _requests.AddVacancyRequestsAsync(vacancyRequests);
             return Ok(true);
         }

         [HttpGet]   
         //Calls GetVacancyRequestsAsync from IVacancyRequests.
         public async Task<IActionResult> getVacancyRequests(){
             var result = await _requests.GetVacancyRequestsAsync();
             return Ok(result);
         }

         [HttpGet("{user_id}")] 
         //Calls GetVacancyRequestsByUserIdAsync from IVacancyRequests.   
         public async Task<IActionResult> getVacancyRequestsByUserId(string user_id,[FromQuery]string sort_by_date){
             var result = await _requests.GetVacancyRequestsByUserIdAsync(user_id, sort_by_date);
             return Ok(result);
         }

         [HttpGet("vacancies/{id}")]
         //Calls GetVacancyRequestsByIdAsync from IVacancyRequests.   
         public async Task<IActionResult> getVacancyRequestsById(int id){
             var result = await _requests.GetVacancyRequestsByIdAsync(id);
             return Ok(result);
         }

         [HttpDelete("{id}")]
         //Calls DeleteVacancyRequestsAsync from IVacancyRequests.
         public async Task<IActionResult> deleteVacancyRequests(int id){
             await _requests.DeleteVacancyRequestsAsync(id);
             return Ok(true);
         }

         [HttpPatch("vacancies/{id}")]
         //Calls VacancyPatchUpdateByIdAsync from IVacancyRequests.   
         public async Task<IActionResult> updateVacancyPatchById(int id, JsonPatchDocument vacancyRequest){
             await _requests.VacancyPatchUpdateByIdAsync(id, vacancyRequest);
             return Ok(true);
         }
    }
}