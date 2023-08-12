namespace NocauteBets.Domain.Models
{
    public abstract class OddBase : IOdd
    {
        public abstract OddType Type { get; }
        public decimal Value { get; set; }
    }
}
