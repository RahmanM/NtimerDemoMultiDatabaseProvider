using Sample.NTier.Services.CustomAttributes;

namespace SampleNTier.Services.Database
{

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
}