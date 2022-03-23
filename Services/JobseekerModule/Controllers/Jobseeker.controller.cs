using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;
using JobseekerModule.repository;
using Microsoft.AspNetCore.Mvc;

namespace JobseekerModule.controller{
    [ApiController]
    [Route("api/[controller]")]
    public class JobSeekerController : ControllerBase{
        private readonly IJobSeeker _jobseeker;
        public JobSeekerController(IJobSeeker jobseeker){
            _jobseeker = jobseeker;
        }

        [HttpPost]
        public async Task<IActionResult> addJobseeker(JobSeekerModel jobseekerdata){
            await _jobseeker.AddJobSeekerAsync(jobseekerdata);
            return Ok(true);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getJobseekerById([FromRoute]string id){
            var result = await _jobseeker.GetJobSeekerByUserIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateJobSeekerById([FromRoute]string id,[FromBody]JobSeekerModel jobSeekerModel){
            await _jobseeker.UpdateJobSeekerById(id, jobSeekerModel);
            return Ok(true);
        }   

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteJobSeekerById(string id){
            await _jobseeker.DeleteJobSeekerByUserIdAsync(id);
            return Ok(true);
        }
    }
}