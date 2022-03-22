using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Repository{
    //VacancyRequestsRepository implements IVacancyRequests and declares all its methods.
    public class VacancyRequestsRepository : IVacancyRequests{
        private readonly VacancyRequestsContext _context;
        public VacancyRequestsRepository(VacancyRequestsContext vacancyRequestsContext){
            _context = vacancyRequestsContext;
        }

        //Add vacancy requests from the jobseeker.
        public async Task AddVacancyRequestsAsync(VacancyRequests vacancyRequestsModel){
            var data = new VacancyRequests(){
                user_id = vacancyRequestsModel.user_id,
                vacancy_id = vacancyRequestsModel.vacancy_id,
                applied_on = vacancyRequestsModel.applied_on,
                awaiting_approval = vacancyRequestsModel.awaiting_approval,
                approved = vacancyRequestsModel.approved,
                user_name = vacancyRequestsModel.user_name,
                PublishedBy = vacancyRequestsModel.PublishedBy,
                description = vacancyRequestsModel.description
            }; 

            _context.vacancyRequests.Add(data);
            await _context.SaveChangesAsync();
        }

        //Get all vacancies requests from the jobseeker.
        public async Task<List<VacancyRequests>> GetVacancyRequestsAsync(){
           var result = await _context.vacancyRequests.Select(x => new VacancyRequests(){
               id = x.id,
               user_id = x.user_id,
               vacancy_id = x.vacancy_id,
               applied_on = x.applied_on,
               awaiting_approval = x.awaiting_approval,
               approved = x.approved,
               user_name = x.user_name,
               PublishedBy = x.PublishedBy,
               description = x.description
           }).ToListAsync();

           return result;
        }

        //Get vacancies requests by jobseeker user_id. 
        public async Task<List<VacancyRequests>> GetVacancyRequestsByUserIdAsync(string user_id, string sort_by_date){
            var result = await _context.vacancyRequests.Where(x => x.user_id == user_id).Select(x => new VacancyRequests(){
                id = x.id,
                user_id = x.user_id,
                vacancy_id = x.vacancy_id,
                applied_on = x.applied_on,
                awaiting_approval = x.awaiting_approval,
                approved = x.approved,
                user_name = x.user_name,
                PublishedBy = x.PublishedBy,
                description = x.description,
            }).ToListAsync();

            var vacany_req = new List<VacancyRequests>();

            //Sort by applied date    
            switch(sort_by_date){
                case "ascending":
                vacany_req = result.OrderBy(x => x.applied_on).ToList();
                break;

                default:
                vacany_req = result.OrderByDescending(x => x.applied_on).ToList();
                break;   
            }   
  
            return vacany_req;
        }

        //Get vacancies requests by ID(PK).
        public async Task<VacancyRequests> GetVacancyRequestsByIdAsync(int id){
            var result = await _context.vacancyRequests.FindAsync(id);
            return result;
        }

        //Delete vacancies requests by ID(PK).
        public async Task DeleteVacancyRequestsAsync(int id){
            var vacancy = new VacancyRequests(){
                id = id
            };

            _context.vacancyRequests.Remove(vacancy);
            await _context.SaveChangesAsync();
        }

        //Updates particular key-value pair from vacancy request by ID(PK).
        public async Task VacancyPatchUpdateByIdAsync(int id, JsonPatchDocument vacancyRequest){
            var result = await _context.vacancyRequests.FindAsync(id);
            if(result != null){
                vacancyRequest.ApplyTo(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}