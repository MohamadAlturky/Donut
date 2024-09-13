using Donut.SharedKernel.SQL;

namespace Donut.SharedKernel.Tabels
{
    public class Person : ITabel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long Age1 { get; set; }
        public char Agde1 { get; set; }
        public bool cool { get; set; }
        public double Agse1 { get; set; }
        public decimal Agsse1 { get; set; }
        public DateOnly Agse1f { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
namespace Donut.SharedKernel.SQL
{
    public interface ITabel
    {
    }
}

