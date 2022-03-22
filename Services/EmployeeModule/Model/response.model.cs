using EmployeeModule.Context;

namespace EmployeeModule.Model{
    public class ResponeseModel{
        public PaginationModel<VacancyDetail> vacancyDetail { get;set; }

        public int totalPage { get;set; }
        public int pageIndex { get;set; }
        public int totalItems { get;set; }
    }
}