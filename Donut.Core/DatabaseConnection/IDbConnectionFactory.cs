using System.Data;

namespace Donut.Core.DatabaseConnection;


public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
