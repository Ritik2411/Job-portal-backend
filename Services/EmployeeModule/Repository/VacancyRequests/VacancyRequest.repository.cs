using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;
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
                applied_on = vacancyRequestsModel.applied_on,
                awaiting_approval = vacancyRequestsModel.awaiting_approval,
                approved = vacancyRequestsModel.approved,
                user_name = vacancyRequestsModel.user_name
            }; 

            _context.vacancyRequests.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VacancyRequests>> GetVacancyRequestsAsync(){
           var result = await _context.vacancyRequests.Select(x => new VacancyRequests(){
               id = x.id,
               user_id = x.user_id,
               vacancy_id = x.vacancy_id,
               applied_on = x.applied_on,
               awaiting_approval = x.awaiting_approval,
               approved = x.approved,
               user_name = x.user_name
           }).ToListAsync();

           return result;
        }

        public async Task<List<VacancyRequests>> GetVacancyRequestsByUserIdAsync(string user_id){
            var result = await _context.vacancyRequests.Where(x => x.user_id == user_id).Select(x => new VacancyRequests(){
                id = x.id,
                user_id = x.user_id,
                vacancy_id = x.vacancy_id,
                applied_on = x.applied_on,
                awaiting_approval = x.awaiting_approval,
                approved = x.approved,
                user_name = x.user_name
            }).ToListAsync();

            return result;
        }

        public async Task<VacancyRequests> GetVacancyRequestsByIdAsync(int id){
            var result = await _context.vacancyRequests.FindAsync(id);
            return result;
        }

        public async Task DeleteVacancyRequestsAsync(int id){
            var vacancy = new VacancyRequests(){
                id = id
            };

            _context.vacancyRequests.Remove(vacancy);
            await _context.SaveChangesAsync();
        }

        public async Task VacancyPatchUpdateByIdAsync(int id, JsonPatchDocument vacancyRequest){
            var result = await _context.vacancyRequests.FindAsync(id);
            if(result != null){
                vacancyRequest.ApplyTo(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}