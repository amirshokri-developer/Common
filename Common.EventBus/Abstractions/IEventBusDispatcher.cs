using Common.EventBus.Events;

namespace Common.EventBus.Abstractions;

public interface IEventBusDispatcher
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : IntegrationEvent;
        
    Task PublishAsync<T>(T message, string topic, CancellationToken cancellationToken = default)
        where T : IntegrationEvent;
}

