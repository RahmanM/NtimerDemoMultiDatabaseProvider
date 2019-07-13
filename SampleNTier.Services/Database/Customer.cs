using Sample.NTier.Services.CustomAttributes;

namespace SampleNTier.Services.Database
{

    [DbTable(msSqlName: "Customer", oracleName: "CUSTOMER", postgreSqlName: "customer", mySqlName: "customer")]
    public class Customer
    {
        [DbColumn( mySqlName: "Id")]
        public virtual int Id { get; set; }

        [DbColumn(mySqlName: "FirstName")]
        public virtual string FirstName { get; set; }

        [DbColumn(mySqlName: "LastName")]
        public virtual string LastName { get; set; }
    }
}