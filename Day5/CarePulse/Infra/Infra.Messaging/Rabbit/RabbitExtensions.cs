using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Infra.Messaging.Rabbit;

public static class RabbitExtensions
{
    public static IServiceCollection AddRabbitMQEventBus(this IServiceCollection services)
    {
        services.AddSingleton<IConnectionFactory, ConnectionFactory>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            return new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"]
            };
        });

        services.AddSingleton<IEventBus, RabbitMQEventBus>();

        return services;
    }
}
