# Ntier Demo MVC App with multiple database provider support

## Configurations
Can swap the database just by changing the provider name in the web.config file:

  - Sql Server: <!--<add key="DatabaseProviderName" value="MSSql" />-->
  - MySql: <add key="DatabaseProviderName" value="MySql" />
  - Postgresql: <add key="DatabaseProviderName" value="PostgreSql" />

### Connection strings

    <add name="CustomersConnectionStringPostgreSql" connectionString="Server=localhost;Port=5432;Database=customers;User Id=admin;Password=admin" providerName="Npgsql" />
    <add name="CustomersConnectionStringMsSql" providerName="System.Data.SqlClient" connectionString="Server=MSSQLSERVER2008\instance;Database=Customers;User Id=CustomersWebApi; Password=CustomersWebApi;" />
    <add name="CustomersConnectionStringMySql" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;Port=3306;userid=admin;password=admin;database=customers;persistsecurityinfo=True" />

### Default Schema

Since every provider has its own default schema, we can configure the default schema in the web.config file e.g:

    <!--<add key="DefaultDbSchema" value="dbo" />-->
    <!--<add key="DefaultDbSchema" value="TEST_USER" />-->
    <add key="DefaultDbSchema" value="public" />


# C# Code

## The database entity
Since every provider has its own way of defaulting table names and fields we need to specify the format for each provider as we want to use one entity for all providers. For example Postgress likes database, table and fields to be lower case otherwise it will wrap them in double quotation that is very annoying:

    [DbTable(msSqlName: "Customer", oracleName: "CUSTOMER", postgreSqlName: "customer", mySqlName: "customer")]
    public class Customer
    {
        [DbColumn(mySqlName: "Id", msSqlName: "Id", postgreSqlName: "id")]
        public virtual int Id { get; set; }

        [DbColumn(mySqlName: "FirstName", msSqlName: "FirstName", postgreSqlName: "firstname")]
        public virtual string FirstName { get; set; }

        [DbColumn(mySqlName: "LastName", msSqlName: "LastName", postgreSqlName: "lastname")]
        public virtual string LastName { get; set; }
    }
    
## Custom Attributes
DbTable and DbColumn has been created to tackle the naming issue as specified above.

## DBConfiguration files
The DBContext file needs to be wrapped with attribute to define which provider to use:

    [MyDbConfiguration(null)]
    public class CustomersContext : DbContext
    {
        public CustomersContext() : base(ProviderConnectionString.GetConnection())
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
    
    and the configuration class:
    
     public class MyDbConfigurationAttribute : DbConfigurationTypeAttribute
    {
        public MyDbConfigurationAttribute(Type configurationType) : base(GetDbConfigurationByProvider())
        {
        }

        private static Type GetDbConfigurationByProvider()
        {
            return Tools.DbProvider == 
                                DbProviders.MySql
                                    ? typeof(MySqlEFConfiguration)
                                    : 
                                Tools.DbProvider == DbProviders.MsSql
                                    ? typeof(SqlConfiguration)
                                    :
                                Tools.DbProvider == DbProviders.PostgreSql
                                    ? typeof(NpgSqlConfiguration)
                                    : null;
        }
    }
