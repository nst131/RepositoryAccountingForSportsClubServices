using ServiceAccountingDA.Models;

namespace ServiceAccountingDA.Configuration
{
    internal class TypeOfSexConfiguration : EnumerationConfiguration<TypeOfSex>
    {
        private const string TableName = "TypeOfSex";
        protected override string Table => TableName;
    }
}
