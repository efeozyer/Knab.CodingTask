using Microsoft.Extensions.DependencyInjection;

namespace Knab.Platform.Messaging;

public class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task DispatchAsync(IEnumerable<object> events, CancellationToken cancellationToken = default)
    {
        foreach (var @event in events)
        {
            var eventType = @event.GetType();
            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
            var handlers = _serviceProvider.GetServices(handlerType).ToArray();
            
            if (handlers.Length == 0)
            {
                throw new InvalidOperationException($"Handler not found for given type {eventType}");
            }

            foreach (var handler in handlers)
            {
                if(handler == null) 
                    continue;

                var method = handler.GetType().GetMethod("HandleAsync"); 
                await (Task)method.Invoke(handler, new[] { @event, cancellationToken });
            }
        }
    }
}