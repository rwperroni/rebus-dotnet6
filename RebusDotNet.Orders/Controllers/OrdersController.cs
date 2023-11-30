using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;
using RebusDotNet.Core.Events;
using RebusDotNet.Orders.Models;
using System.Security.Cryptography;

namespace RebusDotNet.Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IBus _bus;

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        [Route("")]

        public async Task<IActionResult> SaveOrder(Order order)
        {
            _logger.LogInformation($"Executing save order for Product: {order.ProductId} , Amount: {order.Amount}");

            //call to service layer for database persistence

            var orderId = 1; // this value is retrieved from service layer after saving order

            var orderEvent = new OrderEvent
            {
                Amount = order.Amount,
                ProductId = order.ProductId,
                OrderId = orderId, 
            };

            await _bus.Publish(orderEvent);

            _logger.LogInformation($"Order {orderId} succesfully saved.");

            return Ok(orderEvent.OrderId);
        }
    }
}