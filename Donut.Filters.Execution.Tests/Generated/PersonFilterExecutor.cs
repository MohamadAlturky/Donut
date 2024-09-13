using Donut.Core.Filter;
using Donut.QueryBuilding.Enum;
using Donut.QueryBuilding.Utils;
using Donut.Core.Pagination;

namespace Donut.Filters.Execution;
public class PersonFilterExecutor: IFilterExecutor<Person,PersonFilter>
{
    // For Every Filter
    public PaginatedResponse<Person> Execute(PersonFilter filter)
    {

        var selectList = new List<Select>();
        var whereList = new List<Where<object>>();
        var orderByList = new List<OrderBy>();
        if (filter.SelectAll)
        {
             selectList.Add(new Select() { Column = "SelectAll" });
        }
        if (filter.SelectId)
        {
             selectList.Add(new Select() { Column = "SelectId" });
        }
        if (filter.SelectName)
        {
             selectList.Add(new Select() { Column = "SelectName" });
        }
        if (filter.SelectAge)
        {
             selectList.Add(new Select() { Column = "SelectAge" });
        }
        if (filter.SelectAge1)
        {
             selectList.Add(new Select() { Column = "SelectAge1" });
        }
        if (filter.SelectAgde1)
        {
             selectList.Add(new Select() { Column = "SelectAgde1" });
        }
        if (filter.Selectcool)
        {
             selectList.Add(new Select() { Column = "Selectcool" });
        }
        if (filter.SelectAgse1)
        {
             selectList.Add(new Select() { Column = "SelectAgse1" });
        }
        if (filter.SelectAgsse1)
        {
             selectList.Add(new Select() { Column = "SelectAgsse1" });
        }
        if (filter.SelectAgse1f)
        {
             selectList.Add(new Select() { Column = "SelectAgse1f" });
        }
        if (filter.SelectBirthDate)
        {
             selectList.Add(new Select() { Column = "SelectBirthDate" });
        }
        if (filter.OrderByIdAscending)
        {
             orderByList.Add(new OrderBy() { Column = "Id",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByIdDescending)
        {
             orderByList.Add(new OrderBy() { Column = "Id",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByNameAscending)
        {
             orderByList.Add(new OrderBy() { Column = "Name",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByNameDescending)
        {
             orderByList.Add(new OrderBy() { Column = "Name",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByAgeAscending)
        {
             orderByList.Add(new OrderBy() { Column = "Age",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByAgeDescending)
        {
             orderByList.Add(new OrderBy() { Column = "Age",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByAge1Ascending)
        {
             orderByList.Add(new OrderBy() { Column = "Age1",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByAge1Descending)
        {
             orderByList.Add(new OrderBy() { Column = "Age1",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByAgde1Ascending)
        {
             orderByList.Add(new OrderBy() { Column = "Agde1",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByAgde1Descending)
        {
             orderByList.Add(new OrderBy() { Column = "Agde1",Direction=OrderDirection.Descending });
        }
        if (filter.OrderBycoolAscending)
        {
             orderByList.Add(new OrderBy() { Column = "cool",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderBycoolDescending)
        {
             orderByList.Add(new OrderBy() { Column = "cool",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByAgse1Ascending)
        {
             orderByList.Add(new OrderBy() { Column = "Agse1",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByAgse1Descending)
        {
             orderByList.Add(new OrderBy() { Column = "Agse1",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByAgsse1Ascending)
        {
             orderByList.Add(new OrderBy() { Column = "Agsse1",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByAgsse1Descending)
        {
             orderByList.Add(new OrderBy() { Column = "Agsse1",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByAgse1fAscending)
        {
             orderByList.Add(new OrderBy() { Column = "Agse1f",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByAgse1fDescending)
        {
             orderByList.Add(new OrderBy() { Column = "Agse1f",Direction=OrderDirection.Descending });
        }
        if (filter.OrderByBirthDateAscending)
        {
             orderByList.Add(new OrderBy() { Column = "BirthDate",Direction=OrderDirection.Ascending });
        }
        if (filter.OrderByBirthDateDescending)
        {
             orderByList.Add(new OrderBy() { Column = "BirthDate",Direction=OrderDirection.Descending });
        }
        if (filter.NameEndsWith is not null)
        {
             whereList.Add(new Where<object>() { Column = "Name",Value=filter.NameEndsWith,Action=Operator.EndsWith });
        }
        if (filter.NameStartsWith is not null)
        {
             whereList.Add(new Where<object>() { Column = "Name",Value=filter.NameStartsWith,Action=Operator.StartsWith });
        }
        if (filter.NameContains is not null)
        {
             whereList.Add(new Where<object>() { Column = "Name",Value=filter.NameContains,Action=Operator.Contains });
        }
        if (filter.IdBiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Id",Value=filter.IdBiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.AgeBiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age",Value=filter.AgeBiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.Age1BiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age1",Value=filter.Age1BiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.Agse1BiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1",Value=filter.Agse1BiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.Agsse1BiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agsse1",Value=filter.Agsse1BiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.Agse1fBiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1f",Value=filter.Agse1fBiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.BirthDateBiggerThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "BirthDate",Value=filter.BirthDateBiggerThan,Action=Operator.BiggerThan });
        }
        if (filter.IdLessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Id",Value=filter.IdLessThan,Action=Operator.LessThan });
        }
        if (filter.AgeLessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age",Value=filter.AgeLessThan,Action=Operator.LessThan });
        }
        if (filter.Age1LessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age1",Value=filter.Age1LessThan,Action=Operator.LessThan });
        }
        if (filter.Agse1LessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1",Value=filter.Agse1LessThan,Action=Operator.LessThan });
        }
        if (filter.Agsse1LessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agsse1",Value=filter.Agsse1LessThan,Action=Operator.LessThan });
        }
        if (filter.Agse1fLessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1f",Value=filter.Agse1fLessThan,Action=Operator.LessThan });
        }
        if (filter.BirthDateLessThan is not null)
        {
             whereList.Add(new Where<object>() { Column = "BirthDate",Value=filter.BirthDateLessThan,Action=Operator.LessThan });
        }
        if (filter.IdNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Id",Value=filter.IdNotEquals,Action=Operator.NotEquals });
        }
        if (filter.NameNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Name",Value=filter.NameNotEquals,Action=Operator.NotEquals });
        }
        if (filter.AgeNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age",Value=filter.AgeNotEquals,Action=Operator.NotEquals });
        }
        if (filter.Age1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age1",Value=filter.Age1NotEquals,Action=Operator.NotEquals });
        }
        if (filter.Agde1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agde1",Value=filter.Agde1NotEquals,Action=Operator.NotEquals });
        }
        if (filter.coolNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "cool",Value=filter.coolNotEquals,Action=Operator.NotEquals });
        }
        if (filter.Agse1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1",Value=filter.Agse1NotEquals,Action=Operator.NotEquals });
        }
        if (filter.Agsse1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agsse1",Value=filter.Agsse1NotEquals,Action=Operator.NotEquals });
        }
        if (filter.Agse1fNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1f",Value=filter.Agse1fNotEquals,Action=Operator.NotEquals });
        }
        if (filter.BirthDateNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "BirthDate",Value=filter.BirthDateNotEquals,Action=Operator.NotEquals });
        }
        if (filter.IdEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Id",Value=filter.IdEquals,Action=Operator.Equals });
        }
        if (filter.IdNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "IdNot",Value=filter.IdNotEquals,Action=Operator.Equals });
        }
        if (filter.NameEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Name",Value=filter.NameEquals,Action=Operator.Equals });
        }
        if (filter.NameNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "NameNot",Value=filter.NameNotEquals,Action=Operator.Equals });
        }
        if (filter.AgeEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age",Value=filter.AgeEquals,Action=Operator.Equals });
        }
        if (filter.AgeNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "AgeNot",Value=filter.AgeNotEquals,Action=Operator.Equals });
        }
        if (filter.Age1Equals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age1",Value=filter.Age1Equals,Action=Operator.Equals });
        }
        if (filter.Age1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Age1Not",Value=filter.Age1NotEquals,Action=Operator.Equals });
        }
        if (filter.Agde1Equals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agde1",Value=filter.Agde1Equals,Action=Operator.Equals });
        }
        if (filter.Agde1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agde1Not",Value=filter.Agde1NotEquals,Action=Operator.Equals });
        }
        if (filter.coolEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "cool",Value=filter.coolEquals,Action=Operator.Equals });
        }
        if (filter.coolNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "coolNot",Value=filter.coolNotEquals,Action=Operator.Equals });
        }
        if (filter.Agse1Equals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1",Value=filter.Agse1Equals,Action=Operator.Equals });
        }
        if (filter.Agse1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1Not",Value=filter.Agse1NotEquals,Action=Operator.Equals });
        }
        if (filter.Agsse1Equals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agsse1",Value=filter.Agsse1Equals,Action=Operator.Equals });
        }
        if (filter.Agsse1NotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agsse1Not",Value=filter.Agsse1NotEquals,Action=Operator.Equals });
        }
        if (filter.Agse1fEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1f",Value=filter.Agse1fEquals,Action=Operator.Equals });
        }
        if (filter.Agse1fNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "Agse1fNot",Value=filter.Agse1fNotEquals,Action=Operator.Equals });
        }
        if (filter.BirthDateEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "BirthDate",Value=filter.BirthDateEquals,Action=Operator.Equals });
        }
        if (filter.BirthDateNotEquals is not null)
        {
             whereList.Add(new Where<object>() { Column = "BirthDateNot",Value=filter.BirthDateNotEquals,Action=Operator.Equals });
        }
return new();
    }

}
