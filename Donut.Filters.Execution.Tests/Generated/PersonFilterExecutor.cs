using Donut.Core.Filter;
using Donut.QueryBuilding.Enum;
using Donut.QueryBuilding.Utils;
using Donut.QueryBuilding.Execution;
using Donut.QueryBuilding.Builder;
using Microsoft.Data.SqlClient;
using System.Text;
using Donut.Core.Pagination;
using Donut.SharedKernel.Tabels;

namespace Donut.Filters.Execution;
public interface IPersonFilterExecutor : IFilterExecutor<Person, PersonFilter>
{

}

public class PersonFilterExecutor: IPersonFilterExecutor
{
    private readonly QueryExecutor _executor;

    public PersonFilterExecutor(QueryExecutor executor)
    {
        _executor=executor;
    }
    // For Every Filter
    public PaginatedResponse<Person> Execute(PersonFilter filter)
    {

        var whereQueryBuilder = new StringBuilder();
        var selectQueryBuilder = new StringBuilder();
        var orderByQueryBuilder = new StringBuilder();
        var parameters = new List<SqlParameter>();

        bool isFirstSelect = true;
        if (filter.EagerLoading)
        {
            selectQueryBuilder.Append("*");
        }
        else
        {
            if (filter.SelectId)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Id);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Id);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectName)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Name);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Name);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectAge)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Age);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Age);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectWifes)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Wifes);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Wifes);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectChar)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Char);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Char);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectAlive)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Alive);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Alive);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectImportance)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Importance);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Importance);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectNonImportance)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(NonImportance);
                }
                else
                {
                     selectQueryBuilder.Append(", "+NonImportance);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectYear)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Year);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Year);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectDateOfBirth)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(DateOfBirth);
                }
                else
                {
                     selectQueryBuilder.Append(", "+DateOfBirth);
                     isFirstSelect = false;
                }
            }
        }

        bool isFirstOrderBy = true;
        if (filter.OrderByIdAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByIdAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByIdAscending);
            }
        }
        if (filter.OrderByIdDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByIdDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByIdDescending);
            }
        }
        if (filter.OrderByNameAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByNameAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByNameAscending);
            }
        }
        if (filter.OrderByNameDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByNameDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByNameDescending);
            }
        }
        if (filter.OrderByAgeAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgeAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgeAscending);
            }
        }
        if (filter.OrderByAgeDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgeDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgeDescending);
            }
        }
        if (filter.OrderByWifesAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByWifesAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByWifesAscending);
            }
        }
        if (filter.OrderByWifesDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByWifesDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByWifesDescending);
            }
        }
        if (filter.OrderByCharAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByCharAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByCharAscending);
            }
        }
        if (filter.OrderByCharDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByCharDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByCharDescending);
            }
        }
        if (filter.OrderByAliveAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAliveAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAliveAscending);
            }
        }
        if (filter.OrderByAliveDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAliveDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAliveDescending);
            }
        }
        if (filter.OrderByImportanceAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByImportanceAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByImportanceAscending);
            }
        }
        if (filter.OrderByImportanceDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByImportanceDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByImportanceDescending);
            }
        }
        if (filter.OrderByNonImportanceAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByNonImportanceAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByNonImportanceAscending);
            }
        }
        if (filter.OrderByNonImportanceDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByNonImportanceDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByNonImportanceDescending);
            }
        }
        if (filter.OrderByYearAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByYearAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByYearAscending);
            }
        }
        if (filter.OrderByYearDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByYearDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByYearDescending);
            }
        }
        if (filter.OrderByDateOfBirthAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByDateOfBirthAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByDateOfBirthAscending);
            }
        }
        if (filter.OrderByDateOfBirthDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByDateOfBirthDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByDateOfBirthDescending);
            }
        }

        bool isFirstWhere = true;
        if (filter.YearBiggerThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(YearBiggerThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+YearBiggerThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p1", filter.YearBiggerThanOrEqualDate));
        }
        if (filter.DateOfBirthBiggerThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(DateOfBirthBiggerThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+DateOfBirthBiggerThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p2", filter.DateOfBirthBiggerThanOrEqualDate));
        }
        if (filter.YearBiggerThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(YearBiggerThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+YearBiggerThanDate);
             }
             parameters.Add(new SqlParameter("@p3", filter.YearBiggerThanDate));
        }
        if (filter.DateOfBirthBiggerThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(DateOfBirthBiggerThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+DateOfBirthBiggerThanDate);
             }
             parameters.Add(new SqlParameter("@p4", filter.DateOfBirthBiggerThanDate));
        }
        if (filter.YearLessThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(YearLessThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+YearLessThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p5", filter.YearLessThanOrEqualDate));
        }
        if (filter.DateOfBirthLessThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(DateOfBirthLessThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+DateOfBirthLessThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p6", filter.DateOfBirthLessThanOrEqualDate));
        }
        if (filter.YearLessThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(YearLessThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+YearLessThanDate);
             }
             parameters.Add(new SqlParameter("@p7", filter.YearLessThanDate));
        }
        if (filter.DateOfBirthLessThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(DateOfBirthLessThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+DateOfBirthLessThanDate);
             }
             parameters.Add(new SqlParameter("@p8", filter.DateOfBirthLessThanDate));
        }
        if (filter.IdBiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(IdBiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+IdBiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p9", filter.IdBiggerThanOrEqualNumber));
        }
        if (filter.AgeBiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AgeBiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AgeBiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p10", filter.AgeBiggerThanOrEqualNumber));
        }
        if (filter.WifesBiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(WifesBiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+WifesBiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p11", filter.WifesBiggerThanOrEqualNumber));
        }
        if (filter.ImportanceBiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(ImportanceBiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+ImportanceBiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p12", filter.ImportanceBiggerThanOrEqualNumber));
        }
        if (filter.NonImportanceBiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NonImportanceBiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NonImportanceBiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p13", filter.NonImportanceBiggerThanOrEqualNumber));
        }
        if (filter.IdBiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(IdBiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+IdBiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p14", filter.IdBiggerThanNumber));
        }
        if (filter.AgeBiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AgeBiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AgeBiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p15", filter.AgeBiggerThanNumber));
        }
        if (filter.WifesBiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(WifesBiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+WifesBiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p16", filter.WifesBiggerThanNumber));
        }
        if (filter.ImportanceBiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(ImportanceBiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+ImportanceBiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p17", filter.ImportanceBiggerThanNumber));
        }
        if (filter.NonImportanceBiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NonImportanceBiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NonImportanceBiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p18", filter.NonImportanceBiggerThanNumber));
        }
        if (filter.IdLessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(IdLessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+IdLessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p19", filter.IdLessThanOrEqualNumber));
        }
        if (filter.AgeLessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AgeLessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AgeLessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p20", filter.AgeLessThanOrEqualNumber));
        }
        if (filter.WifesLessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(WifesLessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+WifesLessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p21", filter.WifesLessThanOrEqualNumber));
        }
        if (filter.ImportanceLessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(ImportanceLessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+ImportanceLessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p22", filter.ImportanceLessThanOrEqualNumber));
        }
        if (filter.NonImportanceLessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NonImportanceLessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NonImportanceLessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p23", filter.NonImportanceLessThanOrEqualNumber));
        }
        if (filter.IdLessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(IdLessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+IdLessThanNumber);
             }
             parameters.Add(new SqlParameter("@p24", filter.IdLessThanNumber));
        }
        if (filter.AgeLessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AgeLessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AgeLessThanNumber);
             }
             parameters.Add(new SqlParameter("@p25", filter.AgeLessThanNumber));
        }
        if (filter.WifesLessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(WifesLessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+WifesLessThanNumber);
             }
             parameters.Add(new SqlParameter("@p26", filter.WifesLessThanNumber));
        }
        if (filter.ImportanceLessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(ImportanceLessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+ImportanceLessThanNumber);
             }
             parameters.Add(new SqlParameter("@p27", filter.ImportanceLessThanNumber));
        }
        if (filter.NonImportanceLessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NonImportanceLessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NonImportanceLessThanNumber);
             }
             parameters.Add(new SqlParameter("@p28", filter.NonImportanceLessThanNumber));
        }
        if (filter.NameContains is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NameContains);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NameContains);
             }
             parameters.Add(new SqlParameter("@p29", filter.NameContains));
        }
        if (filter.NameStartsWith is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NameStartsWith);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NameStartsWith);
             }
             parameters.Add(new SqlParameter("@p30", filter.NameStartsWith));
        }
        if (filter.NameEndsWith is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NameEndsWith);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NameEndsWith);
             }
             parameters.Add(new SqlParameter("@p31", filter.NameEndsWith));
        }
        if (filter.IdEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(IdEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+IdEquals);
             }
             parameters.Add(new SqlParameter("@p32", filter.IdEquals));
        }
        if (filter.NameEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NameEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NameEquals);
             }
             parameters.Add(new SqlParameter("@p33", filter.NameEquals));
        }
        if (filter.AgeEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AgeEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AgeEquals);
             }
             parameters.Add(new SqlParameter("@p34", filter.AgeEquals));
        }
        if (filter.WifesEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(WifesEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+WifesEquals);
             }
             parameters.Add(new SqlParameter("@p35", filter.WifesEquals));
        }
        if (filter.CharEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(CharEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+CharEquals);
             }
             parameters.Add(new SqlParameter("@p36", filter.CharEquals));
        }
        if (filter.AliveEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AliveEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AliveEquals);
             }
             parameters.Add(new SqlParameter("@p37", filter.AliveEquals));
        }
        if (filter.ImportanceEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(ImportanceEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+ImportanceEquals);
             }
             parameters.Add(new SqlParameter("@p38", filter.ImportanceEquals));
        }
        if (filter.NonImportanceEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NonImportanceEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NonImportanceEquals);
             }
             parameters.Add(new SqlParameter("@p39", filter.NonImportanceEquals));
        }
        if (filter.YearEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(YearEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+YearEquals);
             }
             parameters.Add(new SqlParameter("@p40", filter.YearEquals));
        }
        if (filter.DateOfBirthEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(DateOfBirthEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+DateOfBirthEquals);
             }
             parameters.Add(new SqlParameter("@p41", filter.DateOfBirthEquals));
        }
        if (filter.IdNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(IdNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+IdNotEqual);
             }
             parameters.Add(new SqlParameter("@p42", filter.IdNotEqual));
        }
        if (filter.NameNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NameNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NameNotEqual);
             }
             parameters.Add(new SqlParameter("@p43", filter.NameNotEqual));
        }
        if (filter.AgeNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AgeNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AgeNotEqual);
             }
             parameters.Add(new SqlParameter("@p44", filter.AgeNotEqual));
        }
        if (filter.WifesNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(WifesNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+WifesNotEqual);
             }
             parameters.Add(new SqlParameter("@p45", filter.WifesNotEqual));
        }
        if (filter.CharNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(CharNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+CharNotEqual);
             }
             parameters.Add(new SqlParameter("@p46", filter.CharNotEqual));
        }
        if (filter.AliveNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(AliveNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+AliveNotEqual);
             }
             parameters.Add(new SqlParameter("@p47", filter.AliveNotEqual));
        }
        if (filter.ImportanceNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(ImportanceNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+ImportanceNotEqual);
             }
             parameters.Add(new SqlParameter("@p48", filter.ImportanceNotEqual));
        }
        if (filter.NonImportanceNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(NonImportanceNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+NonImportanceNotEqual);
             }
             parameters.Add(new SqlParameter("@p49", filter.NonImportanceNotEqual));
        }
        if (filter.YearNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(YearNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+YearNotEqual);
             }
             parameters.Add(new SqlParameter("@p50", filter.YearNotEqual));
        }
        if (filter.DateOfBirthNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(DateOfBirthNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+DateOfBirthNotEqual);
             }
             parameters.Add(new SqlParameter("@p51", filter.DateOfBirthNotEqual));
        }
        
       
        // Query Execution
        return _executor.ExecuteQuery<Person>(selectQueryBuilder.ToString(), "Person", whereQueryBuilder.ToString(), parameters, orderByQueryBuilder.ToString(), filter.PaginatedRequest);
    }

    private static readonly string Id = "[Id]";
    private static readonly string Name = "[Name]";
    private static readonly string Age = "[Age]";
    private static readonly string Wifes = "[Wifes]";
    private static readonly string Char = "[Char]";
    private static readonly string Alive = "[Alive]";
    private static readonly string Importance = "[Importance]";
    private static readonly string NonImportance = "[NonImportance]";
    private static readonly string Year = "[Year]";
    private static readonly string DateOfBirth = "[DateOfBirth]";

    private static readonly string OrderByIdAscending = "[Id] ASC";
    private static readonly string OrderByIdDescending = "[Id] DESC";
    private static readonly string OrderByNameAscending = "[Name] ASC";
    private static readonly string OrderByNameDescending = "[Name] DESC";
    private static readonly string OrderByAgeAscending = "[Age] ASC";
    private static readonly string OrderByAgeDescending = "[Age] DESC";
    private static readonly string OrderByWifesAscending = "[Wifes] ASC";
    private static readonly string OrderByWifesDescending = "[Wifes] DESC";
    private static readonly string OrderByCharAscending = "[Char] ASC";
    private static readonly string OrderByCharDescending = "[Char] DESC";
    private static readonly string OrderByAliveAscending = "[Alive] ASC";
    private static readonly string OrderByAliveDescending = "[Alive] DESC";
    private static readonly string OrderByImportanceAscending = "[Importance] ASC";
    private static readonly string OrderByImportanceDescending = "[Importance] DESC";
    private static readonly string OrderByNonImportanceAscending = "[NonImportance] ASC";
    private static readonly string OrderByNonImportanceDescending = "[NonImportance] DESC";
    private static readonly string OrderByYearAscending = "[Year] ASC";
    private static readonly string OrderByYearDescending = "[Year] DESC";
    private static readonly string OrderByDateOfBirthAscending = "[DateOfBirth] ASC";
    private static readonly string OrderByDateOfBirthDescending = "[DateOfBirth] DESC";


    private static readonly string YearBiggerThanOrEqualDate = "[Year] >= CAST(@p1 AS DATE)";
    private static readonly string DateOfBirthBiggerThanOrEqualDate = "[DateOfBirth] >= CAST(@p2 AS DATE)";
    private static readonly string YearBiggerThanDate = "[Year] > CAST(@p3 AS DATE)";
    private static readonly string DateOfBirthBiggerThanDate = "[DateOfBirth] > CAST(@p4 AS DATE)";
    private static readonly string YearLessThanOrEqualDate = "[Year] <= CAST(@p5 AS DATE)";
    private static readonly string DateOfBirthLessThanOrEqualDate = "[DateOfBirth] <= CAST(@p6 AS DATE)";
    private static readonly string YearLessThanDate = "[Year] < CAST(@p7 AS DATE)";
    private static readonly string DateOfBirthLessThanDate = "[DateOfBirth] < CAST(@p8 AS DATE)";
    private static readonly string IdBiggerThanOrEqualNumber = "[Id] >= @p9";
    private static readonly string AgeBiggerThanOrEqualNumber = "[Age] >= @p10";
    private static readonly string WifesBiggerThanOrEqualNumber = "[Wifes] >= @p11";
    private static readonly string ImportanceBiggerThanOrEqualNumber = "[Importance] >= @p12";
    private static readonly string NonImportanceBiggerThanOrEqualNumber = "[NonImportance] >= @p13";
    private static readonly string IdBiggerThanNumber = "[Id] > @p14";
    private static readonly string AgeBiggerThanNumber = "[Age] > @p15";
    private static readonly string WifesBiggerThanNumber = "[Wifes] > @p16";
    private static readonly string ImportanceBiggerThanNumber = "[Importance] > @p17";
    private static readonly string NonImportanceBiggerThanNumber = "[NonImportance] > @p18";
    private static readonly string IdLessThanOrEqualNumber = "[Id] <= @p19";
    private static readonly string AgeLessThanOrEqualNumber = "[Age] <= @p20";
    private static readonly string WifesLessThanOrEqualNumber = "[Wifes] <= @p21";
    private static readonly string ImportanceLessThanOrEqualNumber = "[Importance] <= @p22";
    private static readonly string NonImportanceLessThanOrEqualNumber = "[NonImportance] <= @p23";
    private static readonly string IdLessThanNumber = "[Id] < @p24";
    private static readonly string AgeLessThanNumber = "[Age] < @p25";
    private static readonly string WifesLessThanNumber = "[Wifes] < @p26";
    private static readonly string ImportanceLessThanNumber = "[Importance] < @p27";
    private static readonly string NonImportanceLessThanNumber = "[NonImportance] < @p28";
    private static readonly string NameContains = "[Name] LIKE '%' + @p29 + '%'";
    private static readonly string NameStartsWith = "[Name] LIKE @p30 + '%'";
    private static readonly string NameEndsWith = "[Name] LIKE '%' + @p31";
    private static readonly string IdEquals = "[Id] = @p32";
    private static readonly string NameEquals = "[Name] = @p33";
    private static readonly string AgeEquals = "[Age] = @p34";
    private static readonly string WifesEquals = "[Wifes] = @p35";
    private static readonly string CharEquals = "[Char] = @p36";
    private static readonly string AliveEquals = "[Alive] = @p37";
    private static readonly string ImportanceEquals = "[Importance] = @p38";
    private static readonly string NonImportanceEquals = "[NonImportance] = @p39";
    private static readonly string YearEquals = "[Year] = @p40";
    private static readonly string DateOfBirthEquals = "[DateOfBirth] = @p41";
    private static readonly string IdNotEqual = "[Id] <> @p42";
    private static readonly string NameNotEqual = "[Name] <> @p43";
    private static readonly string AgeNotEqual = "[Age] <> @p44";
    private static readonly string WifesNotEqual = "[Wifes] <> @p45";
    private static readonly string CharNotEqual = "[Char] <> @p46";
    private static readonly string AliveNotEqual = "[Alive] <> @p47";
    private static readonly string ImportanceNotEqual = "[Importance] <> @p48";
    private static readonly string NonImportanceNotEqual = "[NonImportance] <> @p49";
    private static readonly string YearNotEqual = "[Year] <> @p50";
    private static readonly string DateOfBirthNotEqual = "[DateOfBirth] <> @p51";

}
