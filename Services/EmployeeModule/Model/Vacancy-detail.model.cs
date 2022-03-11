using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeModule.Model{
    public class VacancyDetailModel{
        [Required]
        public string PublishedBy { get;set; } 
        
        [Required]
        public DateTime Published_Date { get;set; }
        
        [Required]
        public int No_of_Vacancies { get;set; } 
        
        [Required]
        public string Minimum_qualification { get;set; } 
        
        [Required]
        public string Job_Description { get;set; } 
        
        [Required]
        public string Experience { get;set; } 
        
        [Required]
        public DateTime Last_Date { get;set; }

        [Required]
        public string Min_Salary{ get;set; }  
        
        [Required]
        public string Max_Salary { get;set; } 
    }
}