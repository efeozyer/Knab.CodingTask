using System.ComponentModel.DataAnnotations.Schema;

namespace Knab.Platform.Modelling;

public abstract class Aggregate<TIdentity> : IAggregate
{
    private readonly List<IDomainEvent> _events;

    public TIdentity Id { get; protected set; }
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    public Aggregate()
    {
        _events = new List<IDomainEvent>();
    }
    
    protected void Raise<TEvent>(TEvent @event)
        where TEvent : IDomainEvent
    {
        _events.Add(@event);
    }
}