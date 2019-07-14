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

                switch (ConfigurationManager.AppSettings["DatabaseProviderName"])
                {
                    case "MSSql":
                        _dbProvider = DbProviders.MsSql;
                        break;
                    case "Oracle":
                        _dbProvider = DbProviders.Oracle;
                        break;
                    case "PostgreSql":
                        _dbProvider = DbProviders.PostgreSql;
                        break;
                    case "MySql":
                        _dbProvider = DbProviders.MySql;
                        break;
                }

                return _dbProvider;
            }
        }
    }
}