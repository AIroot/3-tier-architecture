using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.DbFactory.Util
{
  public  class SystemVariables
    {
      public static string GetConnectionString()
      {
          return ConfigurationManager.ConnectionStrings["IoneTrainingDbContext"].ConnectionString;
      }
    }
}
