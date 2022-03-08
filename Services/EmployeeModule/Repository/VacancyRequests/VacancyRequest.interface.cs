using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;

namespace EmployeeModule.Repository{
    public interface IVacancyRequests{
        Task AddVacancyRequestsAsync(VacancyRequests vacancyRequests);
        Task<List<VacancyRequestsModel>> GetVacancyRequestsByIdAsync(int id);
        Task<List<VacancyRequests>> GetVacancyRequestsAsync();
    }
}