using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeModule.Context;
using EmployeeModule.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModule.Repository{
    //VacancyDetailRepository implements IVacancyDetail and defined all its  methods 
    public class VacancyDetailRepository : IVacancyDetail{
        private readonly VacancyDetailContext _vacancy;
        public VacancyDetailRepository(VacancyDetailContext vacancyDetailContext){
            _vacancy = vacancyDetailContext;
        }

        // Provides list of all vacancies posted by employee.
        public async Task<ResponeseModel> getVacancyListAsync(string sortOrder,  int page_size, int page = 1){
            
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
                Max_Salary = x.Max_Salary ,
                no_of_applications = x.no_of_applications
            }).ToListAsync();
            
            switch(sortOrder){
                case "ascending_publishDate":
                    vacancies = vacancies.OrderBy(s => s.Published_Date).ToList();
                    break;

                case "descending_lastDate":
                    vacancies = vacancies.OrderByDescending(s => s.Last_Date).ToList();
                    break;
                
                case "ascending_lastDate":
                    vacancies = vacancies.OrderBy(s => s.Last_Date).ToList();
                    break;

                default:
                    vacancies = vacancies.OrderByDescending(s => s.Published_Date).ToList();
                    break;
            }

            var result = PaginationModel<VacancyDetail>.create(vacancies, page, page_size);
          
            return new ResponeseModel(){
                vacancyDetail = result,
                totalPage = result.totalPage,
                pageIndex = result.PageIndex,
                totalItems = vacancies.Count
            };
        }

        //Provides the data of particular vacancy based on user_id.
        public async Task<ResponeseModel> getVacanyByUserIdAsync(string user_id, string experience,string pub_date,string sortOrder,int pageSize, int page){
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
                Max_Salary = x.Max_Salary,
                no_of_applications = x.no_of_applications
            }).ToListAsync();
            
            //Filtering
            if(!string.IsNullOrEmpty(experience)){
                vacancyData = vacancyData.Where(x => x.Experience.Contains(experience)).ToList();
            }

            if(!string.IsNullOrEmpty(pub_date)){
                vacancyData = vacancyData.Where(x => x.Published_Date.ToString().Contains(pub_date)).ToList();
            }

            //Sorting
            switch(sortOrder){
                case "ascending_PD":
                    vacancyData = vacancyData.OrderBy(x => x.Published_Date).ToList();
                    break;

                case "descending_LD":
                    vacancyData = vacancyData.OrderByDescending(x => x.Last_Date).ToList();
                    break;

                case "ascending_LD":
                    vacancyData = vacancyData.OrderBy(x => x.Last_Date).ToList();
                    break;

                default:
                    vacancyData = vacancyData.OrderByDescending(x => x.Published_Date).ToList();
                    break;
            }

            //Pagination
            var result = PaginationModel<VacancyDetail>.create(vacancyData, page, pageSize);
            return new ResponeseModel(){
                vacancyDetail = result,
                totalItems = vacancyData.Count,
                pageIndex = result.PageIndex,
                totalPage = result.totalPage
            };
        }

        //Provides the data of particular vacancy based on ID(PK).
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
                Max_Salary = x.Max_Salary,
                no_of_applications =x.no_of_applications
            }).ToListAsync();
            
            return vacancyData;
        }

        //Addes a vacancy that is posted by employee. 
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
                Max_Salary = vacancyDetailModel.Max_Salary,
            };

            _vacancy.vacancies.Add(vacancy);
            await  _vacancy.SaveChangesAsync();
        }

        //Deletes vacancies based on ID(PK)
        public async Task deleteVacancyAsync(int id){
            var vacancies = new VacancyDetail(){
                id = id
            };

            _vacancy.vacancies.Remove(vacancies);
            await _vacancy.SaveChangesAsync();
        }

        //Updates vacancies based on ID(PK) and addes the requested value.
        public async Task updateVacancyAsync(int id, VacancyDetailModel vacancyDetailModel){
            var vacancies = await _vacancy.vacancies.FindAsync(id);

            if(vacancies != null){
                vacancies.No_of_Vacancies = vacancyDetailModel.No_of_Vacancies;
                vacancies.Minimum_qualification = vacancyDetailModel.Minimum_qualification;
                vacancies.Job_Description = vacancyDetailModel.Job_Description;
                vacancies.Experience = vacancyDetailModel.Experience;
                vacancies.Min_Salary = vacancyDetailModel.Min_Salary;
                vacancies.Max_Salary = vacancyDetailModel.Max_Salary;        
            }

            await _vacancy.SaveChangesAsync();
        }

        //Updates a particular key value instead of entire row.
        public async Task UpdateVacancyPatchAsync(int id, JsonPatchDocument vacancyModel){
            var result = await _vacancy.vacancies.FindAsync(id);
            if(result != null){
                vacancyModel.ApplyTo(result);
                await _vacancy.SaveChangesAsync();
            }
        }
    }
}