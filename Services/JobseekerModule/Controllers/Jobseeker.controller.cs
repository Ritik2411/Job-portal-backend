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
        public async Task<IActionResult> addJobseeker(JobSeeker jobseekerdata){
            await _jobseeker.AddJobSeekerAsync(jobseekerdata);
            return Ok(true);
        }

        [HttpGet("{user_id}")]
        public async Task<IActionResult> getJobseekerById([FromRoute]string user_id){
            var result = await _jobseeker.GetJobSeekerByIdAsync(user_id);
            return Ok(result);
        }

        [HttpPut("{user_id}")]
        public async Task<IActionResult> updateJobSeekerById([FromRoute]string user_id,[FromBody]JobSeekerModel jobSeekerModel){
            await _jobseeker.UpdateJobSeekerById(user_id, jobSeekerModel);
            return Ok(true);
        }   

        [HttpDelete("{user_id}")]
        public async Task<IActionResult> deleteJobSeekerById(string user_id){
            await _jobseeker.DeleteJobSeekerByIdAsync(user_id);
            return Ok(true);
        }
    }
}