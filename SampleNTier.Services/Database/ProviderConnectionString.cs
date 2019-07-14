using Sample.NTier.Services.CustomAttributes;
using System.Configuration;

namespace Sample.NTier.Services
{
    public class ProviderConnectionString
    {

        internal static string GetConnection()
        {
            var connectiongString = "";

            var provider = Tools.DbProvider;
            switch (provider)
            {
                case DbProviders.MsSql:
                    connectiongString = ConfigurationManager.ConnectionStrings["CustomersConnectionStringMsSql"].ConnectionString;
                    break;
                case DbProviders.MySql:
                    connectiongString = ConfigurationManager.ConnectionStrings["CustomersConnectionStringMySql"].ConnectionString;
                    break;
                case DbProviders.Oracle:
                    connectiongString = ConfigurationManager.ConnectionStrings["CustomersConnectionStringOracle"].ConnectionString;
                    break;
                case DbProviders.PostgreSql:
                    connectiongString = ConfigurationManager.ConnectionStrings["CustomersConnectionStringPostgreSql"].ConnectionString;
                    break;
            }

            return connectiongString;
        }
    }
}