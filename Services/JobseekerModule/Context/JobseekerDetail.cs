using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobseekerModule.context{

    [Table("JobseekerDetail")]
    public class JobSeekerDetail{
        [Key]
        public string user_id { get;set; }
        public string first_name { get;set; }
        public string last_name { get;set; }
        [EmailAddress]
        public string email { get;set; }
        public string phone { get;set; }
        public string address { get;set; }
        public string total_expericence { get;set; }
        public string expected_salary { get;set; }
        public string dob { get;set; } 

        public ICollection<Qualification> qualification { get;set; }
        public ICollection<Experience> experience { get;set; }
    }
}