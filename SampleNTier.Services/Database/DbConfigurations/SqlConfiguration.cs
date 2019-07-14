using MySql.Data.Entity;
using System.Data.Entity;

namespace Sample.NTier.Services
{
    public class SqlConfiguration : DbConfiguration
    {
        public SqlConfiguration()
        {

            this.SetProviderServices("System.Data.SqlClient",  System.Data.Entity.SqlServer.SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new MySqlConnectionFactory("CustomersConnectionStringMsSql"));

        }
    }
}