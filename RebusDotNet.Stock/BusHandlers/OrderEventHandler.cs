using Rebus.Handlers;
using RebusDotNet.Core.Events;

namespace RebusDotNet.Stock.BusHandlers;

public class OrderEventHandler : IHandleMessages<OrderEvent>
{
    private readonly ILogger<OrderEventHandler> _logger;

    public OrderEventHandler(ILogger<OrderEventHandler> logger)
    { 
        _logger = logger;
    }
    public Task Handle(OrderEvent message)
    {
        _logger.LogInformation($"Order receive with following parameters: OrderId={message.OrderId} ProductId={message.ProductId} Amount={message.Amount}");
       
       //Check stock and remove product units from repository
        
        return Task.CompletedTask;
           
    }
}
