using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobseekerModule.context{
    public class Experience{
        public int Id { get;set; }
        public string company_name { get;set; }
        public string start_year { get;set; }
        public string end_year { get;set; } 
        public string CompanyUrl { get;set; }
        public string Designation { get;set; }
        public string JobDescription { get;set; } 

        [ForeignKey("jobSeeker")]
        public string user_id { get;set; }
        public JobSeekerDetail jobSeeker { get;set; }
    }
}