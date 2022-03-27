using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobseekerModule.context{

    //Annotation for defining table name
    [Table("JobseekerDetail")]
    
    //Column for jobseeker detail table
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

        //Refrence for qualification table for assigning FK to quafication table
        public ICollection<Qualification> qualification { get;set; }
        //Refrence for experience table for assigning FK to experience table
        public ICollection<Experience> experience { get;set; }
    }
}