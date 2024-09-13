using System.Data;

namespace Donut.SharedKernel.DatabaseConnection
{

    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
