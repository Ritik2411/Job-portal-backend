using System.Collections.Generic;
using System.Threading.Tasks;
using JobseekerModule.context;
using JobseekerModule.models;

namespace JobseekerModule.repository{
    public interface IExperience{
        Task AddUserExperienceAsync(ExperienceModel experienceModel);
        Task<List<Experience>> GetUserExperienceByIdAsync(string id);
        Task UpdateExperienceById(int id, ExperienceModel experienceModel);
        Task DeleteExperienceByIdAsync(int id);
    }
}