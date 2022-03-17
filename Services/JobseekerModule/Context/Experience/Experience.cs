using System;

namespace JobseekerModule.context{
    public class Experience{
        public int Id { get;set; }
        public string User_ID { get;set; }  
        public string company_name { get;set; }
        public string start_year { get;set; }
        public string end_year { get;set; } 
        public string CompanyUrl { get;set; }
        public string Designation { get;set; }
        public string JobDescription { get;set; } 
    }
}