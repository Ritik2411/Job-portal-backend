using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeModule.Model{
    public class VacancyDetailModel{
        public int id { get;set; }

        public string user_id { get;set; } 
        public string PublishedBy { get;set; } 
            
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

        public int no_of_applications { get;set; } 
        public int totalPage { get;set; }
    }
}