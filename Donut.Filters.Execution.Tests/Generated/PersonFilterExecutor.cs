using Donut.Core.Filter;
using Donut.QueryBuilding.Enum;
using Donut.QueryBuilding.Utils;
using Donut.QueryBuilding.Builder;
using Donut.QueryBuilding.Execution;
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

        var queryBuilder = new StringBuilder();
        var parameters = new List<SqlParameter>();
        if (filter.SelectId)
        {
             queryBuilder.Append(Id);
        }
        if (filter.SelectName)
        {
             queryBuilder.Append(Name);
        }
        if (filter.SelectAge)
        {
             queryBuilder.Append(Age);
        }
        if (filter.SelectAge1)
        {
             queryBuilder.Append(Age1);
        }
        if (filter.SelectAgde1)
        {
             queryBuilder.Append(Agde1);
        }
        if (filter.Selectcool)
        {
             queryBuilder.Append(cool);
        }
        if (filter.SelectAgse1)
        {
             queryBuilder.Append(Agse1);
        }
        if (filter.SelectAgsse1)
        {
             queryBuilder.Append(Agsse1);
        }
        if (filter.SelectAgse1f)
        {
             queryBuilder.Append(Agse1f);
        }
        if (filter.SelectBirthDate)
        {
             queryBuilder.Append(BirthDate);
        }
        if (filter.OrderByIdAscending)
        {
             queryBuilder.Append(OrderByIdAscending);
        }
        if (filter.OrderByIdDescending)
        {
             queryBuilder.Append(OrderByIdDescending);
        }
        if (filter.OrderByNameAscending)
        {
             queryBuilder.Append(OrderByNameAscending);
        }
        if (filter.OrderByNameDescending)
        {
             queryBuilder.Append(OrderByNameDescending);
        }
        if (filter.OrderByAgeAscending)
        {
             queryBuilder.Append(OrderByAgeAscending);
        }
        if (filter.OrderByAgeDescending)
        {
             queryBuilder.Append(OrderByAgeDescending);
        }
        if (filter.OrderByAge1Ascending)
        {
             queryBuilder.Append(OrderByAge1Ascending);
        }
        if (filter.OrderByAge1Descending)
        {
             queryBuilder.Append(OrderByAge1Descending);
        }
        if (filter.OrderByAgde1Ascending)
        {
             queryBuilder.Append(OrderByAgde1Ascending);
        }
        if (filter.OrderByAgde1Descending)
        {
             queryBuilder.Append(OrderByAgde1Descending);
        }
        if (filter.OrderBycoolAscending)
        {
             queryBuilder.Append(OrderBycoolAscending);
        }
        if (filter.OrderBycoolDescending)
        {
             queryBuilder.Append(OrderBycoolDescending);
        }
        if (filter.OrderByAgse1Ascending)
        {
             queryBuilder.Append(OrderByAgse1Ascending);
        }
        if (filter.OrderByAgse1Descending)
        {
             queryBuilder.Append(OrderByAgse1Descending);
        }
        if (filter.OrderByAgsse1Ascending)
        {
             queryBuilder.Append(OrderByAgsse1Ascending);
        }
        if (filter.OrderByAgsse1Descending)
        {
             queryBuilder.Append(OrderByAgsse1Descending);
        }
        if (filter.OrderByAgse1fAscending)
        {
             queryBuilder.Append(OrderByAgse1fAscending);
        }
        if (filter.OrderByAgse1fDescending)
        {
             queryBuilder.Append(OrderByAgse1fDescending);
        }
        if (filter.OrderByBirthDateAscending)
        {
             queryBuilder.Append(OrderByBirthDateAscending);
        }
        if (filter.OrderByBirthDateDescending)
        {
             queryBuilder.Append(OrderByBirthDateDescending);
        }
        if (filter.Agse1fBiggerThanOrEqualDate is not null)
        {
             queryBuilder.Append(Agse1fBiggerThanOrEqualDate);
             parameters.Add(new SqlParameter("@p1", filter.Agse1fBiggerThanOrEqualDate));
        }
        if (filter.BirthDateBiggerThanOrEqualDate is not null)
        {
             queryBuilder.Append(BirthDateBiggerThanOrEqualDate);
             parameters.Add(new SqlParameter("@p2", filter.BirthDateBiggerThanOrEqualDate));
        }
        if (filter.Agse1fBiggerThanDate is not null)
        {
             queryBuilder.Append(Agse1fBiggerThanDate);
             parameters.Add(new SqlParameter("@p3", filter.Agse1fBiggerThanDate));
        }
        if (filter.BirthDateBiggerThanDate is not null)
        {
             queryBuilder.Append(BirthDateBiggerThanDate);
             parameters.Add(new SqlParameter("@p4", filter.BirthDateBiggerThanDate));
        }
        if (filter.Agse1fLessThanOrEqualDate is not null)
        {
             queryBuilder.Append(Agse1fLessThanOrEqualDate);
             parameters.Add(new SqlParameter("@p5", filter.Agse1fLessThanOrEqualDate));
        }
        if (filter.BirthDateLessThanOrEqualDate is not null)
        {
             queryBuilder.Append(BirthDateLessThanOrEqualDate);
             parameters.Add(new SqlParameter("@p6", filter.BirthDateLessThanOrEqualDate));
        }
        if (filter.Agse1fLessThanDate is not null)
        {
             queryBuilder.Append(Agse1fLessThanDate);
             parameters.Add(new SqlParameter("@p7", filter.Agse1fLessThanDate));
        }
        if (filter.BirthDateLessThanDate is not null)
        {
             queryBuilder.Append(BirthDateLessThanDate);
             parameters.Add(new SqlParameter("@p8", filter.BirthDateLessThanDate));
        }
        if (filter.IdBiggerThanOrEqualNumber is not null)
        {
             queryBuilder.Append(IdBiggerThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p9", filter.IdBiggerThanOrEqualNumber));
        }
        if (filter.AgeBiggerThanOrEqualNumber is not null)
        {
             queryBuilder.Append(AgeBiggerThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p10", filter.AgeBiggerThanOrEqualNumber));
        }
        if (filter.Age1BiggerThanOrEqualNumber is not null)
        {
             queryBuilder.Append(Age1BiggerThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p11", filter.Age1BiggerThanOrEqualNumber));
        }
        if (filter.Agse1BiggerThanOrEqualNumber is not null)
        {
             queryBuilder.Append(Agse1BiggerThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p12", filter.Agse1BiggerThanOrEqualNumber));
        }
        if (filter.Agsse1BiggerThanOrEqualNumber is not null)
        {
             queryBuilder.Append(Agsse1BiggerThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p13", filter.Agsse1BiggerThanOrEqualNumber));
        }
        if (filter.IdBiggerThanNumber is not null)
        {
             queryBuilder.Append(IdBiggerThanNumber);
             parameters.Add(new SqlParameter("@p14", filter.IdBiggerThanNumber));
        }
        if (filter.AgeBiggerThanNumber is not null)
        {
             queryBuilder.Append(AgeBiggerThanNumber);
             parameters.Add(new SqlParameter("@p15", filter.AgeBiggerThanNumber));
        }
        if (filter.Age1BiggerThanNumber is not null)
        {
             queryBuilder.Append(Age1BiggerThanNumber);
             parameters.Add(new SqlParameter("@p16", filter.Age1BiggerThanNumber));
        }
        if (filter.Agse1BiggerThanNumber is not null)
        {
             queryBuilder.Append(Agse1BiggerThanNumber);
             parameters.Add(new SqlParameter("@p17", filter.Agse1BiggerThanNumber));
        }
        if (filter.Agsse1BiggerThanNumber is not null)
        {
             queryBuilder.Append(Agsse1BiggerThanNumber);
             parameters.Add(new SqlParameter("@p18", filter.Agsse1BiggerThanNumber));
        }
        if (filter.IdLessThanOrEqualNumber is not null)
        {
             queryBuilder.Append(IdLessThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p19", filter.IdLessThanOrEqualNumber));
        }
        if (filter.AgeLessThanOrEqualNumber is not null)
        {
             queryBuilder.Append(AgeLessThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p20", filter.AgeLessThanOrEqualNumber));
        }
        if (filter.Age1LessThanOrEqualNumber is not null)
        {
             queryBuilder.Append(Age1LessThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p21", filter.Age1LessThanOrEqualNumber));
        }
        if (filter.Agse1LessThanOrEqualNumber is not null)
        {
             queryBuilder.Append(Agse1LessThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p22", filter.Agse1LessThanOrEqualNumber));
        }
        if (filter.Agsse1LessThanOrEqualNumber is not null)
        {
             queryBuilder.Append(Agsse1LessThanOrEqualNumber);
             parameters.Add(new SqlParameter("@p23", filter.Agsse1LessThanOrEqualNumber));
        }
        if (filter.IdLessThanNumber is not null)
        {
             queryBuilder.Append(IdLessThanNumber);
             parameters.Add(new SqlParameter("@p24", filter.IdLessThanNumber));
        }
        if (filter.AgeLessThanNumber is not null)
        {
             queryBuilder.Append(AgeLessThanNumber);
             parameters.Add(new SqlParameter("@p25", filter.AgeLessThanNumber));
        }
        if (filter.Age1LessThanNumber is not null)
        {
             queryBuilder.Append(Age1LessThanNumber);
             parameters.Add(new SqlParameter("@p26", filter.Age1LessThanNumber));
        }
        if (filter.Agse1LessThanNumber is not null)
        {
             queryBuilder.Append(Agse1LessThanNumber);
             parameters.Add(new SqlParameter("@p27", filter.Agse1LessThanNumber));
        }
        if (filter.Agsse1LessThanNumber is not null)
        {
             queryBuilder.Append(Agsse1LessThanNumber);
             parameters.Add(new SqlParameter("@p28", filter.Agsse1LessThanNumber));
        }
        if (filter.NameContains is not null)
        {
             queryBuilder.Append(NameContains);
             parameters.Add(new SqlParameter("@p29", filter.NameContains));
        }
        if (filter.NameStartsWith is not null)
        {
             queryBuilder.Append(NameStartsWith);
             parameters.Add(new SqlParameter("@p30", filter.NameStartsWith));
        }
        if (filter.NameEndsWith is not null)
        {
             queryBuilder.Append(NameEndsWith);
             parameters.Add(new SqlParameter("@p31", filter.NameEndsWith));
        }
        if (filter.IdEquals is not null)
        {
             queryBuilder.Append(IdEquals);
             parameters.Add(new SqlParameter("@p32", filter.IdEquals));
        }
        if (filter.NameEquals is not null)
        {
             queryBuilder.Append(NameEquals);
             parameters.Add(new SqlParameter("@p33", filter.NameEquals));
        }
        if (filter.AgeEquals is not null)
        {
             queryBuilder.Append(AgeEquals);
             parameters.Add(new SqlParameter("@p34", filter.AgeEquals));
        }
        if (filter.Age1Equals is not null)
        {
             queryBuilder.Append(Age1Equals);
             parameters.Add(new SqlParameter("@p35", filter.Age1Equals));
        }
        if (filter.Agde1Equals is not null)
        {
             queryBuilder.Append(Agde1Equals);
             parameters.Add(new SqlParameter("@p36", filter.Agde1Equals));
        }
        if (filter.coolEquals is not null)
        {
             queryBuilder.Append(coolEquals);
             parameters.Add(new SqlParameter("@p37", filter.coolEquals));
        }
        if (filter.Agse1Equals is not null)
        {
             queryBuilder.Append(Agse1Equals);
             parameters.Add(new SqlParameter("@p38", filter.Agse1Equals));
        }
        if (filter.Agsse1Equals is not null)
        {
             queryBuilder.Append(Agsse1Equals);
             parameters.Add(new SqlParameter("@p39", filter.Agsse1Equals));
        }
        if (filter.Agse1fEquals is not null)
        {
             queryBuilder.Append(Agse1fEquals);
             parameters.Add(new SqlParameter("@p40", filter.Agse1fEquals));
        }
        if (filter.BirthDateEquals is not null)
        {
             queryBuilder.Append(BirthDateEquals);
             parameters.Add(new SqlParameter("@p41", filter.BirthDateEquals));
        }
        if (filter.IdNotEqual is not null)
        {
             queryBuilder.Append(IdNotEqual);
             parameters.Add(new SqlParameter("@p42", filter.IdNotEqual));
        }
        if (filter.NameNotEqual is not null)
        {
             queryBuilder.Append(NameNotEqual);
             parameters.Add(new SqlParameter("@p43", filter.NameNotEqual));
        }
        if (filter.AgeNotEqual is not null)
        {
             queryBuilder.Append(AgeNotEqual);
             parameters.Add(new SqlParameter("@p44", filter.AgeNotEqual));
        }
        if (filter.Age1NotEqual is not null)
        {
             queryBuilder.Append(Age1NotEqual);
             parameters.Add(new SqlParameter("@p45", filter.Age1NotEqual));
        }
        if (filter.Agde1NotEqual is not null)
        {
             queryBuilder.Append(Agde1NotEqual);
             parameters.Add(new SqlParameter("@p46", filter.Agde1NotEqual));
        }
        if (filter.coolNotEqual is not null)
        {
             queryBuilder.Append(coolNotEqual);
             parameters.Add(new SqlParameter("@p47", filter.coolNotEqual));
        }
        if (filter.Agse1NotEqual is not null)
        {
             queryBuilder.Append(Agse1NotEqual);
             parameters.Add(new SqlParameter("@p48", filter.Agse1NotEqual));
        }
        if (filter.Agsse1NotEqual is not null)
        {
             queryBuilder.Append(Agsse1NotEqual);
             parameters.Add(new SqlParameter("@p49", filter.Agsse1NotEqual));
        }
        if (filter.Agse1fNotEqual is not null)
        {
             queryBuilder.Append(Agse1fNotEqual);
             parameters.Add(new SqlParameter("@p50", filter.Agse1fNotEqual));
        }
        if (filter.BirthDateNotEqual is not null)
        {
             queryBuilder.Append(BirthDateNotEqual);
             parameters.Add(new SqlParameter("@p51", filter.BirthDateNotEqual));
        }
        
       
        // Query Execution
        return new();
        //_executor.ExecuteQuery<Person>(selectClause, "Person", whereClause, parameters, orderByClause, filter.PaginatedRequest);
    }

    private static readonly string Id = "Id";
    private static readonly string Name = "Name";
    private static readonly string Age = "Age";
    private static readonly string Age1 = "Age1";
    private static readonly string Agde1 = "Agde1";
    private static readonly string cool = "cool";
    private static readonly string Agse1 = "Agse1";
    private static readonly string Agsse1 = "Agsse1";
    private static readonly string Agse1f = "Agse1f";
    private static readonly string BirthDate = "BirthDate";

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
