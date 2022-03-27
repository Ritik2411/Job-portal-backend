using System;

namespace EmployeeModule.Context{
    //Columns for vacancy requests
    public class VacancyRequests{
        public int id { get;set; }
        public int vacancy_id { get;set; }
        public string PublishedBy { get;set; }
        public string user_id { get;set; }
        public DateTime applied_on { get;set; }
        public bool awaiting_approval { get;set; }
        public bool approved { get;set; }
        public string user_name { get;set; }
        
        public string description { get;set; }

        public int No_of_Vacancies { get;set; }
    }
}