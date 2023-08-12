using Shared.Events;

namespace Shared.Domain
{
    public class AggregateRoot : Entity
    {
        public AggregateRoot()
            : base()
        {
        }

        private readonly List<IEvent> _events = new List<IEvent>();

        public IReadOnlyList<IEvent> Events => _events;

        protected void AddEvent(IEvent @event)
        {
            _events.Add(@event);
        }
    }
}
