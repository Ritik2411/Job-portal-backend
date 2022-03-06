using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller{
    public class WebApiController{
        public Task<string> simple([FromServices]IHttpClientFactory httpClientFactory){
            var client = httpClientFactory.CreateClient("EmployeeService");
            return client.GetStringAsync("/EmployeeDetail");
        }
    }
}