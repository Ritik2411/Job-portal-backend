using System;
using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.context{
    public class JobSeeker{
        [Required]
        public string id { get;set; }
        [Required]
        public string first_name { get;set; }
        [Required]
        public string last_name { get;set; }
        [Required]
        [EmailAddress]
        public string email { get;set; }
        [Required]
        public string phone { get;set; }
        [Required]
        public string address { get;set; }
        [Required]
        public string total_expericence { get;set; }
        public string expected_salary { get;set; }
        [Required]
        public DateTime dob { get;set; } 
    }
}