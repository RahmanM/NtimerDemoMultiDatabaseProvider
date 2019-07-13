using System.Configuration;

namespace Sample.NTier.Services.CustomAttributes
{
    public static class Tools
    {
        private static DbProviders _dbProvider;

        public static DbProviders DbProvider
        {
            get
            {
                if (_dbProvider != DbProviders.None)
                    return _dbProvider;

                switch (ConfigurationManager.ConnectionStrings["CustomersConnectionString"].ProviderName)
                {
                    case "System.Data.SqlClient":
                        _dbProvider = DbProviders.MsSql;
                        break;
                    case "Oracle.ManagedDataAccess.Client":
                        _dbProvider = DbProviders.Oracle;
                        break;
                    case "Npgsql":
                        _dbProvider = DbProviders.PostgreSql;
                        break;
                    case "MySql.Data.MySqlClient":
                        _dbProvider = DbProviders.MySql;
                        break;
                }

                return _dbProvider;
            }
        }
    }
}