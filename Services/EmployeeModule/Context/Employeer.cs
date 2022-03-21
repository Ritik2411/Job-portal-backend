using System;

namespace EmployeeModule.Context{
    //Columns for employee table
    public class Employee{
        public string id { get;set; }

        public string Organization { get;set; }

        public string OrganizationType { get;set; }

        public string CompanyEmail { get;set; }

        public string CompanyPhone { get;set; }

        public int NoOfEmployee { get;set; }

        public string StartYear { get;set; }

        public string about { get;set; }

        public string createdBy { get;set; } 
    }
}