using IOS.Training.BLL.BllModules;
using IOS.Training.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.API.ApiModules
{
    public static class EmployeeAPI
    {
        public static List<Employee> GetAllEmployees()
        {
            return EmployeeBLL.GetAllEmployees();
        }
    }
}
