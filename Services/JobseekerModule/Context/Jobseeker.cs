using System;
using System.ComponentModel.DataAnnotations;

namespace JobseekerModule.context{
    public class JobSeeker{
        public string id { get;set; }
        public string first_name { get;set; }
        public string last_name { get;set; }
        public string email { get;set; }
        public string phone { get;set; }
        public string address { get;set; }
        public string total_expericence { get;set; }
        public string expected_salary { get;set; }
        public string dob { get;set; } 
    }
}