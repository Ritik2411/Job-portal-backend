using System;
using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.models{
    public class ExperienceModel{
        public int id { get;set; } 
        public string user_id { get;set; }
        [Required]
        public string company_name { get;set; }
        [Required]
        public string start_year { get;set; }
        [Required]
        public string end_year { get;set; }     
        [Required]
        public string CompanyUrl { get;set; }
        [Required]
        public string Designation { get;set; }
        [Required]
        public string JobDescription { get;set; }
    }
}