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
         public async Task<IActionResult> AddVacancyRequests(VacancyRequests vacancyRequests){
             await _requests.AddVacancyRequestsAsync(vacancyRequests);
             return Ok(true);
         }

         [HttpGet]   
         public async Task<IActionResult> getVacancyRequests(){
             var result = await _requests.GetVacancyRequestsAsync();
             return Ok(result);
         }

         [HttpGet("{user_id}")]   
         public async Task<IActionResult> getVacancyRequestsByUserId(string user_id){
             var result = await _requests.GetVacancyRequestsByUserIdAsync(user_id);
             return Ok(result);
         }

         [HttpGet("vacancies/{id}")]   
         public async Task<IActionResult> getVacancyRequestsById(int id){
             var result = await _requests.GetVacancyRequestsByIdAsync(id);
             return Ok(result);
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> deleteVacancyRequests(int id){
             await _requests.DeleteVacancyRequestsAsync(id);
             return Ok(true);
         }

         [HttpPatch("vacancies/{id}")]
         public async Task<IActionResult> updateVacancyPatchById(int id, JsonPatchDocument vacancyRequest){
             await _requests.VacancyPatchUpdateByIdAsync(id, vacancyRequest);
             return Ok(true);
         }
    }
}