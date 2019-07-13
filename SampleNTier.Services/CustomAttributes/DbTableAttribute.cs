using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Sample.NTier.Services.CustomAttributes
{
    /// <summary>
    /// This is to specify the default casing for the table e.g. for MySql table is normally lower case
    /// </summary>
    internal class DbTableAttribute : TableAttribute
    {
        public DbTableAttribute(string msSqlName, string oracleName, string postgreSqlName, string mySqlName = null, string msSqlSchema = null, string oracleSchema = null, string postgreSqlSchema = null, string mySqlSchema = null)
            : base(Tools.DbProvider == DbProviders.MsSql
                ? msSqlName
                : Tools.DbProvider == DbProviders.Oracle
                    ? oracleName
                    : Tools.DbProvider == DbProviders.PostgreSql
                        ? postgreSqlName
                        : Tools.DbProvider == DbProviders.MySql
                        ? mySqlName
                        : null)
        {
            switch (Tools.DbProvider)
            {
                case DbProviders.MsSql:
                    Schema = (msSqlSchema ?? ConfigurationManager.AppSettings["DefaultDbSchema"]) ?? "dbo";
                    break;
                case DbProviders.Oracle:
                    Schema = (oracleSchema ?? ConfigurationManager.AppSettings["DefaultDbSchema"]);
                    break;
                case DbProviders.PostgreSql:
                    Schema = (postgreSqlSchema ?? ConfigurationManager.AppSettings["DefaultDbSchema"]);
                    break;
                case DbProviders.MySql:
                    Schema = (mySqlSchema ?? ConfigurationManager.AppSettings["DefaultDbSchema"]) ?? "sys";
                    break;
            }
        }
    }
}