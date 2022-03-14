using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeModule.Repository{
    public interface IVacancyDetail{
        Task AddVacancyAsync(VacancyDetail vacancyDetailModel);
        Task<List<VacancyDetail>> getVacancyListAsync();
        Task deleteVacancyAsync(int id);
        Task updateVacancyAsync(int id, VacancyDetailModel vacancyDetailModel);
        Task<List<VacancyDetail>> getVacanyByUserIdAsync(string user_id);
        Task<List<VacancyDetail>> getVacanyByIdAsync(int id);
        Task UpdateVacancyPatchAsync(int id, JsonPatchDocument vacancyModel);
    }
}