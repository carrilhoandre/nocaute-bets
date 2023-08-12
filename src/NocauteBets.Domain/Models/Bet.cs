using Shared.Domain;

namespace NocauteBets.Domain.Models
{
    public class Bet : AggregateRoot
    {
        public Guid UserId { get; private set;}
        public Guid OddId { get; private set; }
        public decimal Value { get; private set; }
    }
}
