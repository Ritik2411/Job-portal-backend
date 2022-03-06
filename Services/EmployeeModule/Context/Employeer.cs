using System;

namespace EmployeeModule.Context{
    public class Employee{
        public int id { get;set; }

        public string Organization { get;set; }

        public string OrganizationType { get;set; }

        public string CompanyEmail { get;set; }

        public string CompanyPhone { get;set; }

        public string NoOfEmployee { get;set; }

        public DateTime StartYear { get;set; }

        public string about { get;set; }

        public string createdBy { get;set; } 
    }
}