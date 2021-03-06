using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeModule.Context{
    //Column for vacancy table
    public class VacancyDetail{
        public int id { get;set;}
        public string user_id { get;set; }

        public string PublishedBy { get;set; } 
        
        public DateTime Published_Date { get;set; }
        
        public int No_of_Vacancies { get;set; } 
        
        public string Minimum_qualification { get;set; } 
        
        public string Job_Description { get;set; } 
        
        public string Experience { get;set; } 
        
        public DateTime Last_Date { get;set; }

        public string Min_Salary{ get;set; }  
        
        public string Max_Salary { get;set; } 
        
        public int no_of_applications { get;set; }
    }
}