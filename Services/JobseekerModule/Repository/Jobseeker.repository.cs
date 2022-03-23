using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;
using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.repository{
    public class JobseekerRepository : IJobSeeker{
        private readonly JobseekerDetailContext _context;
        
        public JobseekerRepository(JobseekerDetailContext context){
            _context = context;
        }

        public async Task AddJobSeekerAsync(JobSeekerModel jobseekerdata){
            var data = new JobSeekerDetail(){
                user_id = jobseekerdata.user_id,
                first_name = jobseekerdata.first_name,
                last_name = jobseekerdata.last_name,
                email = jobseekerdata.email,
                phone = jobseekerdata.phone,
                address = jobseekerdata.address,
                total_expericence = jobseekerdata.total_expericence,
                expected_salary = jobseekerdata.expected_salary,
                dob = jobseekerdata.dob
            };

            _context.jobSeeker.Add(data); 

            await _context.SaveChangesAsync();
        }

        public async Task<List<JobSeekerModel>> GetJobSeekerByUserIdAsync(string id){
            var data = await _context.jobSeeker.Where(x => x.user_id == id).Select((x) => new JobSeekerModel(){
                user_id = x.user_id,
                first_name = x.first_name,
                last_name = x.last_name,
                email = x.email,
                phone = x.phone,
                address = x.address,
                total_expericence = x.total_expericence,
                expected_salary = x.expected_salary,
                dob = x.dob
            }).ToListAsync();

           return data;            
        }

        public async Task UpdateJobSeekerById(string id, JobSeekerModel jobSeekerModel){
            var result = await _context.jobSeeker.FindAsync(id);
            
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

        public async Task DeleteJobSeekerByUserIdAsync(string id){
            var jobseeker = new JobSeekerDetail(){
                user_id = id
            };

            _context.jobSeeker.Remove(jobseeker);
            await _context.SaveChangesAsync();
        }
    }
}