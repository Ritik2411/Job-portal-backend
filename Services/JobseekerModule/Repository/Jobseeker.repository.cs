using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;

namespace JobseekerModule.repository{
    public class JobseekerRepository : IJobSeeker{
        private readonly JobseekerContext _context;
        
        public JobseekerRepository(JobseekerContext context){
            _context = context;
        }

        public async Task AddJobSeekerAsync(JobSeeker jobseekerdata){
            var jobseeker = new JobSeeker(){
                id = jobseekerdata.id,
                first_name = jobseekerdata.first_name,
                last_name = jobseekerdata.last_name,
                email = jobseekerdata.email,
                phone = jobseekerdata.phone,
                address = jobseekerdata.address,
                total_expericence = jobseekerdata.total_expericence,
                expected_salary = jobseekerdata.expected_salary,
                dob = jobseekerdata.dob
            };

            _context.jobSeeker.Add(jobseeker); 

            await _context.SaveChangesAsync();
        }

        public async Task<JobSeekerModel> GetJobSeekerByIdAsync(string user_id){
            var data = await _context.jobSeeker.FindAsync(user_id);

            var jobseeker = new JobSeekerModel(){
                first_name = data.first_name,
                last_name = data.last_name,
                email = data.email,
                phone = data.phone,
                address = data.address,
                total_expericence = data.total_expericence,
                expected_salary = data.expected_salary,
                dob = data.dob
            };
           return jobseeker;            
        }

        public async Task UpdateJobSeekerById(string user_id, JobSeekerModel jobSeekerModel){
            var result = await _context.jobSeeker.FindAsync(user_id);
            
            if(result != null){
                result.address = jobSeekerModel.address;
                result.dob = jobSeekerModel.dob;
                result.email = jobSeekerModel.email;
                result.expected_salary = jobSeekerModel.expected_salary;
                result.first_name = jobSeekerModel.first_name;
                result.last_name = jobSeekerModel.last_name;
                result.phone = jobSeekerModel.phone;
                result.total_expericence = jobSeekerModel.total_expericence;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteJobSeekerByIdAsync(string user_id){
            var jobseeker = new JobSeeker(){
                id = user_id
            };

            _context.jobSeeker.Remove(jobseeker);
            await _context.SaveChangesAsync();
        }
    }
}