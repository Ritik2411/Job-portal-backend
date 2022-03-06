using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;

namespace JobseekerModule.repository{
    public interface IJobSeeker{
        Task AddJobSeekerAsync(JobSeeker jobseekerdata);
        Task<JobSeekerModel> GetJobSeekerByIdAsync(string id);
        Task UpdateJobSeekerById(string user_id, JobSeekerModel jobSeekerModel);
    }
}