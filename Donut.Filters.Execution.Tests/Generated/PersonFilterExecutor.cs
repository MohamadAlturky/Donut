using Donut.Core.Filter;
using Donut.QueryBuilding.Enum;
using Donut.QueryBuilding.Utils;
using Donut.QueryBuilding.Execution;
using Donut.QueryBuilding.Builder;
using Microsoft.Data.SqlClient;
using System.Text;
using Donut.Core.Pagination;

namespace Donut.Filters.Execution;
public class PersonFilterExecutor: IFilterExecutor<Person,PersonFilter>
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
            if (filter.SelectAge1)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Age1);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Age1);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectAgde1)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Agde1);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Agde1);
                     isFirstSelect = false;
                }
            }
            if (filter.Selectcool)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(cool);
                }
                else
                {
                     selectQueryBuilder.Append(", "+cool);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectAgse1)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Agse1);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Agse1);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectAgsse1)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Agsse1);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Agsse1);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectAgse1f)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(Agse1f);
                }
                else
                {
                     selectQueryBuilder.Append(", "+Agse1f);
                     isFirstSelect = false;
                }
            }
            if (filter.SelectBirthDate)
            {
                if (isFirstSelect)
                {
                     selectQueryBuilder.Append(BirthDate);
                }
                else
                {
                     selectQueryBuilder.Append(", "+BirthDate);
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
        if (filter.OrderByAge1Ascending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAge1Ascending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAge1Ascending);
            }
        }
        if (filter.OrderByAge1Descending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAge1Descending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAge1Descending);
            }
        }
        if (filter.OrderByAgde1Ascending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgde1Ascending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgde1Ascending);
            }
        }
        if (filter.OrderByAgde1Descending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgde1Descending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgde1Descending);
            }
        }
        if (filter.OrderBycoolAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderBycoolAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderBycoolAscending);
            }
        }
        if (filter.OrderBycoolDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderBycoolDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderBycoolDescending);
            }
        }
        if (filter.OrderByAgse1Ascending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgse1Ascending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgse1Ascending);
            }
        }
        if (filter.OrderByAgse1Descending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgse1Descending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgse1Descending);
            }
        }
        if (filter.OrderByAgsse1Ascending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgsse1Ascending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgsse1Ascending);
            }
        }
        if (filter.OrderByAgsse1Descending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgsse1Descending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgsse1Descending);
            }
        }
        if (filter.OrderByAgse1fAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgse1fAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgse1fAscending);
            }
        }
        if (filter.OrderByAgse1fDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByAgse1fDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByAgse1fDescending);
            }
        }
        if (filter.OrderByBirthDateAscending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByBirthDateAscending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByBirthDateAscending);
            }
        }
        if (filter.OrderByBirthDateDescending)
        {
            if (isFirstOrderBy)
            {
                 orderByQueryBuilder.Append(OrderByBirthDateDescending);
                 isFirstOrderBy = false;
            }
            else
            {
                 orderByQueryBuilder.Append(", "+OrderByBirthDateDescending);
            }
        }

        bool isFirstWhere = true;
        if (filter.Agse1fBiggerThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1fBiggerThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1fBiggerThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p1", filter.Agse1fBiggerThanOrEqualDate));
        }
        if (filter.BirthDateBiggerThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(BirthDateBiggerThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+BirthDateBiggerThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p2", filter.BirthDateBiggerThanOrEqualDate));
        }
        if (filter.Agse1fBiggerThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1fBiggerThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1fBiggerThanDate);
             }
             parameters.Add(new SqlParameter("@p3", filter.Agse1fBiggerThanDate));
        }
        if (filter.BirthDateBiggerThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(BirthDateBiggerThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+BirthDateBiggerThanDate);
             }
             parameters.Add(new SqlParameter("@p4", filter.BirthDateBiggerThanDate));
        }
        if (filter.Agse1fLessThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1fLessThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1fLessThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p5", filter.Agse1fLessThanOrEqualDate));
        }
        if (filter.BirthDateLessThanOrEqualDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(BirthDateLessThanOrEqualDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+BirthDateLessThanOrEqualDate);
             }
             parameters.Add(new SqlParameter("@p6", filter.BirthDateLessThanOrEqualDate));
        }
        if (filter.Agse1fLessThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1fLessThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1fLessThanDate);
             }
             parameters.Add(new SqlParameter("@p7", filter.Agse1fLessThanDate));
        }
        if (filter.BirthDateLessThanDate is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(BirthDateLessThanDate);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+BirthDateLessThanDate);
             }
             parameters.Add(new SqlParameter("@p8", filter.BirthDateLessThanDate));
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
        if (filter.Age1BiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Age1BiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Age1BiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p11", filter.Age1BiggerThanOrEqualNumber));
        }
        if (filter.Agse1BiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1BiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1BiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p12", filter.Agse1BiggerThanOrEqualNumber));
        }
        if (filter.Agsse1BiggerThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agsse1BiggerThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agsse1BiggerThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p13", filter.Agsse1BiggerThanOrEqualNumber));
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
        if (filter.Age1BiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Age1BiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Age1BiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p16", filter.Age1BiggerThanNumber));
        }
        if (filter.Agse1BiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1BiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1BiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p17", filter.Agse1BiggerThanNumber));
        }
        if (filter.Agsse1BiggerThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agsse1BiggerThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agsse1BiggerThanNumber);
             }
             parameters.Add(new SqlParameter("@p18", filter.Agsse1BiggerThanNumber));
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
        if (filter.Age1LessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Age1LessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Age1LessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p21", filter.Age1LessThanOrEqualNumber));
        }
        if (filter.Agse1LessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1LessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1LessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p22", filter.Agse1LessThanOrEqualNumber));
        }
        if (filter.Agsse1LessThanOrEqualNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agsse1LessThanOrEqualNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agsse1LessThanOrEqualNumber);
             }
             parameters.Add(new SqlParameter("@p23", filter.Agsse1LessThanOrEqualNumber));
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
        if (filter.Age1LessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Age1LessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Age1LessThanNumber);
             }
             parameters.Add(new SqlParameter("@p26", filter.Age1LessThanNumber));
        }
        if (filter.Agse1LessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1LessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1LessThanNumber);
             }
             parameters.Add(new SqlParameter("@p27", filter.Agse1LessThanNumber));
        }
        if (filter.Agsse1LessThanNumber is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agsse1LessThanNumber);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agsse1LessThanNumber);
             }
             parameters.Add(new SqlParameter("@p28", filter.Agsse1LessThanNumber));
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
        if (filter.Age1Equals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Age1Equals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Age1Equals);
             }
             parameters.Add(new SqlParameter("@p35", filter.Age1Equals));
        }
        if (filter.Agde1Equals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agde1Equals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agde1Equals);
             }
             parameters.Add(new SqlParameter("@p36", filter.Agde1Equals));
        }
        if (filter.coolEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(coolEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+coolEquals);
             }
             parameters.Add(new SqlParameter("@p37", filter.coolEquals));
        }
        if (filter.Agse1Equals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1Equals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1Equals);
             }
             parameters.Add(new SqlParameter("@p38", filter.Agse1Equals));
        }
        if (filter.Agsse1Equals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agsse1Equals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agsse1Equals);
             }
             parameters.Add(new SqlParameter("@p39", filter.Agsse1Equals));
        }
        if (filter.Agse1fEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1fEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1fEquals);
             }
             parameters.Add(new SqlParameter("@p40", filter.Agse1fEquals));
        }
        if (filter.BirthDateEquals is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(BirthDateEquals);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+BirthDateEquals);
             }
             parameters.Add(new SqlParameter("@p41", filter.BirthDateEquals));
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
        if (filter.Age1NotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Age1NotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Age1NotEqual);
             }
             parameters.Add(new SqlParameter("@p45", filter.Age1NotEqual));
        }
        if (filter.Agde1NotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agde1NotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agde1NotEqual);
             }
             parameters.Add(new SqlParameter("@p46", filter.Agde1NotEqual));
        }
        if (filter.coolNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(coolNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+coolNotEqual);
             }
             parameters.Add(new SqlParameter("@p47", filter.coolNotEqual));
        }
        if (filter.Agse1NotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1NotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1NotEqual);
             }
             parameters.Add(new SqlParameter("@p48", filter.Agse1NotEqual));
        }
        if (filter.Agsse1NotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agsse1NotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agsse1NotEqual);
             }
             parameters.Add(new SqlParameter("@p49", filter.Agsse1NotEqual));
        }
        if (filter.Agse1fNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(Agse1fNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+Agse1fNotEqual);
             }
             parameters.Add(new SqlParameter("@p50", filter.Agse1fNotEqual));
        }
        if (filter.BirthDateNotEqual is not null)
        {
             if(isFirstWhere)
             {
                  whereQueryBuilder.Append(BirthDateNotEqual);
                  isFirstWhere = false;
             }
             else
             {
                  whereQueryBuilder.Append(" AND "+BirthDateNotEqual);
             }
             parameters.Add(new SqlParameter("@p51", filter.BirthDateNotEqual));
        }
        
       
        // Query Execution
        return _executor.ExecuteQuery<Person>(selectQueryBuilder.ToString(), "Person", whereQueryBuilder.ToString(), parameters, orderByQueryBuilder.ToString(), filter.PaginatedRequest);
    }

    private static readonly string Id = "[Id]";
    private static readonly string Name = "[Name]";
    private static readonly string Age = "[Age]";
    private static readonly string Age1 = "[Age1]";
    private static readonly string Agde1 = "[Agde1]";
    private static readonly string cool = "[cool]";
    private static readonly string Agse1 = "[Agse1]";
    private static readonly string Agsse1 = "[Agsse1]";
    private static readonly string Agse1f = "[Agse1f]";
    private static readonly string BirthDate = "[BirthDate]";

    private static readonly string OrderByIdAscending = "[Id] ASC";
    private static readonly string OrderByIdDescending = "[Id] DESC";
    private static readonly string OrderByNameAscending = "[Name] ASC";
    private static readonly string OrderByNameDescending = "[Name] DESC";
    private static readonly string OrderByAgeAscending = "[Age] ASC";
    private static readonly string OrderByAgeDescending = "[Age] DESC";
    private static readonly string OrderByAge1Ascending = "[Age1] ASC";
    private static readonly string OrderByAge1Descending = "[Age1] DESC";
    private static readonly string OrderByAgde1Ascending = "[Agde1] ASC";
    private static readonly string OrderByAgde1Descending = "[Agde1] DESC";
    private static readonly string OrderBycoolAscending = "[cool] ASC";
    private static readonly string OrderBycoolDescending = "[cool] DESC";
    private static readonly string OrderByAgse1Ascending = "[Agse1] ASC";
    private static readonly string OrderByAgse1Descending = "[Agse1] DESC";
    private static readonly string OrderByAgsse1Ascending = "[Agsse1] ASC";
    private static readonly string OrderByAgsse1Descending = "[Agsse1] DESC";
    private static readonly string OrderByAgse1fAscending = "[Agse1f] ASC";
    private static readonly string OrderByAgse1fDescending = "[Agse1f] DESC";
    private static readonly string OrderByBirthDateAscending = "[BirthDate] ASC";
    private static readonly string OrderByBirthDateDescending = "[BirthDate] DESC";


    private static readonly string Agse1fBiggerThanOrEqualDate = "[Agse1f] >= CAST(@p1 AS DATE)";
    private static readonly string BirthDateBiggerThanOrEqualDate = "[BirthDate] >= CAST(@p2 AS DATE)";
    private static readonly string Agse1fBiggerThanDate = "[Agse1f] > CAST(@p3 AS DATE)";
    private static readonly string BirthDateBiggerThanDate = "[BirthDate] > CAST(@p4 AS DATE)";
    private static readonly string Agse1fLessThanOrEqualDate = "[Agse1f] <= CAST(@p5 AS DATE)";
    private static readonly string BirthDateLessThanOrEqualDate = "[BirthDate] <= CAST(@p6 AS DATE)";
    private static readonly string Agse1fLessThanDate = "[Agse1f] < CAST(@p7 AS DATE)";
    private static readonly string BirthDateLessThanDate = "[BirthDate] < CAST(@p8 AS DATE)";
    private static readonly string IdBiggerThanOrEqualNumber = "[Id] >= @p9";
    private static readonly string AgeBiggerThanOrEqualNumber = "[Age] >= @p10";
    private static readonly string Age1BiggerThanOrEqualNumber = "[Age1] >= @p11";
    private static readonly string Agse1BiggerThanOrEqualNumber = "[Agse1] >= @p12";
    private static readonly string Agsse1BiggerThanOrEqualNumber = "[Agsse1] >= @p13";
    private static readonly string IdBiggerThanNumber = "[Id] > @p14";
    private static readonly string AgeBiggerThanNumber = "[Age] > @p15";
    private static readonly string Age1BiggerThanNumber = "[Age1] > @p16";
    private static readonly string Agse1BiggerThanNumber = "[Agse1] > @p17";
    private static readonly string Agsse1BiggerThanNumber = "[Agsse1] > @p18";
    private static readonly string IdLessThanOrEqualNumber = "[Id] <= @p19";
    private static readonly string AgeLessThanOrEqualNumber = "[Age] <= @p20";
    private static readonly string Age1LessThanOrEqualNumber = "[Age1] <= @p21";
    private static readonly string Agse1LessThanOrEqualNumber = "[Agse1] <= @p22";
    private static readonly string Agsse1LessThanOrEqualNumber = "[Agsse1] <= @p23";
    private static readonly string IdLessThanNumber = "[Id] < @p24";
    private static readonly string AgeLessThanNumber = "[Age] < @p25";
    private static readonly string Age1LessThanNumber = "[Age1] < @p26";
    private static readonly string Agse1LessThanNumber = "[Agse1] < @p27";
    private static readonly string Agsse1LessThanNumber = "[Agsse1] < @p28";
    private static readonly string NameContains = "[Name] LIKE '%' + @p29 + '%'";
    private static readonly string NameStartsWith = "[Name] LIKE @p30 + '%'";
    private static readonly string NameEndsWith = "[Name] LIKE '%' + @p31";
    private static readonly string IdEquals = "[Id] = @p32";
    private static readonly string NameEquals = "[Name] = @p33";
    private static readonly string AgeEquals = "[Age] = @p34";
    private static readonly string Age1Equals = "[Age1] = @p35";
    private static readonly string Agde1Equals = "[Agde1] = @p36";
    private static readonly string coolEquals = "[cool] = @p37";
    private static readonly string Agse1Equals = "[Agse1] = @p38";
    private static readonly string Agsse1Equals = "[Agsse1] = @p39";
    private static readonly string Agse1fEquals = "[Agse1f] = @p40";
    private static readonly string BirthDateEquals = "[BirthDate] = @p41";
    private static readonly string IdNotEqual = "[Id] <> @p42";
    private static readonly string NameNotEqual = "[Name] <> @p43";
    private static readonly string AgeNotEqual = "[Age] <> @p44";
    private static readonly string Age1NotEqual = "[Age1] <> @p45";
    private static readonly string Agde1NotEqual = "[Agde1] <> @p46";
    private static readonly string coolNotEqual = "[cool] <> @p47";
    private static readonly string Agse1NotEqual = "[Agse1] <> @p48";
    private static readonly string Agsse1NotEqual = "[Agsse1] <> @p49";
    private static readonly string Agse1fNotEqual = "[Agse1f] <> @p50";
    private static readonly string BirthDateNotEqual = "[BirthDate] <> @p51";

}
