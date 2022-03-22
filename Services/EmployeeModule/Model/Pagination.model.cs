using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeModule.Model{
    public class PaginationModel<T> : List<T>{
        //Current page
        public int PageIndex { get;set; }

        //Total number of Pages
        public int totalPage { get;set; }
        
        public PaginationModel(List<T> items, int count, int pageIndex, int pageSize){
            PageIndex = pageIndex;
            totalPage = (int)Math.Ceiling(count / (double)pageSize); //Will be calculated like if total number if elelmensts in array are 20 then 20/5(number of itlems per page) = 4(Number of pages).
            AddRange(items);
        }

        public static PaginationModel<T> create(List<T> source, int pageIndex, int pageSize){
            //Total number of objects in list
            var count = source.Count();

            //Items per page
            var items = source.Skip((pageIndex -1)*pageSize).Take(pageSize).ToList();

            return new PaginationModel<T>(items, count, pageIndex, pageSize); 
        }
    }
}