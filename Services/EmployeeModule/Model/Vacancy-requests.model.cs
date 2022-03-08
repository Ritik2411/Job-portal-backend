using System;

namespace EmployeeModule.Model{
    public class VacancyRequestsModel{
        public string user_id { get;set; }
        public string vacany_id { get;set; }
        public DateTime applied_on { get;set; }
    }
}