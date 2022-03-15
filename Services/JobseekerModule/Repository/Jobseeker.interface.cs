using System.Collections.Generic;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;

namespace JobseekerModule.repository{
    public interface IJobSeeker{
        Task AddJobSeekerAsync(JobSeeker jobseekerdata);
        Task<List<JobSeekerModel>> GetJobSeekerByUserIdAsync(string user_id);
        Task UpdateJobSeekerById(string user_id, JobSeekerModel jobSeekerModel);
        Task DeleteJobSeekerByUserIdAsync(string user_id);
    }
}