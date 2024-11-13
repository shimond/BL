using Infra.Messaging.Models;

namespace Infra.Messaging;

public interface IEventBus
{
    Task Publish<T>(T @event) where T : IntegrationEvent;
    Task Subscribe<T>(Func<T, Task> handler) where T : IntegrationEvent;
}
