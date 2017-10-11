using IOS.D2S.DataConnector.DBFramework;
namespace IOS.Common.DataConnector.Utill
{
    internal class ConnectionStringProvider
    {
        public static string GetConStringFromDb(string companyCode)
        {
            GetConStringFromDbAction action = new GetConStringFromDbAction(companyCode);
            return action.Execute(EnumDatabase.Default);
        }
    }
}
