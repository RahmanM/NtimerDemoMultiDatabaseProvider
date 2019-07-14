using MySql.Data.Entity;
using System;
using System.Data.Entity;

namespace Sample.NTier.Services.CustomAttributes
{
    /// <summary>
    /// For MySQL we need to set the context to typeof(MySqlEFConfiguration) otherwise there will be null reference exception
    /// 
    /// </summary>
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
}