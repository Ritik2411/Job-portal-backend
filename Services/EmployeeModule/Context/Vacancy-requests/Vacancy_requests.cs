using System;

namespace EmployeeModule.Context{
    public class VacancyRequests{
        public int id { get;set; }
        public string vacancy_id { get;set; }
        public string user_id { get;set; }
        public DateTime applied_on { get;set; }
        public bool awaiting_approval { get;set; }
        public bool approved { get;set; }
    }
}