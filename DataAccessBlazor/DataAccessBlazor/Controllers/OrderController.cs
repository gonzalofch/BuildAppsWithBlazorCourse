using DataAccessBlazor;
using DataAccessBlazor.Data;
using DataAccessBlazor.Services;
using Microsoft.AspNetCore.Mvc;
namespace DataAccessBlazor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly PizzaStoreContext _context;

    public OrdersController(PizzaStoreContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(OrderState orderState)
    {
        //datos a insertar en Order
        var userId = orderState.Order.UserId;
        var orderId = orderState.Order.OrderId;
        var createdTime = DateTime.Now;
        var deliveryAddressId = orderState.Order.DeliveryAddress;
        var deliveryLocationId = orderState.Order.DeliveryLocation;

        //datos a insertar en tabla Pizzas (ordenes)
        foreach (var pizza in orderState.Order.Pizzas)
        {
            _context.Pizzas.AddRange(pizza);
        }
        _context.Orders.Add(orderState.Order);

        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrder), new { id = orderState.Order.OrderId }, orderState.Order);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }
}