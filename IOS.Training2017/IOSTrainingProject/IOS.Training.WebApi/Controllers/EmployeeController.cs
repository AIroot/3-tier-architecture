using IOS.Training.API.ApiModules;
using IOS.Training.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IOS.Training.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return EmployeeAPI.GetAllEmployees();
        }
    }
}
