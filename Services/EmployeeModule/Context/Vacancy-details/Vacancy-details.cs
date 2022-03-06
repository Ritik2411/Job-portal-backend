using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeModule.Context{
    public class VacancyDetail{
        public int id { get;set;}

        public string PublishedBy { get;set; } 
        
        public DateTime Published_Date { get;set; }
        
        public string No_of_Vacancies { get;set; } 
        
        public string Minimum_qualification { get;set; } 
        
        public string Job_Description { get;set; } 
        
        public string Experience { get;set; } 
        
        public DateTime Last_Date { get;set; }

        public string Min_Salary{ get;set; }  
        
        public string Max_Salary { get;set; } 
    }
}