using Donut.Core.Filter;
using Donut.Core.Pagination;

namespace Donut.Filters;
public class PersonFilter: IFilter
{
    // For Every Filter
    public PaginatedRequest PaginatedRequest { get; set; }
    public bool EagerLoading { get; set; } = true;

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


    // Wifes
    public long? WifesEquals { get; set; }
    public long? WifesNotEqual { get; set; }
    public bool SelectWifes { get; set; }
    public bool OrderByWifesAscending { get; set; }
    public bool OrderByWifesDescending { get; set; }
    public long? WifesLessThanNumber { get; set; }
    public long? WifesBiggerThanNumber { get; set; }
    public long? WifesLessThanOrEqualNumber { get; set; }
    public long? WifesBiggerThanOrEqualNumber { get; set; }


    // Char
    public char? CharEquals { get; set; }
    public char? CharNotEqual { get; set; }
    public bool SelectChar { get; set; }
    public bool OrderByCharAscending { get; set; }
    public bool OrderByCharDescending { get; set; }


    // Alive
    public bool? AliveEquals { get; set; }
    public bool? AliveNotEqual { get; set; }
    public bool SelectAlive { get; set; }
    public bool OrderByAliveAscending { get; set; }
    public bool OrderByAliveDescending { get; set; }


    // Importance
    public double? ImportanceEquals { get; set; }
    public double? ImportanceNotEqual { get; set; }
    public bool SelectImportance { get; set; }
    public bool OrderByImportanceAscending { get; set; }
    public bool OrderByImportanceDescending { get; set; }
    public double? ImportanceLessThanNumber { get; set; }
    public double? ImportanceBiggerThanNumber { get; set; }
    public double? ImportanceLessThanOrEqualNumber { get; set; }
    public double? ImportanceBiggerThanOrEqualNumber { get; set; }


    // NonImportance
    public decimal? NonImportanceEquals { get; set; }
    public decimal? NonImportanceNotEqual { get; set; }
    public bool SelectNonImportance { get; set; }
    public bool OrderByNonImportanceAscending { get; set; }
    public bool OrderByNonImportanceDescending { get; set; }
    public decimal? NonImportanceLessThanNumber { get; set; }
    public decimal? NonImportanceBiggerThanNumber { get; set; }
    public decimal? NonImportanceLessThanOrEqualNumber { get; set; }
    public decimal? NonImportanceBiggerThanOrEqualNumber { get; set; }


    // Year
    public DateOnly? YearEquals { get; set; }
    public DateOnly? YearNotEqual { get; set; }
    public bool SelectYear { get; set; }
    public bool OrderByYearAscending { get; set; }
    public bool OrderByYearDescending { get; set; }
    public DateOnly? YearLessThanDate { get; set; }
    public DateOnly? YearBiggerThanDate { get; set; }
    public DateOnly? YearLessThanOrEqualDate { get; set; }
    public DateOnly? YearBiggerThanOrEqualDate { get; set; }


    // DateOfBirth
    public DateTime? DateOfBirthEquals { get; set; }
    public DateTime? DateOfBirthNotEqual { get; set; }
    public bool SelectDateOfBirth { get; set; }
    public bool OrderByDateOfBirthAscending { get; set; }
    public bool OrderByDateOfBirthDescending { get; set; }
    public DateTime? DateOfBirthLessThanDate { get; set; }
    public DateTime? DateOfBirthBiggerThanDate { get; set; }
    public DateTime? DateOfBirthLessThanOrEqualDate { get; set; }
    public DateTime? DateOfBirthBiggerThanOrEqualDate { get; set; }


}
