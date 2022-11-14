using Knab.Platform.Modelling;

namespace Knab.Platform.Messaging;

public interface IEventDispatcher
{
    Task DispatchAsync(IEnumerable<object> @events, CancellationToken cancellationToken = default);
}