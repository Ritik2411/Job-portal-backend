using System.Threading.Tasks;
using JobseekerModule.models;
using JobseekerModule.repository;
using Microsoft.AspNetCore.Mvc;

namespace JobseekerModule.controller{
    [ApiController]
    [Route("[action]")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> getUserExperienceById([FromRoute]string id){
            var result = await _experience.GetUserExperienceByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateExperienceById([FromRoute]int id, [FromBody]ExperienceModel experienceModel){
            await _experience.UpdateExperienceById(id, experienceModel);
            return Ok(true);
        }
    } 
}