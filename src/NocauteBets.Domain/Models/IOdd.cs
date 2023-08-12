namespace NocauteBets.Domain.Models
{
    public interface IOdd
    {
        OddType Type { get; }
        decimal Value { get; }
    }
}
