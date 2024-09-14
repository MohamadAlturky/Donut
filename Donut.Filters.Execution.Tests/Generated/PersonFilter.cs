using Donut.Core.Filter;
using Donut.Core.Pagination;

namespace Donut.Filters;
public class PersonFilter : IFilter
{
    // For Every Filter
    public PaginatedRequest PaginatedRequest { get; set; }
    public bool EagerLoading { get; set; }

    // Id
    public int? IdEquals { get; set; }
    public int? IdNotEqual { get; set; }
    public bool SelectId { get; set; }
    public bool OrderByIdAscending { get; set; }
    public bool OrderByIdDescending { get; set; }
    public int? IdLessThanNumber { get; set; }
    public int? IdBiggerThanNumber { get; set; }
    public int? IdLessThanOrEqualNumber { get; set; }
    public int? IdBiggerThanOrEqualNumber { get; set; }


    // Name
    public string? NameEquals { get; set; }
    public string? NameNotEqual { get; set; }
    public bool SelectName { get; set; }
    public bool OrderByNameAscending { get; set; }
    public bool OrderByNameDescending { get; set; }
    public string? NameContains { get; set; }
    public string? NameStartsWith { get; set; }
    public string? NameEndsWith { get; set; }


    // Age
    public int? AgeEquals { get; set; }
    public int? AgeNotEqual { get; set; }
    public bool SelectAge { get; set; }
    public bool OrderByAgeAscending { get; set; }
    public bool OrderByAgeDescending { get; set; }
    public int? AgeLessThanNumber { get; set; }
    public int? AgeBiggerThanNumber { get; set; }
    public int? AgeLessThanOrEqualNumber { get; set; }
    public int? AgeBiggerThanOrEqualNumber { get; set; }


    // Age1
    public long? Age1Equals { get; set; }
    public long? Age1NotEqual { get; set; }
    public bool SelectAge1 { get; set; }
    public bool OrderByAge1Ascending { get; set; }
    public bool OrderByAge1Descending { get; set; }
    public long? Age1LessThanNumber { get; set; }
    public long? Age1BiggerThanNumber { get; set; }
    public long? Age1LessThanOrEqualNumber { get; set; }
    public long? Age1BiggerThanOrEqualNumber { get; set; }


    // Agde1
    public char? Agde1Equals { get; set; }
    public char? Agde1NotEqual { get; set; }
    public bool SelectAgde1 { get; set; }
    public bool OrderByAgde1Ascending { get; set; }
    public bool OrderByAgde1Descending { get; set; }


    // cool
    public bool? coolEquals { get; set; }
    public bool? coolNotEqual { get; set; }
    public bool Selectcool { get; set; }
    public bool OrderBycoolAscending { get; set; }
    public bool OrderBycoolDescending { get; set; }


    // Agse1
    public double? Agse1Equals { get; set; }
    public double? Agse1NotEqual { get; set; }
    public bool SelectAgse1 { get; set; }
    public bool OrderByAgse1Ascending { get; set; }
    public bool OrderByAgse1Descending { get; set; }
    public double? Agse1LessThanNumber { get; set; }
    public double? Agse1BiggerThanNumber { get; set; }
    public double? Agse1LessThanOrEqualNumber { get; set; }
    public double? Agse1BiggerThanOrEqualNumber { get; set; }


    // Agsse1
    public decimal? Agsse1Equals { get; set; }
    public decimal? Agsse1NotEqual { get; set; }
    public bool SelectAgsse1 { get; set; }
    public bool OrderByAgsse1Ascending { get; set; }
    public bool OrderByAgsse1Descending { get; set; }
    public decimal? Agsse1LessThanNumber { get; set; }
    public decimal? Agsse1BiggerThanNumber { get; set; }
    public decimal? Agsse1LessThanOrEqualNumber { get; set; }
    public decimal? Agsse1BiggerThanOrEqualNumber { get; set; }


    // Agse1f
    public DateOnly? Agse1fEquals { get; set; }
    public DateOnly? Agse1fNotEqual { get; set; }
    public bool SelectAgse1f { get; set; }
    public bool OrderByAgse1fAscending { get; set; }
    public bool OrderByAgse1fDescending { get; set; }
    public DateOnly? Agse1fLessThanDate { get; set; }
    public DateOnly? Agse1fBiggerThanDate { get; set; }
    public DateOnly? Agse1fLessThanOrEqualDate { get; set; }
    public DateOnly? Agse1fBiggerThanOrEqualDate { get; set; }


    // BirthDate
    public DateTime? BirthDateEquals { get; set; }
    public DateTime? BirthDateNotEqual { get; set; }
    public bool SelectBirthDate { get; set; }
    public bool OrderByBirthDateAscending { get; set; }
    public bool OrderByBirthDateDescending { get; set; }
    public DateTime? BirthDateLessThanDate { get; set; }
    public DateTime? BirthDateBiggerThanDate { get; set; }
    public DateTime? BirthDateLessThanOrEqualDate { get; set; }
    public DateTime? BirthDateBiggerThanOrEqualDate { get; set; }


}

public class Person
{

}