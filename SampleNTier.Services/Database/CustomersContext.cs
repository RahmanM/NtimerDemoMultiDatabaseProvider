using Sample.NTier.Services;
using Sample.NTier.Services.CustomAttributes;
using System;
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
        public CustomersContext() : base(ProviderConnectionString.GetConnection())
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}

