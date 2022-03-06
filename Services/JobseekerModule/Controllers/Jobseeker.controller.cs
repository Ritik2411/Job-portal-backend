using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;
using JobseekerModule.repository;
using Microsoft.AspNetCore.Mvc;

namespace JobseekerModule.controller{
    [ApiController]
    [Route("[action]")]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> getJobseekerById([FromRoute]string id){
            var result = await _jobseeker.GetJobSeekerByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateJobSeekerById([FromRoute]string id,[FromBody]JobSeekerModel jobSeekerModel){
            await _jobseeker.UpdateJobSeekerById(id, jobSeekerModel);
            return Ok(true);

        }   
    }
}