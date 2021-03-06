using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeModule.Repository{
    public interface IVacancyDetail{
        Task AddVacancyAsync(VacancyDetail vacancyDetailModel);
        Task<ResponeseModel> getVacancyListAsync(string pub_name,string min_salary, string max_salary,string sortOrder, int page, int page_size);
        Task deleteVacancyAsync(int id);
        Task updateVacancyAsync(int id, VacancyDetailModel vacancyDetailModel);
        Task<ResponeseModel> getVacanyByUserIdAsync(string user_id, string experience, string pub_date,string sortOrder,int pageSize, int page = 1);
        Task<List<VacancyDetail>> getVacanyByIdAsync(int id);
        Task UpdateVacancyPatchAsync(int id, JsonPatchDocument vacancyModel);
    }
}