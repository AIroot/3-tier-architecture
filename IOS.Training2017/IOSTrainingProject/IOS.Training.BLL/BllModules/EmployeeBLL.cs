using IOS.Training.Core.DomainObjects;
using IOS.Training.DAL.DALModules.EmployeeCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.BLL.BllModules
{
    public static class EmployeeBLL
    {
        public static List<Employee> GetAllEmployees()
        {
            return new GetAllEmployeesAction().Execute(EnumDatabase.IoneTrainingDb);
        }
    }
}
