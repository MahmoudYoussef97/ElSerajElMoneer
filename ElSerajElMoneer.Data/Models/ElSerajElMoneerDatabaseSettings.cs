using System;
namespace ElSerajElMoneer.Data.Models
{
    public class ElSerajElMoneerDatabaseSettings : IElSerajElMoneerDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string TaghredatCollectionName { get; set; }
    }
    public interface IElSerajElMoneerDatabaseSettings
    {
        string TaghredatCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
