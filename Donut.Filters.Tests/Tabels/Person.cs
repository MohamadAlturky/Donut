using Donut.SharedKernel.SQL;

namespace Donut.SharedKernel.Tabels
{
    public class Person : ITabel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public long Wifes { get; set; }
        public char Char { get; set; }
        public bool Alive { get; set; }
        public double Importance { get; set; }
        public decimal NonImportance { get; set; }
        public DateOnly Year { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

