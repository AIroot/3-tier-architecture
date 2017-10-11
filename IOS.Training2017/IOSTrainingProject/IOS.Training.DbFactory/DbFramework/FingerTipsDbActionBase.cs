using IOS.Training.DbFactory.Core.Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOS.Training.DbFactory.DbFramework
{
    public abstract class FingerTipsDbActionBase<T>
    {
        protected DbConnection Connection;
        private DbTransaction _transaction;

        /// <summary>
        /// Implement this method and perform any required database operation by using
        /// the provided DbConnection. Implementer of this method is free from connection
        /// close hazzel and will be taken care by the 'Execute()' base method of the class.
        /// </summary>
        /// <param name="connection">Connection instance which is ready for use</param>
        /// <returns>Output of the command execution. This exact object will be
        /// returned when the Execute() method is called by the users</returns>
        /// <remarks></remarks>
        protected abstract T Body(DbConnection connection);

        /// <summary>
        /// call this method to execute this database Action class
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public T Execute(EnumDatabase dbName)
        {
            Connection = GenericDbFactory.GetConnection(dbName);

            const ConnectionState finallyExpected = ConnectionState.Closed; // this is the expected state at the end of the operation
            ConnectionState finallyActual = 0;
            T returnInstance;

            // 'using' clause will ensure the proper clasong of the connection
            using (Connection)
            {
                try
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open(); //open the connection
                    }
                    // check connection opened proprely
                    if (Connection.State != ConnectionState.Open)
                    {
                        throw (new Exception("Problem in opening the DB Connection. Connection not opened"));
                    }
                    // run the command body of this command
                    returnInstance = Body(Connection);

                }
                catch (Exception ex) // some problem occured in executing this command
                {
                    var exp = new TrainingDbException();
                    exp.Log(ex.Message);

                    throw (new Exception("Error on data. " + ex.Message));
                }
					finally // close the connection
                {
                    if (Connection.State != ConnectionState.Closed)
                    {
                        Connection.Close();
                        finallyActual = Connection.State;
                    }
                }
            }

            if (finallyExpected != finallyActual)
            {
                throw (new Exception("Problem in closing the DB connection. Db connection is not properly closed"));
            }
            return returnInstance;
        }

        #region T Execute Overload method

        #endregion


        public DbTransaction ParentTransaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }


        /// <summary>
        /// This will create a command which is assocoiated with this db Action's
        /// Connection. Make sure calls to this method happens only withing the
        /// overidden Body() method of this action
        /// </summary>
        /// <param name="type">CommandType of the new Command</param>
        /// <param name="commandText">CommandText of the new Command</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected DbCommand CreateCommand(CommandType type, string commandText)
        {
            var command = GenericDbFactory.Factory.CreateCommand();
            if (command != null)
            {
                command.Connection = Connection;
                command.CommandText = commandText;
                command.CommandType = type;
                command.CommandTimeout = int.MaxValue;
            }
            return command;
        }

        protected DbCommand CreateCommand(CommandType type, string commandText, DbTransaction dbTransaction)
        {
            var command = GenericDbFactory.Factory.CreateCommand();
            if (command != null)
            {
                command.Connection = Connection;
                command.CommandText = commandText;
                command.CommandType = type;
                command.CommandTimeout = int.MaxValue;
                command.Transaction = dbTransaction;
            }
            return command;
        }
    }
}
