using Shared.Domain;

namespace NocauteBets.Domain.Models
{
    public class Odd : AggregateRoot
    {
        public Guid FightId { get; set; }
    }
}
