using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeModule.Repository{
    public interface IVacancyRequests{
        Task AddVacancyRequestsAsync(VacancyRequests vacancyRequests);
        Task<List<VacancyRequests>> getallVacancyRequestsByUserIdAsync(string user_id);
        Task<ResponeseModel> GetVacancyRequestsByUserIdAsync(string user_id, string sort_by_date, int page_index, int page = 1);
        Task<List<VacancyRequests>> GetVacancyRequestsAsync();
        Task DeleteVacancyRequestsAsync(int id);
        Task<VacancyRequests> GetVacancyRequestsByIdAsync(int id);
        Task VacancyPatchUpdateByIdAsync(int id, JsonPatchDocument vacancyRequest);
        Task<ResponeseModel> GetVacancyRequestsByPublisherNameAsync(string user_name, string search, string sort_order, int page_size, int page);
    }
}