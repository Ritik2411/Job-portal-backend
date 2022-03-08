using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Repository{
    public class VacancyRequestsRepository : IVacancyRequests{
        private readonly VacancyRequestsContext _context;
        public VacancyRequestsRepository(VacancyRequestsContext vacancyRequestsContext){
            _context = vacancyRequestsContext;
        }

        public async Task AddVacancyRequestsAsync(VacancyRequests vacancyRequestsModel){
            var data = new VacancyRequests(){
                user_id = vacancyRequestsModel.user_id,
                vacancy_id = vacancyRequestsModel.vacancy_id,
                applied_on = vacancyRequestsModel.applied_on
            }; 

            _context.vacancyRequests.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VacancyRequests>> GetVacancyRequestsAsync(){
           var result = await _context.vacancyRequests.Select(x => new VacancyRequests(){
               id = x.id,
               user_id = x.user_id,
               vacancy_id = x.vacancy_id,
               applied_on = x.applied_on
           }).ToListAsync();

           return result;
        }

        public async Task<List<VacancyRequestsModel>> GetVacancyRequestsByIdAsync(int id){
            var result = await _context.vacancyRequests.Where(x => x.id == id).Select(x => new VacancyRequestsModel(){
                user_id = x.user_id,
                vacany_id = x.vacancy_id,
                applied_on = x.applied_on
            }).ToListAsync();
            
            return result;
        }
    }
}