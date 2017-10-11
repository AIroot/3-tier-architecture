using System;
using System.Data.Common;
using IOS.Common.DataConnector.Utill;

namespace IOS.D2S.DataConnector.DBFramework
{
            
		/// <summary>
		/// This class will hide the Db specific functionality and provide Db resources
		/// through common db interfaces as defined under ADO.NET Common Factory Model.
		/// </summary>
		/// <remarks></remarks>
		public class GenericDBFactory
		{

            
			/// <summary>
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
           

            private static DbConnection GetConnectionByName(EnumDatabase dbName)
            {
                string ConnectionString = "";
                switch (dbName)
                {
                    case EnumDatabase.HMS:
                        ConnectionString = IOSRunTimeVariables.GetConnectionString();
                        break;
                    case EnumDatabase.IBE:
                        break;
                    case EnumDatabase.D2S:
                        ConnectionString = IOSRunTimeVariables.D2SConnectionString();
                        
                        break;
                    case EnumDatabase.VNT:
                        break;
                    case EnumDatabase.Search:
                        break;
                    case EnumDatabase.RVN:
                        break;
                    case EnumDatabase.Default:
                        ConnectionString = IOSRunTimeVariables.GetConnectionString();
                        break;
                    default:
                        break;
                }
                

                DbConnection Connection = Factory.CreateConnection();
                Connection.ConnectionString = ConnectionString;

                return Connection;
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
               
                DbConnection Connection = Factory.CreateConnection();
                Connection.ConnectionString = connectionString;

                return Connection;
            }
            #endregion

           
            private static DbConnection GetConnectionByCompanyCode(EnumDatabase dbName, string companyCode)
            {
                string ConnectionString = string.Empty;
                if (dbName == EnumDatabase.Default)
                {
                    if ((AppDomain.CurrentDomain.GetData(companyCode) == null))
                    {
                        ConnectionString = ConnectionStringProvider.GetConStringFromDb(companyCode);
                        AppDomain.CurrentDomain.SetData(companyCode, ConnectionString);
                    }
                    else
                    {
                        ConnectionString = AppDomain.CurrentDomain.GetData(companyCode).ToString();
                    }
                }
              
                DbConnection Connection = Factory.CreateConnection();
                Connection.ConnectionString = ConnectionString;
                return Connection;
            }
        }

	
}
