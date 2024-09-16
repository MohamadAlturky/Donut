using Donut.Core.Pagination;


namespace Donut.QueryBuilding.Execution;

public class QueryExecutor
{
    //private readonly IDbConnectionFactory _factory;

    //public QueryExecutor(IDbConnectionFactory factory)
    //{
    //    _factory=factory;
    //}

    public PaginatedResponse<T> ExecuteQuery<T>(
    string selectClause,
    string tableName,
    string whereClause,
    object parameters,
    string orderByClause,
    PaginatedRequest paginatedRequest)
    {
        string countQuery = $"SELECT COUNT(*) FROM [{tableName}] {(string.IsNullOrEmpty(whereClause) ? "" : "WHERE " + whereClause)};";
        string dataQuery = $@"
            SELECT {selectClause} 
            FROM [{tableName}] 
            {(string.IsNullOrEmpty(whereClause) ? "" : "WHERE " + whereClause)} 
            {(string.IsNullOrEmpty(orderByClause) ? "" : "ORDER BY " + orderByClause)} 
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY;";
        Console.WriteLine(countQuery);
        Console.WriteLine(dataQuery);

        //using (var connection = _factory.CreateConnection())
        //{
        //    connection.Open();

        //    var queryParameters = new DynamicParameters(parameters);
        //    queryParameters.Add("@Offset", (paginatedRequest.PageNumber - 1) * paginatedRequest.PageSize);
        //    queryParameters.Add("@PageSize", paginatedRequest.PageSize);

        //    var totalCount = connection.ExecuteScalar<int>(countQuery, parameters);
        //    var items = connection.Query<T>(dataQuery, queryParameters).ToList();

        //    return new PaginatedResponse<T>
        //    {
        //        TotalCount = totalCount,
        //        Items = items
        //    };
        //}
        return new PaginatedResponse<T>();
    }

}
