using MySql.Data.Entity;
using System;
using System.Data.Entity;

namespace Sample.NTier.Services.CustomAttributes
{
    /// <summary>
    /// For MySQL we need to set the context to typeof(MySqlEFConfiguration) otherwise there will be null reference exception
    /// 
    /// For all the others to be null in this stage
    /// </summary>
    public class MyDbConfigurationAttribute : DbConfigurationTypeAttribute
    {
        public MyDbConfigurationAttribute(Type configurationType) : base(Tools.DbProvider == DbProviders.MySql
                        ? typeof(MySqlEFConfiguration)
                        : null)
        {
        }
    }
}