using Shared.Domain;

namespace NocauteBets.Domain.Models
{
    public class FightEvent : AggregateRoot
    {
        private List<Fight> _fights;
        public FightEvent(string name, DateTime date)
        {
            Name = name;
            Date = date;
            _fights = new List<Fight>();
        }

        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<Fight> Fights { get { return _fights; } }

        public void AddFights(IEnumerable<Fight> fights)
        {
            _fights.AddRange(fights);
        }
    }
}
