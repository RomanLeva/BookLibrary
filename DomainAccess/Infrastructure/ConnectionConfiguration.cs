
using System.Configuration;

namespace DomainAccess.Infrastructure
{
    public class ConnectionConfiguration
    {
        public string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["Book_Library"].ConnectionString;
    }
}
