using Donut.Core.Filter;
using Donut.Core.Pagination;

namespace Donut.Filters;
public class PersonFilter: IFilter
{
    // For Every Filter
    public PaginatedRequest PaginatedRequest { get; set; }
    public bool SelectAll { get; set; }

    // Id
    public int? IdEquals { get; set; }
    public int? IdNotEquals { get; set; }
    public bool SelectId { get; set; }
    public bool OrderByIdAscending { get; set; }
    public bool OrderByIdDescending { get; set; }
    public int? IdLessThan { get; set; }
    public int? IdBiggerThan{ get; set; }


    // Name
    public string? NameEquals { get; set; }
    public string? NameNotEquals { get; set; }
    public bool SelectName { get; set; }
    public bool OrderByNameAscending { get; set; }
    public bool OrderByNameDescending { get; set; }
    public string? NameContains { get; set; }
    public string? NameStartsWith { get; set; }
    public string? NameEndsWith { get; set; }


    // Age
    public int? AgeEquals { get; set; }
    public int? AgeNotEquals { get; set; }
    public bool SelectAge { get; set; }
    public bool OrderByAgeAscending { get; set; }
    public bool OrderByAgeDescending { get; set; }
    public int? AgeLessThan { get; set; }
    public int? AgeBiggerThan{ get; set; }


    // Age1
    public long? Age1Equals { get; set; }
    public long? Age1NotEquals { get; set; }
    public bool SelectAge1 { get; set; }
    public bool OrderByAge1Ascending { get; set; }
    public bool OrderByAge1Descending { get; set; }
    public long? Age1LessThan { get; set; }
    public long? Age1BiggerThan{ get; set; }


    // Agde1
    public char? Agde1Equals { get; set; }
    public char? Agde1NotEquals { get; set; }
    public bool SelectAgde1 { get; set; }
    public bool OrderByAgde1Ascending { get; set; }
    public bool OrderByAgde1Descending { get; set; }


    // cool
    public bool? coolEquals { get; set; }
    public bool? coolNotEquals { get; set; }
    public bool Selectcool { get; set; }
    public bool OrderBycoolAscending { get; set; }
    public bool OrderBycoolDescending { get; set; }


    // Agse1
    public double? Agse1Equals { get; set; }
    public double? Agse1NotEquals { get; set; }
    public bool SelectAgse1 { get; set; }
    public bool OrderByAgse1Ascending { get; set; }
    public bool OrderByAgse1Descending { get; set; }
    public double? Agse1LessThan { get; set; }
    public double? Agse1BiggerThan{ get; set; }


    // Agsse1
    public decimal? Agsse1Equals { get; set; }
    public decimal? Agsse1NotEquals { get; set; }
    public bool SelectAgsse1 { get; set; }
    public bool OrderByAgsse1Ascending { get; set; }
    public bool OrderByAgsse1Descending { get; set; }
    public decimal? Agsse1LessThan { get; set; }
    public decimal? Agsse1BiggerThan{ get; set; }


    // Agse1f
    public DateOnly? Agse1fEquals { get; set; }
    public DateOnly? Agse1fNotEquals { get; set; }
    public bool SelectAgse1f { get; set; }
    public bool OrderByAgse1fAscending { get; set; }
    public bool OrderByAgse1fDescending { get; set; }
    public DateOnly? Agse1fLessThan { get; set; }
    public DateOnly? Agse1fBiggerThan{ get; set; }


    // BirthDate
    public DateTime? BirthDateEquals { get; set; }
    public DateTime? BirthDateNotEquals { get; set; }
    public bool SelectBirthDate { get; set; }
    public bool OrderByBirthDateAscending { get; set; }
    public bool OrderByBirthDateDescending { get; set; }
    public DateTime? BirthDateLessThan { get; set; }
    public DateTime? BirthDateBiggerThan{ get; set; }


}
