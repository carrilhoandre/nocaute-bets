namespace NocauteBets.Domain.Models
{
    public class Fight
    {
        public Fight()
        {
            Odds = Enumerable.Empty<IOdd>();
        }

        public Guid FightEventId { get; private set; }
        public CardType CardType { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public Guid RedCornerFighterId { get; set; }
        public Guid BlueCornerFighterId { get; set; }
        public Guid? WinnerId { get; set; }
        public FightResult FightResult { get; set; }
        public IEnumerable<IOdd> Odds { get; set; }

    }
}
