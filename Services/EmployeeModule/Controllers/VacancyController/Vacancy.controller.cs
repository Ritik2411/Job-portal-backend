using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using EmployeeModule.Repository;
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
        public async Task<IActionResult> AddVacancyDetail(VacancyDetail vacancyDetailModel){
            await _vacancy.AddVacancyAsync(vacancyDetailModel);
            return Ok(true);
        }

        [HttpGet]
        public async Task<IActionResult> getVacancy(){
            var result = await _vacancy.getVacancyListAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteVacancy([FromRoute]int id){
            await _vacancy.deleteVacancyAsync(id);
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateVacancy([FromRoute]int id,[FromBody]VacancyDetailModel vacancyDetailModel){
           await _vacancy.updateVacancyAsync(id, vacancyDetailModel);
           return Ok(true);
        }

        [HttpGet("{user_id}")]
        public async Task<IActionResult> getVacancyById([FromRoute]string user_id){
            var result = await _vacancy.getVacanyByUserIdAsync(user_id);
            return Ok(result);
        }
    }
}