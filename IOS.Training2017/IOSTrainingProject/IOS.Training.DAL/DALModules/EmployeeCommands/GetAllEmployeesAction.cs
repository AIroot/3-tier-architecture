using IOS.Training.Core.DomainObjects;
using IOS.Training.DbFactory.DbFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.DAL.DALModules.EmployeeCommands
{
    public class GetAllEmployeesAction : FingerTipsDbActionBase<List<Employee>>
    {
        protected override List<Employee> Body(DbConnection connection)
        {
            var employees = new List<Employee>();
            try
            {
                const string storedProcedureName = "dbo.USR_GetAllEmployees";
                var cmd = CreateCommand(CommandType.StoredProcedure, storedProcedureName);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = Convert.IsDBNull(reader["Id"]) ? 0 : Convert.ToInt32(reader["Id"]),
                        FirstName = Convert.IsDBNull(reader["FirstName"]) ? "" : reader["FirstName"].ToString(),
                        LastName = Convert.IsDBNull(reader["LastName"]) ? "" : reader["LastName"].ToString(),
                        Email = Convert.IsDBNull(reader["Email"]) ? "" : reader["Email"].ToString(),
                        MobileNo = Convert.IsDBNull(reader["MobileNo"]) ? "" : reader["MobileNo"].ToString(),
                        Username = Convert.IsDBNull(reader["Username"]) ? "" : reader["Username"].ToString(),
                        IconUrl = Convert.IsDBNull(reader["IconUrl"]) ? "" : reader["IconUrl"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return employees;
        }
    }
}
