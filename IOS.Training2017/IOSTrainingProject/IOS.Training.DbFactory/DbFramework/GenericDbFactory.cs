using IOS.Training.DbFactory.Util;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.DbFactory.DbFramework
{
  public  class GenericDbFactory
    {/// <summary>
        /// This specifies ADO.NET 2.0 framework to use specified provider classes
        /// to provide requesting database resources
        /// </summary>
        protected const string ProviderInvarientName = "System.Data.SqlClient";

        /// <summary>
        /// Returns the appropriate factory as specified in 'ProviderInvarientName'
        /// to get the database resources. To create Db resources as Commands and Parameters
        /// with generic interface, one should use this Factory.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DbProviderFactory Factory
        {
            get
            {
                return DbProviderFactories.GetFactory(ProviderInvarientName);
            }
        }

        /// <summary>
        /// To get a new Db connection call this method. Returned connection is not yet opened.
        /// Please make sure that you open it before use and then close it after.
        /// </summary>
        /// <returns>new database connection</returns>
        /// <remarks></remarks>
        public static DbConnection GetConnection(EnumDatabase dbName)
        {
            return GetConnectionByName(dbName);
        }

        private static string GetConnectionStringByName(EnumDatabase dbName)
        {
            var connectionString = "";
            if (dbName == EnumDatabase.IoneTrainingDb)
            {
                // Connection string read from "WEB API web.config file"
                connectionString = SystemVariables.GetConnectionString();
            }

            return connectionString;
        }

        private static DbConnection GetConnectionByName(EnumDatabase dbName)
        {
            var connection = Factory.CreateConnection();
            if (connection != null)
            {
                connection.ConnectionString = GetConnectionStringByName(dbName);
            }
            return connection;
        }

        #region GetConnection overload method

        /// <summary>
        /// To get a new Db connection call this method. Returned connection is not yet opened.
        /// Please make sure that you open it before use and then close it after.
        /// </summary>
        /// <returns>new database connection</returns>
        /// <remarks></remarks>
        public static DbConnection GetConnection(string connectionString)
        {
            var connection = Factory.CreateConnection();
            if (connection != null)
            {
                connection.ConnectionString = connectionString;
            }
            return connection;
        }

        #endregion

    }
}
