using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeModule.Repository{
    public interface IVacancyRequests{
        Task AddVacancyRequestsAsync(VacancyRequests vacancyRequests);
       Task<List<VacancyRequests>> GetVacancyRequestsByUserIdAsync(string user_id);
        Task<List<VacancyRequests>> GetVacancyRequestsAsync();
        Task DeleteVacancyRequestsAsync(int id);
        Task<VacancyRequests> GetVacancyRequestsByIdAsync(int id);
        Task VacancyPatchUpdateByIdAsync(int id, JsonPatchDocument vacancyRequest);
    }
}