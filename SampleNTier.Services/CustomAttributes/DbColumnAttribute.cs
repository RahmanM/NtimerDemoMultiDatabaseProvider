using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sample.NTier.Services.CustomAttributes
{
    /// <summary>
    /// This is to enable column casing e.g. for MySql columns are set to lowcase by default for Oracle they are uppercase and Sql Server normally proper case
    /// </summary>
    class DbColumnAttribute : ColumnAttribute
    {
        public DbColumnAttribute(string msSqlName = null, string oracleName = null, string postgreSqlName = null, string mySqlName = null)
            : base(Tools.DbProvider == DbProviders.MsSql
                ? msSqlName
                : Tools.DbProvider == DbProviders.Oracle
                    ? oracleName
                    : Tools.DbProvider == DbProviders.PostgreSql
                        ? postgreSqlName
                            : Tools.DbProvider == DbProviders.MySql
                            ? mySqlName
                            : null)
        { }

      
    }
}