using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;

namespace EmployeeModule.Repository{
    public interface IVacancyDetail{
        Task<VacancyDetailModel> AddVacancyAsync(VacancyDetailModel vacancyDetailModel);
        Task<List<VacancyDetail>> getVacancyListAsync();

        Task deleteVacancyAsync(int id);
        Task updateVacancyAsync(int id, VacancyDetailModel vacancyDetailModel);
        Task<List<VacancyDetail>> getVacanyByIdAsync(int id);
    }
}