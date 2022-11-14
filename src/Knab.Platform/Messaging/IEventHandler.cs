using Knab.Platform.Modelling;

namespace Knab.Platform.Messaging;

public interface IEventHandler<in TEvent>
    where TEvent : IDomainEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}