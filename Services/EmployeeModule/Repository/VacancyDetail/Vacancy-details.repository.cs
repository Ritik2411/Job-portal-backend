using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Repository{
    public class VacancyDetailRepository : IVacancyDetail{
        private readonly VacancyDetailContext _vacancy;
        
        public VacancyDetailRepository(VacancyDetailContext vacancyDetailContext){
            _vacancy = vacancyDetailContext;
        }

        public async Task<List<VacancyDetail>> getVacancyListAsync(){
            var vacancies = await _vacancy.vacancies.Select(x=>new VacancyDetail(){
                id = x.id,
                user_id = x.user_id,
                PublishedBy = x.PublishedBy,
                Published_Date = x.Published_Date,
                No_of_Vacancies = x.No_of_Vacancies,
                Minimum_qualification = x.Minimum_qualification,
                Job_Description = x.Job_Description,
                Experience = x.Experience,
                Last_Date = x.Last_Date,
                Min_Salary = x.Min_Salary,
                Max_Salary = x.Max_Salary 
            }).ToListAsync();

            return vacancies;
        }

        public async Task<List<VacancyDetail>> getVacanyByUserIdAsync(string user_id){
            var vacancyData = await _vacancy.vacancies.Where(x => x.user_id == user_id).Select(x=>new VacancyDetail(){
                id = x.id,
                user_id = x.user_id,
                PublishedBy = x.PublishedBy,
                Published_Date = x.Published_Date,
                No_of_Vacancies = x.No_of_Vacancies,
                Minimum_qualification = x.Minimum_qualification,
                Job_Description = x.Job_Description,
                Experience = x.Experience,
                Last_Date = x.Last_Date,
                Min_Salary = x.Min_Salary,
                Max_Salary = x.Max_Salary 
            }).ToListAsync();
            
            return vacancyData;
        }

        public async Task<List<VacancyDetail>> getVacanyByIdAsync(int id){
            var vacancyData = await _vacancy.vacancies.Where(x => x.id == id).Select(x=>new VacancyDetail(){
                id = x.id,
                user_id = x.user_id,
                PublishedBy = x.PublishedBy,
                Published_Date = x.Published_Date,
                No_of_Vacancies = x.No_of_Vacancies,
                Minimum_qualification = x.Minimum_qualification,
                Job_Description = x.Job_Description,
                Experience = x.Experience,
                Last_Date = x.Last_Date,
                Min_Salary = x.Min_Salary,
                Max_Salary = x.Max_Salary 
            }).ToListAsync();
            
            return vacancyData;
        }

        public async Task AddVacancyAsync(VacancyDetail vacancyDetailModel){
            var vacancy = new VacancyDetail(){
                user_id = vacancyDetailModel.user_id,
                PublishedBy = vacancyDetailModel.PublishedBy,
                Published_Date = vacancyDetailModel.Published_Date,
                No_of_Vacancies = vacancyDetailModel.No_of_Vacancies,
                Minimum_qualification = vacancyDetailModel.Minimum_qualification,
                Job_Description = vacancyDetailModel.Job_Description,
                Experience = vacancyDetailModel.Experience,
                Last_Date = vacancyDetailModel.Last_Date,
                Min_Salary = vacancyDetailModel.Min_Salary,
                Max_Salary = vacancyDetailModel.Max_Salary 
            };

            _vacancy.vacancies.Add(vacancy);
            await  _vacancy.SaveChangesAsync();
        }

        public async Task deleteVacancyAsync(int id){
            var vacancies = new VacancyDetail(){
                id = id
            };

            _vacancy.vacancies.Remove(vacancies);
            await _vacancy.SaveChangesAsync();
        }

        public async Task updateVacancyAsync(int id, VacancyDetailModel vacancyDetailModel){
            var vacancies = await _vacancy.vacancies.FindAsync(id);

            if(vacancies != null){
                vacancies.PublishedBy = vacancyDetailModel.PublishedBy;
                vacancies.Published_Date = vacancyDetailModel.Published_Date;
                vacancies.No_of_Vacancies = vacancyDetailModel.No_of_Vacancies;
                vacancies.Minimum_qualification = vacancyDetailModel.Minimum_qualification;
                vacancies.Job_Description = vacancyDetailModel.Job_Description;
                vacancies.Experience = vacancyDetailModel.Experience;
                vacancies.Last_Date = vacancyDetailModel.Last_Date;
                vacancies.Min_Salary = vacancyDetailModel.Min_Salary;
                vacancies.Max_Salary = vacancyDetailModel.Max_Salary;        
            }

            await _vacancy.SaveChangesAsync();
        }

        public async Task UpdateVacancyPatchAsync(int id, JsonPatchDocument vacancyModel){
            var result = await _vacancy.vacancies.FindAsync(id);
            if(result != null){
                vacancyModel.ApplyTo(result);
                await _vacancy.SaveChangesAsync();
            }

        }
    }
}