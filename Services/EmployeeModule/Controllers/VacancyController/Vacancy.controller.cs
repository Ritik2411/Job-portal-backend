using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using EmployeeModule.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeModule.Controller{
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyDetailController : ControllerBase{
        private readonly IVacancyDetail _vacancy;

        public VacancyDetailController(IVacancyDetail vacancyDetail){
            _vacancy = vacancyDetail;    
        }

        [HttpPost]
        //Calls AddVacancyAsync from IVacancyDetail.
        public async Task<IActionResult> AddVacancyDetail(VacancyDetail vacancyDetailModel){
            await _vacancy.AddVacancyAsync(vacancyDetailModel);
            return Ok(true);
        }

        [HttpGet]
        //Calls getVacancyListAsync from IVacancyDetail.
        public async Task<IActionResult> getVacancy([FromQuery]string sortOrder, [FromQuery]int pageSize, [FromQuery]int page){
            var result = await _vacancy.getVacancyListAsync(sortOrder, pageSize, page);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        //Calls deleteVacancyAsync from IVacancyDetail.
        public async Task<IActionResult> deleteVacancy([FromRoute]int id){
            await _vacancy.deleteVacancyAsync(id);
            return Ok(true);
        }

        [HttpPut("{id}")]
        //Calls updateVacancyAsync from IVacancyDetail.
        public async Task<IActionResult> updateVacancy([FromRoute]int id,[FromBody]VacancyDetailModel vacancyDetailModel){
           await _vacancy.updateVacancyAsync(id, vacancyDetailModel);
           return Ok(true);
        }

        [HttpGet("{user_id}")]
        //Calls updateVacancyAsync from IVacancyDetail.        
        public async Task<IActionResult> getVacancyByUserId([FromRoute]string user_id, [FromQuery]string sortOrder = "default",[FromQuery]int page_size = 5,[FromQuery]int page = 1){
            var result = await _vacancy.getVacanyByUserIdAsync(user_id, sortOrder, page_size, page);
            return Ok(result);
        }

        [HttpGet("vacancy/{id}")]
        //Calls getVacanyByIdAsync from IVacancyDetail.
        public async Task<IActionResult> getVacancyById([FromRoute]int id){
            var result = await _vacancy.getVacanyByIdAsync(id);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        //Calls UpdateVacancyPatchAsync from IVacancyDetail.
        public async Task<IActionResult> updateVacancyPatch([FromRoute]int id, [FromBody]JsonPatchDocument vacancyModel){
            await _vacancy.UpdateVacancyPatchAsync(id, vacancyModel);
            return Ok(true);    
        }
    }
}