using System.Threading.Tasks;
using JobseekerModule.models;
using JobseekerModule.repository;
using Microsoft.AspNetCore.Mvc;

namespace JobseekerModule.controller{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase{
        private readonly IExperience _experience;
        public ExperienceController(IExperience experience){
            _experience = experience;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserExperience(ExperienceModel experienceModel){
            await _experience.AddUserExperienceAsync(experienceModel);
            return Ok(true);
        }

        [HttpGet("{user_id}")]
        public async Task<IActionResult> getUserExperienceById([FromRoute]string user_id){
            var result = await _experience.GetUserExperienceByIdAsync(user_id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateExperienceById([FromRoute]int id, [FromBody]ExperienceModel experienceModel){
            await _experience.UpdateExperienceById(id, experienceModel);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id){
            await _experience.DeleteExperienceByIdAsync(id);
            return Ok(true);
        }
    } 
}