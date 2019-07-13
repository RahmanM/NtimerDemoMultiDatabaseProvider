using Sample.NTier.Services;
using Sample.NTier.Services.CustomAttributes;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SampleNTier.Services.Database
{
    /// <summary>
    /// Required for MYSQL database, will be set based on provider value
    /// </summary>
    [MyDbConfiguration(null)]
    public class CustomersContext : DbContext
    {
        public CustomersContext() : base("CustomersConnectionString")
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}

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