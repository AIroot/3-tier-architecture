using System.Data.Common;
using IOS.D2S.DataConnector.DBFramework;

namespace IOS.Common.DataConnector.Utill
{
    internal class GetConStringFromDbAction : IOSDBActionBase<string>
    {
        public string _companyCode = string.Empty;
        public GetConStringFromDbAction(string companyCode)
        {
            _companyCode = companyCode;
        }

        protected override string Body(System.Data.Common.DbConnection connection)
        {
            string spName = "ExceWorkStationGetGymConnection";
            string conection = string.Empty;
            try
            {
                DbCommand command = CreateCommand(System.Data.CommandType.StoredProcedure, spName);
                command.Parameters.Add(DataAcessUtils.CreateParam("@GymCode", System.Data.DbType.String, _companyCode));
                conection = (string)command.ExecuteScalar();
                return conection;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
