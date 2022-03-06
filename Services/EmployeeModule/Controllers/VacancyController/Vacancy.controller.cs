using System.Threading.Tasks;
using EmployeeModule.Model;
using EmployeeModule.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeModule.Controller{
    [ApiController]
    [Route("[action]")]
    public class VacancyDetailController : ControllerBase{
        private readonly IVacancyDetail _vacancy;

        public VacancyDetailController(IVacancyDetail vacancyDetail){
            _vacancy = vacancyDetail;    
        }

        [HttpPost]
        public async Task<IActionResult> AddVacancyDetail(VacancyDetailModel vacancyDetailModel){
            var result = await _vacancy.AddVacancyAsync(vacancyDetailModel);
            return Ok(result);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> getVacancyById([FromRoute]int id){
            var result = await _vacancy.getVacanyByIdAsync(id);
            return Ok(result);
        }
    }
}