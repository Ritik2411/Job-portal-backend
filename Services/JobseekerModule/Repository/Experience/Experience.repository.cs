using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;
using Microsoft.EntityFrameworkCore;

namespace JobseekerModule.repository{
    public class ExperienceRepository : IExperience{
        private readonly ExperienceContext _context;
        public ExperienceRepository(ExperienceContext context){
            _context = context;
        }

        public async Task AddUserExperienceAsync(ExperienceModel experienceModel){
            var experience = new Experience(){
                user_id = experienceModel.user_id,
                company_name = experienceModel.company_name,
                start_year = experienceModel.start_year,
                end_year = experienceModel.end_year,
                CompanyUrl = experienceModel.CompanyUrl,
                Designation = experienceModel.Designation,
                JobDescription = experienceModel.JobDescription
            };

            _context.experience.Add(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExperienceModel>> GetUserExperienceByIdAsync(string id){
            var result = await _context.experience.Where(x=> x.user_id == id).Select(x => new ExperienceModel(){
                 id = x.Id,
                 user_id = x.user_id,
                 company_name = x.company_name,
                 start_year = x.start_year,
                 end_year = x.end_year,
                 CompanyUrl = x.CompanyUrl,
                 Designation = x.Designation,
                 JobDescription = x.JobDescription
            }).ToListAsync();
            
            return result;
        }

        public async Task UpdateExperienceById(int id, ExperienceModel experienceModel){
            var result = await _context.experience.FindAsync(id);
            if(result != null){
                result.company_name = experienceModel.company_name;
                result.Designation = experienceModel.Designation;
                result.end_year = experienceModel.end_year;
                result.start_year = experienceModel.start_year;
                result.JobDescription = experienceModel.JobDescription;
                result.CompanyUrl = experienceModel.CompanyUrl;
    
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteExperienceByIdAsync(int id){
            var experience = new Experience(){
                Id = id
            };

            _context.experience.Remove(experience);
            await _context.SaveChangesAsync();
        }
    }
}