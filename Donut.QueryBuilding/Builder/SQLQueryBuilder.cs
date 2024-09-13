using Donut.QueryBuilding.Enum;
using Donut.SharedKernel.Filters.Utils;
using Microsoft.Data.SqlClient;
using System.Text;

namespace Donut.QueryBuilding.Builder;

public class SQLQueryBuilder
{
    public static string BuildOrderByClause(List<OrderBy> criteria)
    {
        if (criteria == null || criteria.Count==0)
            return string.Empty;

        var orderByClause = new StringBuilder("ORDER BY ");

        for (int i = 0; i < criteria.Count; i++)
        {
            var criterion = criteria[i];

            if (i > 0)
                orderByClause.Append(", ");

            orderByClause.AppendFormat("[{0}] {1}",
                criterion.Column,
                criterion.Direction == OrderDirection.Ascending ? "ASC" : "DESC");
        }

        return orderByClause.ToString();
    }
    public static (string WhereClause, List<SqlParameter> Parameters) BuildWhereClause<T>(List<Where<T>> criteria)
    {
        if (criteria == null || !criteria.Any())
            return (string.Empty, new List<SqlParameter>());

        var whereClause = new StringBuilder();
        var parameters = new List<SqlParameter>();
        var parameterIndex = 1;

        foreach (var criterion in criteria)
        {
            if (whereClause.Length > 0)
                whereClause.Append(" AND ");

            string parameterName = $"@p{parameterIndex}";
            WhereClauseUtils.UpdateWhereClause(whereClause, criterion, parameterName);

            parameters.Add(new SqlParameter(parameterName, criterion.Value));
            parameterIndex++;
        }

        return (whereClause.ToString(), parameters);
    }


    public static string BuildSelectClause(List<Select> selects)
    {
        if (selects == null || selects.Count == 0)
        {
            return $"*";
        }

        string columns = string.Empty;
        for (int i = 0; i < selects.Count; i++)
        {
            columns += $"[{selects[i].Column}]";
            if (i < selects.Count - 1)
            {
                columns += ", ";
            }
        }

        return $"{columns}";
    }
    public static class WhereClauseUtils
    {
        public static void UpdateWhereClause<T>(StringBuilder whereClause, Where<T> criterion, string parameterName)
        {
            switch (criterion.Action)
            {
                case Operator.Equals:
                    whereClause.AppendFormat("[{0}] = {1}", criterion.Column, parameterName);
                    break;
                case Operator.NotEqual:
                    whereClause.AppendFormat("[{0}] <> {1}", criterion.Column, parameterName);
                    break;
                case Operator.LessThan:
                    whereClause.AppendFormat("[{0}] < {1}", criterion.Column, parameterName);
                    break;
                case Operator.LessThanOrEqual:
                    whereClause.AppendFormat("[{0}] <= {1}", criterion.Column, parameterName);
                    break;
                case Operator.GreaterThan:
                    whereClause.AppendFormat("[{0}] > {1}", criterion.Column, parameterName);
                    break;
                case Operator.GreaterThanOrEqual:
                    whereClause.AppendFormat("[{0}] >= {1}", criterion.Column, parameterName);
                    break;
                case Operator.Like:
                    whereClause.AppendFormat("[{0}] LIKE {1}", criterion.Column, parameterName);
                    break;
                case Operator.Contains:
                    whereClause.AppendFormat("[{0}] LIKE '%' + {1} + '%'", criterion.Column, parameterName);
                    break;
                default:
                    throw new ArgumentException($"Unsupported filter action: {criterion.Action}", nameof(criterion.Action));
            }
        }
    }
