using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeModule.Model{
    public class EmployeeModel{
        [Required]
        public string Organization { get;set; } 
        [Required]
        public string OrgnizationType { get;set;}
        [Required]
        [EmailAddress]
        public string CompanyEmail { get;set; }

        [Required]
        public string CompanyPhone { get;set; }

        [Required]
        public int NoOfEmployees { get;set; }
        [Required]
        public string StartYear { get;set; } 
        [Required]    
        public string About { get;set;}
        [Required]
        public string CreatedBy { get;set; }
    }
}