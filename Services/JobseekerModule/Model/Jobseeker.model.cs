using System;
using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.models{
    public class JobSeekerModel{
        public string user_id { get;set; }
        public string first_name { get;set; }

        public string last_name { get;set; }
        [EmailAddress]
        public string email { get;set; }
        [Required]
        [MinLength(5)]
        public string phone { get;set; }
        [Required]
        public string address { get;set; }
        [Required]
        public string total_expericence { get;set; }
        [Required]
        public string expected_salary { get;set; }
        [Required]
        public string dob { get;set; } 
    }
}