using Shared.Domain;

namespace NocauteBets.Domain.Models
{
    public class FighterStatistics : AggregateRoot
    {
        public int WinsByKnockout { get; set; }
        public int WinsBySubmission { get; set; }
    }
}
