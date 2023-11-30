﻿using Rebus.Config;
using RebusDotNet.Stock.BusHandlers;

namespace RebusDotNet.Stock.Extensions;

public static class WebAplicationBuilderExtension
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplicationBuilder AddBus(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        var queueName = "order-service";

        builder.Services.AddRebus(c => c
            .Transport(t => t.UseRabbitMq(configuration.GetConnectionString("RabbitMQConnection"), queueName))
        );

        builder.Services.AutoRegisterHandlersFromAssemblyOf<OrderEventHandler>();

        return builder;
    }

}
