using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Abstractions
{
    public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainevents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainevents.AsReadOnly();

        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] domainEvents = _domainevents.ToArray();
            _domainevents.Clear();
            return domainEvents;
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainevents.Add(domainEvent);
        }
    }
}
